using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeServer {
	public enum Direction {
		UP,
		DOWN,
		LEFT,
		RIGHT
	};

	public enum Error {
		ClashWithThBody, No
	}

	public class Circle {
		public int x { get; set; }
		public int y { get; set; }

		public Circle() {
			x = y = 0;
		}

		public bool Equals(Circle obj) {
			return x == obj.x && y == obj.y;
		}
	}

	public class Snake {
		public List<Circle> snake;
		public Setting setting;
		public Error error;

		public Snake() {
			error = Error.No;
			snake = new List<Circle>();
			setting = new Setting();
		}
	}

	public class Setting {
		public int width { get; set; }
		public int height { get; set; }
		public int powe_ups { get; set; }
		public Direction direction { get; set; }

		public Setting() {
			width = height = 10;
			powe_ups = 0;
			direction = Direction.RIGHT;
		}
	}

	public class Field {
		public int height { get; set; }
		public int widht { get; set; }
		public Circle bonus;

		public Field() {
			bonus = new Circle();
		}
	}

	public class SnakeServer : ISnakeServer {
		public Snake snake = new Snake();
		public Field field = new Field();
		Random random = new Random();
		public void DoWork() {}

		public void Start(ref Snake snake, ref Field field, int height, int widht) {
			field.height = this.field.height = height;
			field.widht = this.field.widht = widht;
			int x = random.Next(field.height);
			int y = random.Next(field.widht);
			while (x > field.height) {
				x = random.Next(field.height);
			}
			while (y > field.widht) {
				y = random.Next(field.widht);
			}
			if (x%this.snake.setting.height != 0) {
				x += this.snake.setting.height - x%this.snake.setting.height;
				if (x == field.height) {
					x = 0;
				}
			}
			if (y%this.snake.setting.width != 0) {
				y += this.snake.setting.width - y%this.snake.setting.width;
				if (y == field.widht) {
					y = 0;
				}
			}
			this.snake.snake.Add(new Circle {x = x, y = y});
			snake = this.snake;
			field = this.field;
		}

		public void Motion(ref Snake Snake, ref Field Field) {
			for (int i = 0; i < Snake.snake.Count - 1; i++) {
				Snake.snake[i] = Snake.snake[i + 1];
			}
			Snake = AddPartOfSnake(Snake, Field);
			for (int i = 0; i < Snake.snake.Count - 2; i++) {
				if (Snake.snake[i].Equals(Snake.snake[Snake.snake.Count - 1])) {
					Snake.error = Error.ClashWithThBody;
				}
			}
			if (Field.bonus.Equals(Snake.snake[Snake.snake.Count - 1])) {
				Snake = AddPartOfSnake(Snake, Field);
				Snake.setting.powe_ups ++;
				AddBonus(ref Snake, ref Field);
			}
			else {
				Snake.snake.RemoveAt(0);
			}
		}

		public Snake AddPartOfSnake(Snake Snake, Field Field) {
			switch (Snake.setting.direction) {
				case Direction.UP:
					Snake.snake.Add(new Circle {
						x = Snake.snake[Snake.snake.Count - 1].x - Snake.setting.height < 0
							? Field.height - Snake.setting.height
							: Snake.snake[Snake.snake.Count - 1].x - Snake.setting.height,
						y = Snake.snake[Snake.snake.Count - 1].y
					});
					break;
				case Direction.RIGHT:
					Snake.snake.Add(new Circle {
						x = Snake.snake[Snake.snake.Count - 1].x,
						y = Snake.snake[Snake.snake.Count - 1].y + Snake.setting.width == Field.widht
							? 0
							: Snake.snake[Snake.snake.Count - 1].y + Snake.setting.width
					});
					break;
				case Direction.DOWN:
					Snake.snake.Add(new Circle {
						x = Snake.snake[Snake.snake.Count - 1].x + Snake.setting.height == Field.height
							? 0
							: Snake.snake[Snake.snake.Count - 1].x + Snake.setting.height,
						y = Snake.snake[Snake.snake.Count - 1].y
					});
					break;
				case Direction.LEFT:
					Snake.snake.Add(new Circle {
						x = Snake.snake[Snake.snake.Count - 1].x,
						y = Snake.snake[Snake.snake.Count - 1].y - Snake.setting.width < 0
							? Field.widht - Snake.setting.width
							: Snake.snake[Snake.snake.Count - 1].y - Snake.setting.width
					});
					break;
			}
			return Snake;
		}

		public void AddBonus(ref Snake Snake, ref Field Field) {
			Circle bonus = new Circle();
			do {
				bonus.x = random.Next(Field.height);
				bonus.y = random.Next(Field.widht);
				while (bonus.x > Field.height) {
					bonus.x = new Random().Next(Field.height);
				}
				while (bonus.y > Field.widht) {
					bonus.y = new Random().Next(Field.widht);
				}
				if (bonus.x%snake.setting.height != 0) {
					bonus.x += snake.setting.height - bonus.x%snake.setting.height;
					if (bonus.x == Field.height) {
						bonus.x = 0;
					}
				}
				if (bonus.y%Snake.setting.width != 0) {
					bonus.y += snake.setting.width - bonus.y%snake.setting.width;
					if (bonus.y == Field.widht) {
						bonus.y = 0;
					}
				}
			} while (Snake.snake.Any(circle => circle.Equals(bonus)));
			Field.bonus = bonus;
		}
	}
}