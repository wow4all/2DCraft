using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	class Inventory
	{
		private List<Item> inventoryList;

		public List<Item> InventoryList
		{
			get { return this.inventoryList; }
			set { this.inventoryList = value; }
		}

		public int GetTotalItems()
		{
			return this.inventoryList.Count();
		}
		
		public int GetTotalUniqueItems()
		{
			int output = 0;
			List<Item> tempList = new List<Item>();

			foreach (Item item in this.inventoryList)
			{
				if (!tempList.Contains(item))
				{
					tempList.Add(item);
					output++;
				}
			}

			tempList = null;
			return output;
		}

		public int GetTotalOfItem(Item itemName)
		{
			int output = 0;

			foreach (Item item in this.inventoryList)
			{
				if (itemName == item)
					output++;
			}

			return output;
		}

		public bool HasItem(Item itemName)
		{
			if (this.inventoryList.Contains(itemName))
				return true;

			return false;
		}
	}
}