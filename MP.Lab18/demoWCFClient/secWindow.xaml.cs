using demoWCFClient.CalcServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WebScreen
{
    /// <summary>
    /// Логика взаимодействия для secWindow.xaml
    /// </summary>
    public partial class secWindow : Window
    {
        private string name, mainDir = @"C:\";
        private int lvlOfSec;
        List<string> paths = new List<string>();
        private SortedDictionary<string, int> levels = new SortedDictionary<string, int>();

        private Service1Client client;

        public secWindow(string n, int lvl)
        {
            InitializeComponent();

            name = n;
            lvlOfSec = lvl;

            client = new Service1Client(new NetTcpBinding(), new System.ServiceModel.EndpointAddress("net.tcp://localhost:8875"));
            client.begWork();

            paths.Add(mainDir);
            
            getFilesAndDir(paths.Last());

            if (lvlOfSec != 2)
            {
                cbChoice.Visibility = Visibility.Hidden;
                btSec.Visibility = Visibility.Hidden;
            }
            else
            {
                cbChoice.Items.Add("Скрыть");
                cbChoice.Items.Add("Только для чтения");
                cbChoice.Items.Add("Полный доступ");
                cbChoice.SelectedIndex = 0;
            }
        }
        private void getFilesAndDir(string path)
        {
            lbDir.Items.Clear();
            foreach (var v in client.getFilesAndDir(path))
            {
                lbDir.Items.Add(v);
            }
            lbDir.SelectedIndex = 0;
        }
        private void open(object sender, RoutedEventArgs e)
        {
            int c = new DirectoryInfo(paths.Last()).GetDirectories().Count();
            if (lbDir.SelectedIndex >= c)
            {
                string f = paths.Last() + lbDir.SelectedItem;

                tbCont.Text = client.openFile(f);

                if (levels.ContainsKey(f) && lvlOfSec != 2)
                {
                    tbCont.IsReadOnly = true;
                    btSave.Visibility = Visibility.Hidden;
                    tbName.Visibility = Visibility.Hidden;
                }
                else
                {
                    tbCont.IsReadOnly = false;
                    btSave.Visibility = Visibility.Visible;
                    tbName.Visibility = Visibility.Visible;
                }
            }
            else
            {
                paths.Add(paths.Last() + lbDir.SelectedItem + @"\");
                getFilesAndDir(paths.Last());
                tbCont.Clear();
            }
        }
        private void close(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("temp.txt");
            foreach (var level in levels)
            {
              sw.WriteLine("{0} {1}", level.Key, level.Value);  
            }
            sw.Close();
            this.Close();
        }
        private void save(object sender, RoutedEventArgs e)
        {
            string p = tbName.Text;
            StreamWriter sw = new StreamWriter(paths.Last() + p);
            sw.Write(tbCont.Text);
            sw.Close();
            getFilesAndDir(paths.Last());
        }
        private void retBack(object sender, RoutedEventArgs e)
        {
            if (paths.Count == 1) return;
            paths.Remove(paths.Last());
            getFilesAndDir(paths.Last());
            tbCont.Clear();
        }
        private void SecWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter: open(sender, e);
                    break;
                case  Key.Back: retBack(sender, e);
                    break;
                case Key.Escape: close(sender, e);
                    break;
                default:
                    break;
            }
        }
        private void ChangeSec(object sender, RoutedEventArgs e)
        {
            string a = paths.Last() + lbDir.SelectedItem.ToString();
            int b = cbChoice.SelectedIndex + 1;
            if (!levels.ContainsKey(a))
            {
                if (b < 3)
                {
                    levels.Add(a, b);
                }
            }
            else
            {
                if (b < 3)
                {
                    levels[a] = b;
                }
                else levels.Remove(a);
            }
            chSec(sender, null);
        }
        private void chSec(object sender, SelectionChangedEventArgs e)
        {
            int c = new DirectoryInfo(paths.Last()).GetDirectories().Count();
            if (lbDir.SelectedIndex >= c)
            {
                string a = paths.Last() + lbDir.SelectedItem.ToString();
                btDel.Visibility = Visibility.Visible;
                if (!levels.ContainsKey(a))
                {
                    lbSec.Content = "Полный доступ";
                }
                else
                {
                    if (levels[a] == 2)
                    {
                        lbSec.Content = "Только для чтения";
                        if(lvlOfSec != 2) btDel.Visibility = Visibility.Hidden;
                    }
                    else {lbSec.Content = "Скрыт";}
                }
            }
            else
            {
                lbSec.Content = "";
                btDel.Visibility = Visibility.Hidden;
            }
        }
        private void del(object sender, RoutedEventArgs e)
        {
            File.Delete(paths.Last() + lbDir.SelectedItem.ToString());
            getFilesAndDir(paths.Last());
        }
    }
}
/*
Сетевой экран, мандатная модель + первые две
с собой обфускатор, вирус и фаловый менеджер
*/