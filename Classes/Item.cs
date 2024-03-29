﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	class Item
	{
		private string itemName;
		private string textureLocation;
		private string topTextureLocation;
		private string findString;
		private string mineSound;
		private string minedSound;

		private int mineTime;
		private int stackAmount;
		private int findChance;
		private int minTime;
		private int maxTime;
		private int totalRequiredItems;
		private int property;

		private bool findable;
		private bool removeOnCraft;

		private List<Item> requiredEquippedItems;

		private SFML.Graphics.Sprite texture;
		private SFML.Graphics.Sprite topTexture;

		private float speed;
		private float friction;

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

		public List<Item> RequiredEquippedItems
		{
			get { return requiredEquippedItems; }
			set { requiredEquippedItems = value; }
		}

		public int TotalRequiredItems
		{
			get { return totalRequiredItems; }
			set { totalRequiredItems = value; }
		}

		public string TextureLocation
		{
			get { return this.textureLocation; }
			set { this.textureLocation = value; }
		}

		public string TopTextureLocation
		{
			get { return this.topTextureLocation; }
			set { this.topTextureLocation = value; }
		}

		public SFML.Graphics.Sprite Texture
		{
			get { return this.texture; }
			set { this.texture = value; }
		}

		public SFML.Graphics.Sprite TopTexture
		{
			get { return this.topTexture; }
			set { this.topTexture = value; }
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

		public int Property
		{
			get { return this.property; }
			set { this.property = value; }
		}

		#endregion

		public Item(string textureLocation, string topTextureLocation, int width = 16, int height = 16, float speed = 1, float friction = 1, string IName = "DefaultItem", int MTime = 1, int SAmount = 64, int FChance = 100, string FString = "Mining", int MNTime = 0, int MXTime = 24, bool canFind = true, bool deleteOnCraft = true, string MSound = "default", string MDSound = "itemfound", string RItem = "none")
		{
			this.textureLocation = textureLocation;
			this.topTextureLocation = topTextureLocation;
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
			this.requiredEquippedItems = new List<Item>();
		}

		public int GetTotalRequiredItems()
		{
			int output = 0;

			foreach (Item item in this.RequiredEquippedItems)
			{
				output++;
			}

			this.TotalRequiredItems = output;
			return output;
		}

		public void Init() // Initialize stuff that can only be initialized when we have all the data from parsing items.
		{
			this.texture = new SFML.Graphics.Sprite(new SFML.Graphics.Image(textureLocation));
			this.topTexture = new SFML.Graphics.Sprite(new SFML.Graphics.Image(topTextureLocation));

			this.texture.Width = 32;
			this.texture.Height = 32;
			this.texture.Image.Smooth = false;
			this.topTexture.Width = 32;
			this.topTexture.Height = 32;
			this.topTexture.Image.Smooth = false;
		}

		public void Draw()
		{
			_2DCraft.wnd.Draw(this.texture);
		}
	}
}