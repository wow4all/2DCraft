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

		static private StreamReader streamReader;
		static private StreamWriter streamWriter;

		static private Item item;
		static private Craftable craftable;

		static public string Directory
		{
			get { return directory; }
			set { directory = value; }
		}
	}
}