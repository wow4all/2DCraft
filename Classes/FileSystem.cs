using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace _2DCraft
{
	static class FileSystem
	{
		static private string directory;
		static public string DirectoryPath = System.IO.Directory.GetCurrentDirectory();

		static private TextReader textReader;
		static private TextWriter textWriter;

		static private Item item;
		static private Craftable craftable;
		static private Planet planet;

		static private string[] fileContent;

		static public string Directory
		{
			get { return directory; }
			set { directory = value; }
		}

		static public bool LoadPlanets()
		{
			bool parsingPlanet = false;
			bool parsingItem = false;

			if (!System.IO.Directory.Exists(directory))
				System.IO.Directory.CreateDirectory(directory);

			try
			{
				textReader = new StreamReader(directory + "\\planets.txt");
				fileContent = textReader.ReadToEnd().Split('\n');

				textReader.Close();
			}
			catch
			{
				textWriter = new StreamWriter(directory + "\\planets.txt");
				textWriter.Close();

				return false;
			}

			foreach (string line in fileContent)
			{
				string l = line.ToLower();

				l = l.Replace(" ", "");
				l = l.Replace("\r", "");
				l = l.Replace("\t", "");

				if (!parsingPlanet && !parsingItem)
				{
					if (l.ToLower().StartsWith("[planet]"))
					{
						planet = new Planet("New Planet!", 20);

						parsingPlanet = true;

						continue;
					}
				}
				else
				{
					if (!parsingItem)
					{
						if (l.StartsWith("[/planet]"))
						{
							MapManager.PlanetList.Add(planet);

							parsingPlanet = false;

							continue;
						}

						if (l.StartsWith("[item]"))
						{
							try
							{
								item = new Item(DirectoryPath + "\\" + directory + "\\textures\\default.png");
							}
							catch
							{
								return false;
							}
							parsingItem = true;

							continue;
						}

						if (l.StartsWith("basetemperature="))
						{
							l = l.Remove(0, 16);
							int output = 20;
							if (int.TryParse(l, out output))
								output = int.Parse(l);
							else
								System.Windows.Forms.MessageBox.Show("Could not convert string to integer during planet parsing.\r\n(Are all BaseTemperature values correct?)",
									"Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

							planet.BaseTemperature = output;

							continue;
						}

						if (l.StartsWith("planetname="))
						{
							l = l.Remove(0, 11);

							planet.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(l);

							continue;
						}
					}
					else
					{
						if (l.StartsWith("[/item]"))
						{
							planet.PlanetItems.Add(item);

							parsingItem = false;

							continue;
						}

						if (l.StartsWith("itemname="))
						{
							l = l.Remove(0, 9);

							item.ItemName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(l);

							continue;
						}

						if (l.StartsWith("texture="))
						{
							l = l.Remove(0, 8);

							item.TextureLocation = l;

							continue;
						}

						if (l.StartsWith("minetime="))
						{
							l = l.Remove(0, 9);
							int output;

							if (int.TryParse(l, out output))
								item.MineTime = output;
							else
							{
								item.MineTime = 1;
								System.Windows.Forms.MessageBox.Show("Could not convert string to integer during item parsing.\r\n(Are all number values correct?)",
									"Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
							}

							continue;
						}

						if (l.StartsWith("stackamount="))
						{
							l = l.Remove(0, 12);
							int output;

							if (int.TryParse(l, out output))
								item.StackAmount = output;
							else
							{
								item.StackAmount = 1;
								System.Windows.Forms.MessageBox.Show("Could not convert string to integer during item parsing.\r\n(Are all number values correct?)",
									"Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
							}

							continue;
						}

						if (l.StartsWith("chancetofind="))
						{
							l = l.Remove(0, 13);
							int output;

							if (int.TryParse(l, out output))
								item.FindChance = output;
							else
							{
								item.FindChance = 1;
								System.Windows.Forms.MessageBox.Show("Could not convert string to integer during item parsing.\r\n(Are all number values correct?)",
									"Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
							}

							continue;
						}

						if (l.StartsWith("canfind="))
						{
							l = l.Remove(0, 8);
							bool output;

							if (bool.TryParse(l, out output))
								item.Findable = output;
							else
							{
								item.Findable = true;

								System.Windows.Forms.MessageBox.Show("Could not convert string to boolean during item parsing.\r\n(Are all True/False values correct?",
									"Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
							}

							continue;
						}

						if (l.StartsWith("removeoncraft="))
						{
							l = l.Remove(0, 14);

							bool output;

							if (bool.TryParse(l, out output))
								item.RemoveOnCraft = output;
							else
							{
								item.RemoveOnCraft = true;

								System.Windows.Forms.MessageBox.Show("Could not convert string to boolean during item parsing.\r\n(Are all True/False values correct?",
									"Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
							}

							continue;
						}

						if (l.StartsWith("requiredequippeditems="))
						{
							l = l.Remove(0, 21);

							// TODO: Search through a list of existing items.
							// item.RequiredEquippedItems.Add(l);

							continue;
						}
					}
				}
			}

			return true;
		}

		static public bool LoadCraftables()
		{
			bool insideCraftable = false;
			bool insideCraftables = false;

			if (!System.IO.Directory.Exists(directory))
				System.IO.Directory.CreateDirectory(directory);

			try
			{
				textReader = new StreamReader(directory + "\\planets.txt");
				fileContent = textReader.ReadToEnd().Split('\n');

				textReader.Close();
			}
			catch
			{
				textWriter = new StreamWriter(directory + "\\planets.txt");
				textWriter.Close();

				return false;
			}
			foreach (string line in fileContent)
			{
				string l = line.ToLower();
				l = l.Replace(" ", "");
				l = l.Replace("\r", "");
				l = l.Replace("\t", "");
				if (!insideCraftables)
				{
					if (l.StartsWith("[craftables]"))
					{
						insideCraftables = true;

						craftable = new Craftable();

						continue;
					}
				}
				else
				{
					if (!insideCraftable)
					{
						if (l.StartsWith("[/craftables]"))
						{
							insideCraftables = false;

							continue;
						}

						if (l.StartsWith("[craft]"))
						{
							insideCraftable = true;

							continue;
						}
					}
					else
					{
						if (l.StartsWith("[/craft]"))
						{
							MapManager.CraftableList.Add(craftable);

							continue;
						}

						if (l.StartsWith("item="))
						{
							l = l.Remove(0, 5);
							craftable.RequiredItemNames.Add(l);

							continue;
						}

						if (l.StartsWith("amount="))
						{
							l = l.Remove(0, 7);
							int output;

							if(int.TryParse(l, out output))
							{
								output = int.Parse(l);
							}

							craftable.Amount = output;

							continue;
						}

						if (l.StartsWith("newitem="))
						{
							bool _shouldBreak = false;
							l = l.Remove(0, 8);

							foreach (Planet planet in MapManager.PlanetList)
							{
								if (_shouldBreak)
									break;

								foreach (Item item in planet.PlanetItems)
								{
									if (item.ItemName.ToLower() == l.ToLower())
									{
										craftable.NewItem = item;

										_shouldBreak = true;
										break;
									}
								}
							}

							continue;
						}
					}
				}
			}

			return true;
		}
	}
}