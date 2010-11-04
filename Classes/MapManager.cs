using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	static class MapManager
	{
		static private List<Planet> planetList = new List<Planet>();
		static private List<Craftable> craftableList = new List<Craftable>();

		static private int currentTemperature;

		static public List<Planet> PlanetList
		{
			get { return planetList; }
			set { planetList = value; }
		}

		static public List<Craftable> CraftableList
		{
			get { return craftableList; }
			set { craftableList = value; }
		}

		static public int CurrentTemperature
		{
			get { return currentTemperature; }
			set { currentTemperature = value; }
		}

		static public void SaveMap(string fileName)
		{

		}

		static public void LoadMap(string fileName)
		{

		}

		
	}
}