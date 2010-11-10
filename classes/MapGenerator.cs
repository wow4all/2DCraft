using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace _2DCraft
{
	class MapGenerator
	{
		private int[,] tiles;

		private int xSize;
		private int ySize;

		private int y;
		private int x;

		private int groundHeight;

		public int[,] Tiles
		{
			get { return this.tiles; }
			set { this.tiles = value; }
		}

		public int XSize
		{
			get { return this.xSize; }
			set { this.xSize = value; }
		}

		public int YSize
		{
			get { return this.ySize; }
			set { this.ySize = value; }
		}

		public int GroundHeight
		{
			get { return this.groundHeight; }
			set { this.groundHeight = value; }
		}

		public int Y
		{
			get { return this.y; }
			set { this.y = value; }
		}

		public int X
		{
			get { return this.x; }
			set { this.x = value; }
		}

		public void Init(int xSize, int ySize)
		{
			this.tiles = new int[xSize, ySize];
			this.xSize = xSize;
			this.ySize = ySize;

			//Console.WriteLine(xSize + " " + ySize);
		}

		public void GenerateMap(double maxAir, int seed)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			bool first = true;
			//TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\mapOutput.txt");
			Random random = new Random(seed);
			int height;

			for (int y = 0; y < this.ySize; y++)
			{
				for (int x = 0; x < this.xSize; x++)
				{
					// Create a random mountain seed. (This is in the air area)
					if (y <= this.ySize * maxAir)
					{
						if (random.NextDouble() < 0.005 && y > 10) // Create a mountain seed
						{
							this.tiles[x, y] = 1;
						}
						else
							this.tiles[x, y] = 0;
						//writer.Write(this.tiles[x, y]);
					}

					// Create the ground. (Below air area)
					else
					{
						// Set the ground height so that we can be sure we won't make the mountains reach to the bottom of the map.
						if (first)
						{
							this.groundHeight = y;
							first = false;
							Console.WriteLine("Ground height = " + y);

							height = random.Next(-5, 5);
							try
							{
								this.tiles[x, y + height] = 1;
							}
							catch
							{
							}
						}

						if (y == this.groundHeight)
						{
							height = random.Next(-5, 5);
							try
							{
								this.tiles[x, y + height] = 1;
							}
							catch
							{
							}
						}
						else
						{
							this.tiles[x, y] = 1;
						}

						//writer.Write(this.tiles[x, y]);

					}

				}
				//writer.Write("\n");
			}

			// Create stuff that requires the basic map to have been generated. (mountains etc)
			for (int y = 0; y < this.groundHeight; y++)
			{
				for (int x = 0; x < this.xSize; x++)
				{
					if (y <= this.ySize * maxAir)
					{
						try
						{
							if (this.tiles[x, y] == 1 && y <= this.groundHeight)
							{
								//Console.WriteLine("Found mountain at " + x + " " + y + ".");

								// Make all this.tiles underneath the mountain seed a solid tile.
								for (int _y = y; _y < this.groundHeight; _y++)
								{
									this.tiles[x, _y] = 1;
									//writer.Write(this.tiles[x, _y]);
								}
							}
							// Create a downhill from the left side.
							else if (this.tiles[x + 1, y - 1] == 1)
							{
								this.tiles[x, y] = 1;
							}

							// Create a downhill from the right side.
							else if (this.tiles[x - 1, y - 1] == 1)
							{
								this.tiles[x, y] = 1;
							}
						}
						catch (IndexOutOfRangeException e)
						{
							//Console.WriteLine(e.Message + "(at " + x + " " + y + ")");
						}
					}
				}
			}

			//TODO: Liquify map
			for (int y = 0; y < this.ySize; y++)
			{
				for (int x = 0; x < this.xSize; x++)
				{
					if (y >= this.groundHeight && this.tiles[x, y] != 1)
					{
						if (random.NextDouble() < 0.25 && this.tiles[x, y - 1] == 2)
							this.tiles[x, y] = 2;
						else
							this.tiles[x, y] = 1;
					}
				}

			}

			Console.WriteLine("{" + this.xSize + ", " + this.ySize + "}");

			//writer.Close();
			stopwatch.Stop();

			Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms to generate map!");
		}

		public void Draw(uint _x, uint _y, uint _blockSize)
		{
			for (int y = 0; y < this.ySize; y++)
			{
				for (int x = 0; x < this.xSize; x++)
				{
					switch(this.tiles[x, y])
					{
						case 1:
							if (this.tiles[x, y - 1] == 0)
							{
								MapManager.ItemList[0].TopTexture.Position = new SFML.Graphics.Vector2(_x + (x * _blockSize), _y + (y * _blockSize));
								_2DCraft.wnd.Draw(MapManager.ItemList[0].TopTexture);
							}
							else
							{
								MapManager.ItemList[0].Texture.Position = new SFML.Graphics.Vector2(_x + (x * _blockSize), _y + (y * _blockSize));
								_2DCraft.wnd.Draw(MapManager.ItemList[0].Texture);
							}

							break;

						case 2:
							MapManager.ItemList[0].Texture.Position = new SFML.Graphics.Vector2(_x + (x * _blockSize), _y + (y * _blockSize));
							_2DCraft.wnd.Draw(MapManager.ItemList[0].Texture);

							break;
					}
				}
			}
		}
	}
}