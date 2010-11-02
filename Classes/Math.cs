using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	static class GameMath
	{
		static public double CalculateDistance(SFML.Graphics.Vector2 a, SFML.Graphics.Vector2 b)
		{
			double output = 1;
			SFML.Graphics.Vector2 tempVector = new SFML.Graphics.Vector2(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));

			// TODO: Finish this piece of code.

			return output;
		}
	}
}