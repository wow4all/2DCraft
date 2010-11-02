using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	class Planet
	{
		private string name;
		private int baseTemperature;
		private List<Item> planetItems = new List<Item>();

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public int BaseTemperature
		{
			get { return this.baseTemperature; }
			set { this.baseTemperature = value; }
		}

		public List<Item> PlanetItems
		{
			get { return this.planetItems; }
			set { this.planetItems = value; }
		}

		public Planet(string planetName, int baseTemperature)
		{
			this.name = planetName;
			this.baseTemperature = baseTemperature;
		}
	}
}