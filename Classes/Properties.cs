using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _2DCraft
{
	static class Properties
	{
		static private string currentDirectory = Directory.GetCurrentDirectory();

		static private TextReader textReader;
		static private TextWriter textWriter;

		static private string[] fileContent;

		static private List<string> loadedProperties = new List<string>();

		static public string CurrentDirectory
		{
			get { return currentDirectory; }
		}

		static public string GetProperty(string propertyName)
		{
			string output = "PropertyNotFound (" + propertyName + ")";

			if (!loadedProperties.Contains(propertyName))
			{
				try
				{
					textReader = new StreamReader(currentDirectory + "\\properties.txt");
					fileContent = textReader.ReadToEnd().Split('\n');
					textReader.Close();
				}
				catch
				{
					textWriter = new StreamWriter(currentDirectory + "\\properties.txt");
					textWriter.WriteLine("Directory=2DCraft");
					textWriter.Close();

					textReader = new StreamReader(currentDirectory + "\\properties.txt");
					fileContent = textReader.ReadToEnd().Split('\n');
					textReader.Close();
				}

				foreach (string line in fileContent)
				{
					if (line.ToLower().StartsWith(propertyName.ToLower()))
					{
						output = line.Remove(0, propertyName.Length);
						output = output.Replace("\r", "");
						loadedProperties.Add(propertyName);

						break;
					}
				}
			}
			else
			{
				foreach (string _propertyName in loadedProperties)
				{
					if (propertyName.ToLower() == _propertyName.ToLower())
					{
						output = _propertyName;
						break;
					}
				}
			}

			return output;
		}
	}
}