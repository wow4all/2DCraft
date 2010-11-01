using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	class Item
	{
		private string itemName;
		private int mineTime;
		private int stackAmount;
		private int findChance;
		private string findString;
		private int minTime;
		private int maxTime;
		private bool findable;
		private bool removeOnCraft;
		private string mineSound;
		private string minedSound;
		private List<Item> requiredItems;
		private int totalRequiredItems;
		private string textureLocation;
		private SFML.Graphics.Sprite texture;

		private Position pos;
		private float speed;
		private float friction;

		public struct Position
		{
			private int x;
			private int y;

			public int X
			{
				get { return x; }
				set { x = value; }
			}

			public int Y
			{
				get { return y; }
				set { y = value; }
			}
		}

		#region Properties

		public string ItemName
		{
			get { return itemName; }
			set { itemName = value; }
		}

		public int MineTime
		{
			get { return mineTime; }
			set { mineTime = value; }
		}

		public int StackAmount
		{
			get { return stackAmount; }
			set { stackAmount = value; }
		}

		public int FindChance
		{
			get { return findChance; }
			set { findChance = value; }
		}

		public string FindString
		{
			get { return findString; }
			set { findString = value; }
		}

		public int MinTime
		{
			get { return minTime; }
			set { minTime = value; }
		}

		public int MaxTime
		{
			get { return maxTime; }
			set { maxTime = value; }
		}

		public bool Findable
		{
			get { return findable; }
			set { findable = value; }
		}

		public bool RemoveOnCraft
		{
			get { return removeOnCraft; }
			set { removeOnCraft = value; }
		}

		public string MineSound
		{
			get { return mineSound; }
			set { mineSound = value; }
		}

		public string MinedSound
		{
			get { return minedSound; }
			set { minedSound = value; }
		}

		public List<Item> RequiredItems
		{
			get { return requiredItems; }
			set { requiredItems = value; }
		}

		public int TotalRequiredItems
		{
			get { return totalRequiredItems; }
			set { totalRequiredItems = value; }
		}

		public string TextureLocation
		{
			get { return textureLocation; }
			set { textureLocation = value; }
		}

		public SFML.Graphics.Sprite Texture
		{
			get { return this.texture; }
			set { this.texture = value; }
		}

		public float Speed
		{
			get { return this.speed; }
			set { this.speed = value; }
		}

		public float Friction
		{
			get { return this.friction; }
			set { this.friction = value; }
		}

		#endregion

		public Item(string textureLocation, int x = 0, int y = 0, int width = 16, int height = 16, float speed = 1, float friction = 1, string IName = "DefaultItem", int MTime = 1, int SAmount = 64, int FChance = 100, string FString = "Mining", int MNTime = 0, int MXTime = 24, bool canFind = true, bool deleteOnCraft = true, string MSound = "default", string MDSound = "itemfound", string RItem = "none")
		{
			this.pos = new Position();
			this.pos.X = x;
			this.pos.Y = y;
			this.textureLocation = textureLocation;
			this.texture = new SFML.Graphics.Sprite(new SFML.Graphics.Image(textureLocation));
			this.itemName = IName;
			this.mineTime = MTime;
			this.stackAmount = SAmount;
			this.findChance = FChance;
			this.findString = FString;
			this.minTime = MNTime;
			this.maxTime = MXTime;
			this.findable = canFind;
			this.removeOnCraft = deleteOnCraft;
			this.mineSound = MSound;
			this.minedSound = MDSound;
			this.requiredItems = new List<Item>();
		}

		public int GetTotalRequiredItems()
		{
			int output = 0;

			foreach (Item item in this.RequiredItems)
			{
				output++;
			}

			this.TotalRequiredItems = output;
			return output;
		}

		public void Draw()
		{
			
		}
	}
}