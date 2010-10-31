using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	class Craftable
	{
		private List<string> requiredItemNames = new List<string>();

		private int amount;
		private int itemAmount;

		private Item newItem;
		private string textureLocation;
		private SFML.Graphics.Sprite texture;

		public List<string> RequiredItemNames
		{
			get { return this.requiredItemNames; }
			set { this.requiredItemNames = value; }
		}

		public int Amount
		{
			get { return this.amount; }
			set { this.amount = value; }
		}

		public Item NewItem
		{
			get { return this.newItem; }
			set { this.newItem = value; }
		}

		public int ItemAmount
		{
			get { return this.itemAmount; }
			set { this.itemAmount = value; }
		}

		public string TextureLocation
		{
			get { return this.textureLocation; }
			set { this.textureLocation = value; }
		}

		public SFML.Graphics.Sprite Texture
		{
			get { return texture; }
			set { texture = value; }
		}

		/*public Craftable()
		{

		}*/
	}
}