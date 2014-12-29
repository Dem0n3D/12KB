using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using SnakeGame.SnakeServiceReference;

namespace SnakeGame {
	public partial class MainWindow {
		private Snake Snake = new Snake();
		private Field Field = new Field();
		private SnakeServerClient serverClient;

		public MainWindow() {
			InitializeComponent();
			serverClient = new SnakeServerClient();
		}

		public void Drawing() {
			CanvasField.Children.Clear();
			Ellipse ellipse;
			for (int i = 0; i < Snake.snake.Count(); i++) {
				ellipse = new Ellipse {
					Height = Snake.setting.height,
					Width = Snake.setting.width,
					Fill = i == Snake.snake.Count() - 1 ? Brushes.Blue : Brushes.Black,
				};
				Canvas.SetTop(ellipse, Snake.snake[i].x);
				Canvas.SetLeft(ellipse, Snake.snake[i].y);
				CanvasField.Children.Add(ellipse);
			}
			ellipse = new Ellipse {
				Height = Snake.setting.height,
				Width = Snake.setting.width,
				Fill = Brushes.Brown
			};
			Canvas.SetTop(ellipse, Field.bonus.x);
			Canvas.SetLeft(ellipse, Field.bonus.y);
			CanvasField.Children.Add(ellipse);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e) {
			switch (e.Key) {
				case Key.Up:
					if (Snake.setting.direction != Direction.DOWN)
						Snake.setting.direction = Direction.UP;
					Drawing();
					break;
				case Key.Right:
					if (Snake.setting.direction != Direction.LEFT)
						Snake.setting.direction = Direction.RIGHT;
					Drawing();
					break;
				case Key.Down:
					if (Snake.setting.direction != Direction.UP)
						Snake.setting.direction = Direction.DOWN;
					Drawing();
					break;
				case Key.Left:
					if (Snake.setting.direction != Direction.RIGHT)
						Snake.setting.direction = Direction.LEFT;
					Drawing();
					break;
			}
		}

		private void Motion(object obj) {
			while (Snake.error != Error.ClashWithThBody) {
				serverClient.Motion(ref Snake, ref Field);
				Dispatcher.Invoke(() => Drawing());
				Thread.Sleep(Convert.ToInt32(obj));
				Dispatcher.Invoke(new Action(() => LabelBonus.Content = Snake.setting.powe_ups));
			}
		}

		private void ButtonStart_Click(object sender, RoutedEventArgs e) {
			CanvasField.Children.Clear();
			serverClient.Start(ref Snake, ref Field, (int) CanvasField.Height, (int) CanvasField.Width);
			new Thread(Motion).Start(100);
		}
	}
}