using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	static class MapManager
	{
		static private List<Planet> planetList = new List<Planet>();
		static private List<Item> itemList = new List<Item>();
		static private List<Craftable> craftableList = new List<Craftable>();

		static private List<SFML.Graphics.Sprite> spriteList = new List<SFML.Graphics.Sprite>();


		static public List<Planet> PlanetList
		{
			get { return planetList; }
			set { planetList = value; }
		}

		static public List<Item> ItemList
		{
			get { return itemList; }
			set { itemList = value; }
		}

		static public List<Craftable> CraftableList
		{
			get { return craftableList; }
			set { craftableList = value; }
		}

		static public List<SFML.Graphics.Sprite> SpriteList
		{
			get { return spriteList; }
			set { spriteList = value; }
		}
		
		static public void SaveMap(string fileName)
		{

		}

		static public void LoadMap(string fileName)
		{

		}
	}
}