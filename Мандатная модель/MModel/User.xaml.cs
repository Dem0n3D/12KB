using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using MModel.ServiceReference2;

namespace MModel
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public string Category1 { get; set; }
        public string NameFile { get; set; }
        public string FilePath { get; set; }
        public Service1Client Client1 =new Service1Client();
        List<string> lA = new List<string>();
        List<string> lB = new List<string>();
        List<string> lC = new List<string>();
        List<string> lD = new List<string>();
        List<string> lMetka = new List<string>();
        public List<string> Magaz1 = new List<string>(); 
        public User()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StreamReader fs = new StreamReader("A.txt", Encoding.Default);
            StreamReader fs1 = new StreamReader("B.txt", Encoding.Default);
            StreamReader fs2 = new StreamReader("C.txt", Encoding.Default);
            StreamReader fs3 = new StreamReader("D.txt", Encoding.Default);
            //Client1.FileRead(fs,lA.ToArray());
            //Client.FileReadAsync(fs1, lB.ToArray());
            //Client.FileReadAsync(fs2, lC.ToArray());
            //Client.FileReadAsync(fs3, lD.ToArray());
            for (int i = 0; !fs.EndOfStream; i++)
            {
                lA.Add(fs.ReadLine());
            }
            for (int i = 0; !fs1.EndOfStream; i++)
            {
                lB.Add(fs1.ReadLine());
            }
            for (int i = 0; !fs2.EndOfStream; i++)
            {
                lC.Add(fs2.ReadLine());
            }
            for (int i = 0; !fs3.EndOfStream; i++)
            {
                lD.Add(fs3.ReadLine());
            }
            
                    foreach (var i in lA)
                    {
                        lbList.Items.Add(i);
                        lMetka.Add("A");
                    }
                    foreach (var i in lB)
                    {
                        lbList.Items.Add(i);
                        lMetka.Add("B");
                    }
                    foreach (var i in lC)
                    {
                        lbList.Items.Add(i);
                        lMetka.Add("C");
                    }
                    foreach (var i in lD)
                    {
                        lbList.Items.Add(i);
                        lMetka.Add("D");
                    }
            
            fs.Close();
            fs1.Close();
            fs2.Close();
            fs3.Close();
        }

        private void lbList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int a = lbList.SelectedIndex;
            tbText.Text = "";
            tbText.IsReadOnly = false;
            btSave.IsEnabled = true;
            StreamReader fs = new StreamReader(lbList.SelectedItem.ToString(), Encoding.Default);
            if (Category1.Equals("A"))
            {
                if (lMetka[a].Equals("A"))
                {
                    //Client1.FileReadOpen(fs, Magaz1.ToArray(), tbText.Text, lbList.SelectedItem.ToString());
                    for (int j = 0; !fs.EndOfStream; j++)
                    {
                        tbText.Text += fs.ReadLine();
                    }
                    Magaz1.Add(DateTime.Now + "  Пользователь открыл файл " + lbList.SelectedItem.ToString());
                }
                else
                {
                    tbText.IsReadOnly = true;
                    btSave.IsEnabled = false;
                    for (int j = 0; !fs.EndOfStream; j++)
                    {
                        tbText.Text += fs.ReadLine();
                    }
                    Magaz1.Add(DateTime.Now + "  Пользователь открыл файл " + lbList.SelectedItem.ToString() + " с ограничением на запись и сохранение");
                }
            }
            if (Category1.Equals("B"))
            {
                if (lMetka[a].CompareTo("B") == -1)
                {
                    MessageBox.Show("Нет доступа к документу!", "Ok");
                   // Client1.AccessDenied(Magaz1.ToArray(), lbList.SelectedItem.ToString());
                    Magaz1.Add(DateTime.Now + "  Попытка доступа к файлу " + lbList.SelectedItem.ToString());
                     Magaz1.Add(DateTime.Now + "  Доступ запрещен!!!");
                }

                if (lMetka[a].Equals("B"))
                {
                    for (int j = 0; !fs.EndOfStream; j++)
                    {
                        tbText.Text += fs.ReadLine();
                    }
                    Magaz1.Add(DateTime.Now + "  Пользователь открыл файл " + lbList.SelectedItem.ToString());
                }
                else
                {
                    tbText.IsReadOnly = true;
                    btSave.IsEnabled = false;
                    for (int j = 0; !fs.EndOfStream; j++)
                    {
                        tbText.Text += fs.ReadLine();
                    }
                    Magaz1.Add(DateTime.Now + "  Пользователь открыл файл " + lbList.SelectedItem.ToString() + " с ограничением на запись и сохранение");
                }
            }
            if (Category1.Equals("C"))
            {
                if (lMetka[a].CompareTo("C") == -1)
                {
                    MessageBox.Show("Нет доступа к документу!", "Ok");
                    //Client1.AccessDenied(Magaz1.ToArray(), lbList.SelectedItem.ToString());
                    Magaz1.Add(DateTime.Now + "  Попытка доступа к файлу " + lbList.SelectedItem.ToString());
                    Magaz1.Add(DateTime.Now + "  Доступ запрещен!!!");
                }
                if (lMetka[a].Equals("C"))
                {
                    for (int j = 0; !fs.EndOfStream; j++)
                    {
                        tbText.Text += fs.ReadLine();
                    }
                    Magaz1.Add(DateTime.Now + "  Пользователь открыл файл " + lbList.SelectedItem.ToString());
                }
                else
                {
                    tbText.IsReadOnly = true;
                    btSave.IsEnabled = false;
                    for (int j = 0; !fs.EndOfStream; j++)
                    {
                        tbText.Text += fs.ReadLine();
                    }
                    Magaz1.Add(DateTime.Now + "  Пользователь открыл файл " + lbList.SelectedItem.ToString() + " с ограничением на запись и сохранение");
                }
            }
            if (Category1.Equals("D"))
            {
                if (lMetka[a].CompareTo("D") == -1)
                {
                    MessageBox.Show("Нет доступа к документу!", "Ok");
                    //Client1.AccessDenied(Magaz1.ToArray(), lbList.SelectedItem.ToString());
                    Magaz1.Add(DateTime.Now + "  Попытка доступа к файлу " + lbList.SelectedItem.ToString());
                    Magaz1.Add(DateTime.Now + "  Доступ запрещен!!!");
                }
                if (lMetka[a].Equals("D"))
                {
                    for (int j = 0; !fs.EndOfStream; j++)
                    {
                        tbText.Text += fs.ReadLine();
                    }
                    Magaz1.Add(DateTime.Now + "  Пользователь открыл файл " + lbList.SelectedItem.ToString());
                }
                else
                {
                    tbText.IsReadOnly = true;
                    btSave.IsEnabled = false;
                    for (int j = 0; !fs.EndOfStream; j++)
                    {
                        tbText.Text += fs.ReadLine();
                    }
                    Magaz1.Add(DateTime.Now + "  Пользователь открыл файл " + lbList.SelectedItem.ToString() + " с ограничением на запись и сохранение");
                }
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButton.OKCancel) ==
                MessageBoxResult.OK)
            {
                
               StreamWriter fs = new StreamWriter(lbList.SelectedItem.ToString(), false, Encoding.Default);
                fs.WriteLine(tbText.Text);
                fs.Close();
                Magaz1.Add(DateTime.Now + "  Пользователь изменил документ " + lbList.SelectedItem.ToString());
            }
        }

        private void btNew_Click(object sender, RoutedEventArgs e)
        {
            FileName fileName = new FileName();
            fileName.Owner = this;
            if (fileName.ShowDialog() == true)
            {
                NameFile = fileName.NameFile1;
                FilePath = fileName.Path1;
            }
            Magaz1.Add(DateTime.Now + "  Пользователь создал новый файл " + FilePath + "\\" + NameFile + ".txt");
            string path = FilePath + "\\" + NameFile + ".txt";
            File.WriteAllText(path, fileName.tbFText.Text, Encoding.Default);
            if (Category1.Equals("A"))
            {
                File.AppendAllText("A.txt", Environment.NewLine + path, Encoding.Default);
            }
            if (Category1.Equals("B"))
            {
                File.AppendAllText("B.txt", Environment.NewLine + path, Encoding.Default);
            }
            if (Category1.Equals("C"))
            {
                File.AppendAllText("C.txt", Environment.NewLine + path, Encoding.Default);
            }
            if (Category1.Equals("D"))
            {
                File.AppendAllText("D.txt", Environment.NewLine + path, Encoding.Default);
            }
            lA.Clear();
            lB.Clear();
            lC.Clear();
            lD.Clear();
            lMetka.Clear();
            lbList.Items.Clear();
            
            Window_Loaded(sender,e);
        }
    }
}
