using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
	public abstract class GameObjectBase
	{
		protected Texture texture;
		protected Sprite sprite;
		protected Vector2f currentPosition;

		public GameObjectBase(string texturePath, Vector2f startPosition) 
		{
			texture = new Texture(texturePath);
			sprite = new Sprite(texture);
			currentPosition = startPosition;
			sprite.Position = currentPosition;
		}

		public virtual void Update() 
		{
			sprite.Position = currentPosition;
		}

		public virtual void Draw(RenderWindow window) 
		{
			window.Draw(sprite);
		}
		
		public void Dispose() 
		{
			sprite.Dispose();
			texture.Dispose();
		}

		public Vector2f GetPosition()
		{
			return currentPosition;
		}
	}
}
