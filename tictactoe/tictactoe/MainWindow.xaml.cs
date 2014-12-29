using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using tictactoe.ServiceReference1;

namespace tictactoe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Service1Client _client;

        private int _id;

        public MainWindow()
        {
            InitializeComponent();
            _client = new Service1Client();
            _id = _client.Connect();
            if (_id == -1)
            {
                MessageBox.Show("Can't connect");
                Close();
            }
            for (int i = 0; i < 9; i++)
            {
                Button button = new Button();
                Grid.SetColumn(button, i%3);
                Grid.SetRow(button, i/3);
                button.Click += Button_Click;
                button.Tag = i;
                button.Content = "";
                grid1.Children.Add(button);
            }
            MessageBox.Show(_id.ToString());
            if (_id == 1)
            {
                WaitForOtherUser(-1);
                //Thread t = new Thread(WaitForOtherUser);
                //t.Start(new ThreadInfo() { i = -1, th = Thread.CurrentThread });
            }
        }

        struct ThreadInfo
        {
            public int i;
            public Thread th;
        }

        private void WaitForOtherUser(int i)
        {
            while (_client.GetLastClick() == i)
            {
                //MessageBox.Show(_client.GetLastClick().ToString());
            }
            i = _client.GetLastClick();
            (grid1.Children[i] as Button).Content = (_id == 1) ? "O" : "X";
        }

        private void WaitForOtherUser(object o)
        {
            ThreadInfo ti = (ThreadInfo) o;
            while (_client.GetLastClick() == ti.i)
            {
                //MessageBox.Show(_client.GetLastClick().ToString());
            }
            int i = _client.GetLastClick();
            ti.th.Interrupt();
            (grid1.Children[i] as Button).Content = (_id == 1) ? "O" : "X";
            ti.th.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button a = sender as Button;
            if (a.Content == "" && _client.CanClick(_id))
            {
                a.Content = _client.TryClick((int) a.Tag, _id) == 1 ? "X" : "O";
                if (!_client.CanClick(_id))
                {
                    WaitForOtherUser((int) a.Tag);
                    //Thread t = new Thread(WaitForOtherUser);
                    //t.Start(new ThreadInfo() { i = (int)a.Tag, th = Thread.CurrentThread});
                }
            }
        }
    }
}
