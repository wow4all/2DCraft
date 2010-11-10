using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace _2DCraft
{
	class Player
	{
		private string name; // MP Purpose.

		private int health;

		private bool alive;
		private bool sandbox;

		private int width;
		private int height;

		private Sprite sprite;

		private Image image;

		private Vector2 position;

		private List<Item> inventoryList;

		public List<Item> InventoryList
		{
			get { return this.inventoryList; }
			set { this.inventoryList = value; }
		}

		public bool Sandbox
		{
			get { return this.sandbox; }
			set { this.sandbox = value; }
		}

		public int Width
		{
			get { return this.width; }
			set { this.width = value; }
		}

		public int Height
		{
			get { return this.height; }
			set { this.height = value; }
		}

		public Sprite Sprite
		{
			get { return this.sprite; }
			set { this.sprite = value; }
		}

		public Image Image
		{
			get { return this.image; }
			set { this.image = value; }
		}

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public int Health
		{
			get { return this.health; }
			set { this.health = value; }
		}

		public Vector2 Position
		{
			get { return this.position; }
			set { this.position = value; }
		}

		public Player(string name, bool sandbox, Image image, uint width = 0, uint height = 0)
		{
			this.name = name;
			this.alive = true;
			this.health = 100;
			this.sandbox = sandbox;
			this.image = image;

			this.sprite = new Sprite(image);

			this.sprite.Position = new Vector2(10, 10);

			if (width > 0 && height > 0)
			{
				this.sprite.Width = width;
				this.sprite.Height = height;
			}
			else
			{
				this.sprite.Width = 32;
				this.sprite.Height = 64;
			}

			this.inventoryList = new List<Item>();
		}

		public void SetPosition(Vector2 pos)
		{
			this.sprite.Position = pos;
		}

		public float GetX()
		{
			return this.sprite.Position.X;
		}

		public float GetY()
		{
			return this.sprite.Position.Y;
		}

		public void SetX(float value)
		{
			this.sprite.Position = new Vector2(value, GetY());
		}

		public void SetY(float value)
		{
			this.sprite.Position = new Vector2(GetX(), value);
		}

		public Vector2 GetPosition()
		{
			return this.sprite.Position;
		}

		public void Hurt(int amount)
		{
			this.health -= amount;
		}

		public void Draw()
		{
			_2DCraft.wnd.Draw(this.sprite);
		}

		public void Update()
		{
			if (alive)
			{
				if (this.health <= 0)
				{
					this.alive = false;
				}


			}
			else
			{
				Console.WriteLine(this.name + " died!");
				this.Reset();
			}
		}

		public void Reset()
		{
			this.health = 100;
			this.alive = true;
			this.inventoryList = null;
			this.inventoryList = new List<Item>();

			this.sprite.Position = new Vector2(10, 10);
		}
	}
}