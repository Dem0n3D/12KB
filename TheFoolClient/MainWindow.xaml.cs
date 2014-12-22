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

namespace TheFoolClient
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			for (int i = 36; i >= 14; i--)
			{
				ViewAddCard(i);
			}
		}

		private void ViewAddCard(int _id)
		{
			List<int> lstCards = ViewGetListCard();
			lstCards.Add(_id);
			lstCards.Sort();
			foreach (int id in lstCards)
			{
				Image img = new Image();
				img.AllowDrop = true;
				img.MouseLeftButtonUp += ImgOnMouseLeftButtonUp;
				img.Source = new BitmapImage(new Uri("pack://application:,,,/img/"+ id + ".jpg"));
				img.Margin = new Thickness(2);
				img.Tag = id;
				stpCardsMain.Children.Add(img);
			}
		}
		private void ViewDelCard(int _id)
		{
			List<int> lstCards = ViewGetListCard();
			lstCards.Remove(_id);
			lstCards.Sort();
			foreach (int id in lstCards)
			{
				ViewCard(id);
			}
		}

		private void ViewCard(int id)
		{
			Image img = new Image();
			img.AllowDrop = true;
			img.MouseLeftButtonDown += ImgOnMouseLeftButtonUp;
			img.Source = new BitmapImage(new Uri("pack://application:,,,/img/" + id + ".jpg"));
			img.Margin = new Thickness(2);
			img.Tag = id;
			stpCardsMain.Children.Add(img);
		}

		private void ImgOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			Image img = sender as Image;
			ViewDelCard((int) img.Tag);
		}

		private List<int> ViewGetListCard()
		{
			List<int> lstCards = new List<int>();
			if (stpCardsMain.Children.Count != 0)
			{
				stpCardsMain.Children.GetEnumerator();
				foreach (var child in stpCardsMain.Children)
				{
					Image img = child as Image;
					if (img != null)
						lstCards.Add((int)img.Tag);
				}
				stpCardsMain.Children.Clear();
			} 
			return lstCards;
		}
	}
}
