using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	class Player
	{
		private string name; // MP Purpose.
		private int health;

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


	}
}
