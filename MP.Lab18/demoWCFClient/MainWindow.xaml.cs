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

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            //Service1Client calClient = new Service1Client("NetTcpBinding_IService1");

            Service1Client calClient = new Service1Client(new NetTcpBinding(), new System.ServiceModel.EndpointAddress("net.tcp://localhost:8875"));

            int A = int.Parse(tba.Text);
            int B = int.Parse(tbb.Text);
            //int C = calClient.Add(A, B);

            //int C = calClient.Sub(new SubData() {A = A, B = B});

            string header = "bla-bla-bla";
            int C = calClient.Div(ref header, A, B);
            lblc.Content = header + C.ToString();
            
        }
    }
}
