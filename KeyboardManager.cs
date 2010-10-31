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
            SFML.Window.Input Input = _2DCraft.wnd.Input;

            #region debugToggles
            if (Input.IsKeyDown(SFML.Window.KeyCode.F5)) // Framerate Limiter
            {
                FrameLimiterEnabled = !FrameLimiterEnabled;
                if (FrameLimiterEnabled) { wnd.SetFramerateLimit(80); } else { wnd.SetFramerateLimit(2000); }
            }
            #endregion
        }
        public static void OnKeyRelease(object sender, EventArgs e)
        {
        }
     }
}
