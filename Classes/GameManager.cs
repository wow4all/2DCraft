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

		private static SFML.Graphics.String2D mainMenuTitle = new String2D("2DCraft!", fPixel, 30);

		public enum gState
		{
			Game = 0,
			Paused = 1,
			Menu = 2
		}

		public static void Init()
		{
			GameState = gState.Menu;
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

		}
	}
}