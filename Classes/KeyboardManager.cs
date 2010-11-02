using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		}
		public static void OnKeyRelease(object sender, EventArgs e)
		{

		}
	 }
}