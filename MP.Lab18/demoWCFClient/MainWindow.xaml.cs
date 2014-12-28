using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using demoWCFClient.CalcServiceReference;
using WebScreen;

namespace demoWCFClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startProg(object sender, RoutedEventArgs e)
        {
            Service1Client client = new Service1Client();
            int sec;
            if (client.stProg(tbLogin.Text, pbPass.Password, out sec))
            {
                MessageBox.Show(String.Format("{0}, добро пожаловать!", tbLogin.Text), "Вход в систему",
                    MessageBoxButton.OK);
                var temp = new secWindow(tbLogin.Text, sec);
                temp.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный логин или пароль", "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
