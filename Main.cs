﻿using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using System.Diagnostics;
using System.Media;

namespace _2DCraft
{
	class _2DCraft
	{

		public static RenderWindow wnd;

		private static Stopwatch watch = new Stopwatch();
		
		public static void Main()
		{
			Init();

			while (wnd.IsOpened())
			{
				wnd.DispatchEvents();
				wnd.Clear(Color.Black);

				if (GameManager.GameState == GameManager.gState.Menu)
				{
					#region Draw active menu
					foreach (Menu.Control control in GameManager.ActiveMenu.Controls)
					{
						control.Update();
						control.Draw();
					}
					#endregion
				}

				wnd.Display();
			}
		}
		static void OnClose(object sender, EventArgs e)
		{
			RenderWindow wnd = (RenderWindow)sender;
			wnd.Close();
			if (Debugger.IsAttached)
				Process.GetCurrentProcess().Kill();
		}

		static private void Init()
		{
			watch.Start();

			wnd = new RenderWindow(new VideoMode(640, 480, 32), "2DCraft", Styles.Close);
			wnd.UseVerticalSync(true);
			wnd.SetFramerateLimit(120);
			wnd.Closed += new EventHandler(OnClose);
			wnd.KeyPressed += new EventHandler<KeyEventArgs>(KeyboardManager.OnKeyPress);
			wnd.KeyReleased += new EventHandler<KeyEventArgs>(KeyboardManager.OnKeyRelease);
			wnd.EnableKeyRepeat(false);
			wnd.ShowMouseCursor(true);
			GameManager.Init();

			FileSystem.Directory = Properties.GetProperty("Directory=");

			if (!FileSystem.LoadPlanets())
			{
				System.Windows.Forms.MessageBox.Show("items.txt was not found.\r\nCreated it.", "Fatal Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

				return;
			}

			foreach (Planet planet in MapManager.PlanetList) // This MUST be done AFTER loading the planets! (because of how the loading of textures for the items work.)
			{
				foreach (Item item in planet.PlanetItems)
				{
					item.Init();
				}
			}
			Lua.Init(); // Prolonges initialization by atleast 100 ms.

			watch.Stop();

			Console.WriteLine(watch.ElapsedMilliseconds + " ms taken to initialize!", "Debugging Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
		}
	}
}