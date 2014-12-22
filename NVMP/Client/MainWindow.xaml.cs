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
using Client.ServiceReference1;

namespace Client
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    ServerClient sc = new ServerClient();
    public MainWindow()
    {
      InitializeComponent();
    }

    private void GetCard(object sender, RoutedEventArgs e) {
      
      Int16 value = sc.GetCard();

      Label lbl = new Label();
      lbl.Content = value;
      itemlist.Items.Add(lbl);
    }
  }
}
