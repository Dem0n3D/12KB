using System;
using System.Collections.Generic;
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
using WEB_SERVICE_CLIENT.Converter;

namespace WEB_SERVICE_CLIENT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Currency> allCur()
        {
            List<Currency> a = new List<Currency>();
            a.Add(Currency.USD);
            a.Add(Currency.RUB);
            a.Add(Currency.EUR);
            a.Add(Currency.JPY);
            a.Add(Currency.KZT);
            a.Add(Currency.UYU);
            a.Add(Currency.TRL);
            a.Add(Currency.SDD);
            return a;
        }
        public MainWindow()
        {
            InitializeComponent();
            foreach (Currency i in allCur())
            {
                cmb1.Items.Add(i);
                cmb2.Items.Add(i);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrencyConvertorSoapClient client = new CurrencyConvertorSoapClient();
            double result = client.ConversionRate((Currency)cmb1.Items[cmb1.SelectedIndex], (Currency)cmb2.Items[cmb2.SelectedIndex]);
            lbl.Content=int.Parse(tb.Text)*result;
        }

    }
}
