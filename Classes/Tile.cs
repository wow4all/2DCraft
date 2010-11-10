using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace _2DCraft
{
	class Tile
	{
		private Vector2 vPos;

		private Sprite sprite;

		private FloatRect rectangle;

		public _TileProperty TileProperty;

		public enum _TileProperty
		{
			Air = 0,
			Solid = 1,
			Liquid = 2
		}

		public Vector2 VPos
		{
			get { return this.vPos; }
			set { this.vPos = value; }
		}

		public Sprite Sprite
		{
			get { return this.sprite; }
			set { this.sprite = value; }
		}

		public Tile(float x, float y, Sprite sprite, int property)
		{
			this.vPos = new Vector2(x, y);

			this.sprite = new Sprite(sprite.Image);
			sprite.Position = vPos;

			this.rectangle = new FloatRect(x, y, sprite.Width, sprite.Height);

			if (property == 0)
				this.TileProperty = _TileProperty.Air;
			else if (property == 1)
				this.TileProperty = _TileProperty.Solid;
			else if (property == 2)
				this.TileProperty = _TileProperty.Liquid;
			else
				this.TileProperty = _TileProperty.Solid;
		}

		public void Draw()
		{
			_2DCraft.wnd.Draw(this.sprite);
		}
	}
}