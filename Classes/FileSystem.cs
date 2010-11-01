using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _2DCraft
{
	static class FileSystem
	{
		static private string directory;

		static private TextReader textReader;
		static private TextWriter textWriter;

		static private Item item;
		static private Craftable craftable;

		static private string[] fileContent;

		static public string Directory
		{
			get { return directory; }
			set { directory = value; }
		}

		static public bool LoadItems()
		{
			if (!System.IO.Directory.Exists(directory))
				System.IO.Directory.CreateDirectory(directory);

			try
			{
				textReader = new StreamReader(directory + "\\items.txt");
				fileContent = textReader.ReadToEnd().Split('\n');

				textReader.Close();
			}
			catch
			{
				textWriter = new StreamWriter(directory + "\\items.txt");
				textWriter.Close();

				return false;
			}

			// TODO: Load items.

			return true;
		}
	}
}