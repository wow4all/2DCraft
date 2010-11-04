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
		private int totalItemAmount;

		private Item newItem;

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

		public int TotalItemAmount
		{
			get { return this.totalItemAmount; }
			set { this.totalItemAmount = value; }
		}
	}
}