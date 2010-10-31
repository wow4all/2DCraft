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

        static RenderWindow wnd;
        static bool firstPress;
        
        public static void Main()
        {
            firstPress = true;
            wnd = new RenderWindow(new VideoMode(640, 480, 32), "2DCraft", Styles.Close);
            wnd.Closed += new EventHandler(OnClose);
            wnd.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPress);
            wnd.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyRelease);
            wnd.ShowMouseCursor(true);

            while (wnd.IsOpened())
            {
                wnd.DispatchEvents();
                wnd.Clear(Color.Black);
                wnd.Display();
            }
        }

        static void OnKeyPress(object sender, EventArgs e)
        {
            if (firstPress)
            {
                // do something

                firstPress = false; //reset so if you hold a button down it wont call this thing 9999999 times
            }
        }
        static void OnKeyRelease(object sender, EventArgs e)
        {
            firstPress = true; // next button press will be the first press
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
