using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace _2DCraft
{
	class Camera
	{
		private View view;

		public View ViewCamera
		{
			get { return this.view; }
			set { this.view = value; }
		}

		public Camera(float left, float top, float right, float bottom)
		{
			view = new View(new FloatRect(left, top, right, bottom));
		}
	}
}
