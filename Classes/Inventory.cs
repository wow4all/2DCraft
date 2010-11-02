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


	}
}