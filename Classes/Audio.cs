using System;
using IrrKlang;

// INFO: This class will probably change when needed to.

namespace _2DCraft
{
	class Audio
	{
		static private ISoundEngine soundEngine;
		static private ISound sound;

		static public bool Init()
		{
			try
			{
				soundEngine = new ISoundEngine();

				return true;
			}
			catch
			{
				return false;
			}
		}

		[STAThread]
		static public bool PlayAudio(string fileLocation)
		{
			fileLocation = FileSystem.DirectoryPath + "\\" + FileSystem.Directory + "\\music\\" + fileLocation;
			try
			{
				if (System.IO.File.Exists(fileLocation))
				{
					soundEngine = new ISoundEngine();
					soundEngine.SoundVolume = GameManager.Volume;
					sound = soundEngine.Play2D(fileLocation, false, false, StreamMode.NoStreaming, false);
				}
				else
					return false;

				return true;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
				return false;
			}
		}

		[STAThread]
		static public bool PlayMusic(string fileLocation)
		{
			fileLocation = FileSystem.DirectoryPath + "\\" + FileSystem.Directory + "\\music\\" + fileLocation;
			try
			{
				if (System.IO.File.Exists(fileLocation))
				{
					soundEngine = new ISoundEngine();
					soundEngine.SoundVolume = GameManager.Volume;
					sound = soundEngine.Play2D(fileLocation, false, false, StreamMode.Streaming, false);
				}
				else
					return false;

				return true;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
				return false;
			}
		}
	}
}