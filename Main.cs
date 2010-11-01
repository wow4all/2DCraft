using System;
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
		
		public static void Main()
		{
			wnd = new RenderWindow(new VideoMode(640, 480, 32), "2DCraft", Styles.Close);
			wnd.UseVerticalSync(true);
			wnd.SetFramerateLimit(80);
			wnd.Closed += new EventHandler(OnClose);
			wnd.KeyPressed += new EventHandler<KeyEventArgs>(KeyboardManager.OnKeyPress);
			wnd.KeyReleased += new EventHandler<KeyEventArgs>(KeyboardManager.OnKeyRelease);
			wnd.EnableKeyRepeat(false);
			wnd.ShowMouseCursor(true);
            GameManager.Init();

			FileSystem.Directory = Properties.GetProperty("Directory=");

			//if (!FileSystem.LoadItems())
			//{
            //    System.Windows.Forms.MessageBox.Show("items.txt was not found.\r\nCreated it.", "Fatal Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            //    return;
            //}
			while (wnd.IsOpened())
			{
				wnd.DispatchEvents();
				wnd.Clear(Color.Black);

                if (GameManager.GameState == GameManager.gState.Menu)
                {
                    #region Draw active menu
                    foreach (Menu.Control control in GameManager.ActiveMenu.Controls)
                    {
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
	}
}