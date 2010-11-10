using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace _2DCraft
{
	static class TileManager
	{
		static private int tileWidth = 32;
		static private int tileHeight = 32;

		static public int TileWidth
		{
			get { return tileWidth; }
			set { tileWidth = value; }
		}

		static public int TileHeight
		{
			get { return tileHeight; }
			set { tileHeight = value; }
		}
	}
}