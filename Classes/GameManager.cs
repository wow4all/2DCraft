using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace _2DCraft
{
	static class GameManager
	{
		public static Font fPixel = new Font("Resources/Fonts/volter.ttf");
		public static gState GameState;
		public static List<Menu> GameMenus;
		public static Menu ActiveMenu;
		public static Menu.Label healthLabel;

		public static Camera Camera;

		public static Player Ply;

		public static float Volume = 0.75f; // Should be able to edit this ingame.

		private static SFML.Graphics.String2D mainMenuTitle = new String2D("2DCraft!", fPixel, 30);

		public enum gState
		{
			Game = 0,
			Paused = 1,
			Menu = 2
		}

		public static void Init()
		{
			GameState = gState.Game;
			GameMenus = new List<Menu>();

			#region MainMenu
				Menu MainMenu = new Menu();
				Menu.Label TitleLabel = new Menu.Label(mainMenuTitle.Text, fPixel, (_2DCraft.wnd.Width / 2), 25);
				
				TitleLabel.Text.Style = String2D.Styles.Underlined;
				TitleLabel.Text.Size = 30;
				MainMenu.Controls.Add(TitleLabel);
				GameMenus.Add(MainMenu);
			#endregion

			ActiveMenu = MainMenu;

			Ply = new Player("Player", false, new Image(FileSystem.DirectoryPath + "\\" + FileSystem.Directory + "\\" + "textures\\player.png"), 32, 64);

			healthLabel = new Menu.Label("Health: " + Ply.Health, fPixel, 5, _2DCraft.wnd.Height - 20);
			healthLabel.Text.Style = String2D.Styles.Regular;
			healthLabel.Text.Size = 15;
			MainMenu.Controls.Add(healthLabel);

			_2DCraft.MapGen.Init(8, (int)_2DCraft.wnd.Height / 32);
			_2DCraft.MapGen.GenerateMap(0.75, 100);

			Camera = new Camera(0, 0, _2DCraft.wnd.Width, _2DCraft.wnd.Height);

			_2DCraft.wnd.CurrentView = Camera.ViewCamera;
		}

		public static void Update()
		{
			healthLabel.Text.Text = ("Health: " + Ply.Health);


		}

		public static void Draw()
		{
			if (GameState == gState.Menu)
			{
				#region Draw active menu
				foreach (Menu.Control control in ActiveMenu.Controls)
				{
					control.Update();
					control.Draw();
				}
				#endregion
			}
			else if (GameState == gState.Game)
			{
				Ply.Update();
				Ply.Draw();

				foreach (Sprite sprite in MapManager.SpriteList)
				{
					_2DCraft.wnd.Draw(sprite);
				}

				_2DCraft.MapGen.Draw(0, 0, 32);
			}
		}
	}
}