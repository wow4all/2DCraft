using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace _2DCraft
{
    class Menu
    {
        public List<Control> Controls;

        public class Control
        {
            struct Position
            {
                public static int X, Y;
            }

            public virtual void Draw()
            {
            }
            public virtual void Update()
            {
            }
        }
        public class Label : Control
        {
            public String2D Text;

            public Label(string _text, Font _font, float _x = 0, float _y = 0)
            {
                Text = new String2D(_text, _font, 14);
                Text.Position = new Vector2(_x, _y);
            }
            public override void Draw()
            {
                _2DCraft.wnd.Draw(this.Text);
            }
        }

        public Menu()
        {
            Controls = new List<Control>();
        }
    }
}
