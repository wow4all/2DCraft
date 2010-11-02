using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DCraft
{
	static class GameMath
	{
		static public float Distance(SFML.Graphics.Vector2 Vector1, SFML.Graphics.Vector2 Vector2)
		{
			return (float)System.Math.Sqrt((Vector2.X - Vector1.X) * (Vector2.X - Vector1.X) +
						(Vector2.Y - Vector1.Y) * (Vector2.Y - Vector1.Y));
		}
	}
}