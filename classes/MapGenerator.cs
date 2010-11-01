using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace _2DCraft
{
	static class MapGenerator
	{
		static public void GenerateMap()
		{
			//Stopwatch watch = new Stopwatch();
			//watch.Start();

			const int width = 2048;
			const int height = 384;
			const int waterheight = 228;
			const int maxheight = 338;
			const int minheight = 178;
			const int lavamin = 358;
			const int lavamax = 378;
			const int lavaheight = 373;

			int lastheight = 330;
			int lastlava = 368;

			Bitmap image = new Bitmap(width, height);
			Random rand = new Random();

			Color grass = Color.FromArgb(163, 182, 199);
			Color dirt = Color.FromArgb(121, 99, 73);
			Color water = Color.FromArgb(100, 146, 185);
			Color sky = Color.FromArgb(163, 182, 199);
			Color rock = Color.FromArgb(96, 96, 96);
			Color lava = Color.Red;
			Color lavatop = Color.DarkRed;
			Color cave = Color.FromArgb(40, 40, 40);

			for (int x = 0; x < width; x++)
			{
				for (int y = waterheight; y < height; y++)
				{
					image.SetPixel(x, y, water);
				}
				for (int y = 0; y < waterheight; y++)
				{
					image.SetPixel(x, y, sky);
				}
			}

			for (int x = 0; x < width; x++)
			{
				bool goodnumber = false;
				int randnum = lastheight;

				while (goodnumber == false)
				{
					switch (rand.Next(1, 40))
					{
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
							randnum = lastheight - 1;
							break;
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
							randnum = rand.Next(lastheight - 1, lastheight + 1);
							break;
						case 11:
						case 12:
						case 13:
							randnum = rand.Next(lastheight - 5, lastheight + 5);
							break;
						case 14:
						case 15:
							randnum = rand.Next(lastheight - 8, lastheight + 8);
							break;
						default:
							break;
					}
					if (randnum < maxheight & randnum > minheight)
					{
						goodnumber = true;
						lastheight = randnum;
					}
				}

				int randrock = rand.Next(10, 20) + randnum;

				goodnumber = false;
				int lavadepth = lastlava;

				while (goodnumber == false)
				{
					switch (rand.Next(1, 10))
					{
						case 1:
							lavadepth = rand.Next(lastlava - 1, lastlava + 1);
							break;
						case 2:
							lavadepth = rand.Next(lastlava - 2, lastlava + 2);
							break;
						default:
							lavadepth = lastlava;
							break;
					}
					if (lavadepth < lavamax & lavadepth > lavamin)
					{
						goodnumber = true;
						lastlava = lavadepth;
					}
				}

				for (int y = randnum + 2; y < randrock; y++)
				{
					image.SetPixel(x, y, dirt);
				}

				for (int y = randrock; y < lavadepth; y++)
				{
					image.SetPixel(x, y, rock);
				}

				for (int y = lavadepth; y < lavaheight; y++)
				{
					image.SetPixel(x, y, cave);
				}

				for (int y = lavaheight + 1; y < height; y++)
				{
					image.SetPixel(x, y, lava);
				}

				image.SetPixel(x, lavaheight, lavatop);

				if (randnum < waterheight)
				{
					image.SetPixel(x, randnum, grass);
					image.SetPixel(x, randnum + 1, grass);
				}


			}

			//image.Save("out.png");

			//watch.Stop();
			//Console.WriteLine(watch.ElapsedMilliseconds);
		}
	}
}