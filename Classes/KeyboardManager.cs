using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace _2DCraft
{
	static class KeyboardManager
	{
		static bool FrameLimiterEnabled = true;
		static SFML.Window.Window wnd = _2DCraft.wnd;

		public static void OnKeyPress(object sender, EventArgs e)
		{
			SFML.Window.Input input = _2DCraft.wnd.Input;

			#region debugToggles
			if (input.IsKeyDown(SFML.Window.KeyCode.F5)) // Framerate Limiter
			{
				FrameLimiterEnabled = !FrameLimiterEnabled;
				if (FrameLimiterEnabled) { wnd.SetFramerateLimit(80); } else { wnd.SetFramerateLimit(10000); }
			}
			#endregion

			/*if(input.IsKeyDown(SFML.Window.KeyCode.Escape) && input.IsKeyDown(SFML.Window.KeyCode.Space)) // Debug
			{
				_2DCraft.wnd.Close();
			}*/

			if (input.IsKeyDown(SFML.Window.KeyCode.F2))
			{
				if (!System.IO.Directory.Exists(FileSystem.DirectoryPath + "\\" + FileSystem.Directory + "\\screenshots"))
					System.IO.Directory.CreateDirectory(FileSystem.DirectoryPath + "\\" + FileSystem.Directory + "\\screenshots");

				SFML.Graphics.Image image = _2DCraft.wnd.Capture();

				if (image.SaveToFile(FileSystem.DirectoryPath + "\\" + FileSystem.Directory + "\\screenshots\\" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".png"))
					Console.WriteLine("Screenshot saved to " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".png!");
			}

			if (input.IsKeyDown(SFML.Window.KeyCode.Q))
			{
				
				//TileManager.AddTile(50, 50, MapManager.ItemList[0]); // Debug
				Console.WriteLine("Added " + MapManager.ItemList[0].ItemName.ToLower() + "!");
			}

			if (input.IsKeyDown(SFML.Window.KeyCode.E))
			{
				//TileManager.RemoveTile(50, 50); // Debug
				Console.WriteLine("Removed " + MapManager.ItemList[0].ItemName.ToLower() + "!");
			}

			// Right
			if (input.IsKeyDown(KeyCode.D))
			{
				GameManager.Camera.ViewCamera.Move(new SFML.Graphics.Vector2(32, 0));
			}

			// Left
			if (input.IsKeyDown(KeyCode.A))
			{
				GameManager.Camera.ViewCamera.Move(new SFML.Graphics.Vector2(-32, 0));
			}

			// Up
			if (input.IsKeyDown(KeyCode.W))
			{
				GameManager.Camera.ViewCamera.Move(new SFML.Graphics.Vector2(0, -32));
			}

			// Down
			if (input.IsKeyDown(KeyCode.S))
			{
				GameManager.Camera.ViewCamera.Move(new SFML.Graphics.Vector2(0, 32));
			}
		}
		public static void OnKeyRelease(object sender, EventArgs e)
		{
			
		}
	 }
}