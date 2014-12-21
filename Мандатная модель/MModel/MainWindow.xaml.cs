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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MModel.ServiceReference2;

namespace MModel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public string Category { get; set; }
        public List<string> Magaz = new List<string>();
        public Service1Client Client = new Service1Client();
        public MainWindow()
        {
            InitializeComponent();
            lbL.Content += Environment.NewLine;
            lbL.Content += "то обратитесь к администратору!!!" + Environment.NewLine;
            lbL.Content += "Для этого нажмите кнопку 'Помощь' ";
        }
        
        private void A_Click(object sender, RoutedEventArgs e)
        {
            Password pas = new Password();
            pas.Owner = this;
            pas.ShowDialog();

            if (pas.Pas.Equals("qwerty"))
            {
                //Category = "A";
                //Magaz.Add(DateTime.Now + "  Пользователь зашел в систему под уровнем " + Category);
                Client.A_Button_Click(Category,Magaz.ToArray());
                User user = new User();
                user.Owner = this;
                user.Category1 = Category;
                user.ShowDialog();
                
                    foreach (var i in user.Magaz1)
                    {
                       Magaz.Add(i);
                    }
            }
            else
            {
                Client.PasIsNotCor(Category,Magaz.ToArray());
            }
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Password pas = new Password();
            pas.Owner = this;
            pas.ShowDialog();

            if (pas.Pas.Equals("asdfgh"))
            {
                Client.B_Button_Click(Category,Magaz.ToArray());
                User user = new User();
                user.Owner = this;
                user.Category1 = Category;
                user.ShowDialog();
                    foreach (var i in user.Magaz1)
                    {
                        Magaz.Add(i);
                    }
            }
            else
            {
                MessageBox.Show("Пароль неверный!", "Ok");
                Magaz.Add(DateTime.Now + "  Пользователь пытался зайти под уровнем B, но ввел неправильный пароль");
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Password pas = new Password();
            pas.Owner = this;
            pas.ShowDialog();

            if (pas.Pas.Equals("zxcvbn"))
            {
                Client.C_Button_Click(Category,Magaz.ToArray());
            User user = new User();
            user.Owner = this;
            user.Category1 = Category;
            user.ShowDialog();
                foreach (var i in user.Magaz1)
                {
                    Magaz.Add(i);
                }
            
            }
            else
            {
                MessageBox.Show("Пароль неверный!","Ok");
                Magaz.Add(DateTime.Now + "  Пользователь пытался зайти под уровнем C, но ввел неправильный пароль");
            }
        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            Password pas = new Password();
            pas.Owner = this;
            pas.ShowDialog();

            if (pas.Pas.Equals("poiuyt"))
            {
            Category = "D";
            Magaz.Add(DateTime.Now + "  Пользователь зашел в систему под уровнем " + Category);
            User user = new User();
            user.Owner = this;
            user.Category1 = Category;
                user.ShowDialog();
            
                foreach (var i in user.Magaz1)
                {
                    Magaz.Add(i);
                }
            
}
            else
            {
                MessageBox.Show("Пароль неверный!","Ok");
                Magaz.Add(DateTime.Now + "  Пользователь пытался зайти под уровнем D, но ввел неправильный пароль");
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter fs = new StreamWriter("1.txt",true,Encoding.Default);
            foreach (var i in Magaz)
            {
                fs.WriteLine(i);
            }
            fs.WriteLine(DateTime.Now + "  Закрытие программы");
            fs.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Owner = this;
            help.ShowDialog();
        }

        private void btHelp_Click(object sender, RoutedEventArgs e)
        {
            Help1 help1 = new Help1();
            help1.Owner = this;
            help1.ShowDialog();
        }
    }
}