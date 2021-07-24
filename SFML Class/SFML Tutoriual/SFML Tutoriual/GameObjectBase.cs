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
		private bool lateDispose;
		public bool toDelete;
		public GameObjectBase(string texturePath, Vector2f startPosition) 
		{
			texture = new Texture(texturePath);
			sprite = new Sprite(texture);
			currentPosition = startPosition;
			sprite.Position = currentPosition;
			toDelete = false;
			lateDispose = false;
		}

		public virtual void Update() 
		{
			sprite.Position = currentPosition;
		}

		public virtual void Draw(RenderWindow window) 
		{
			window.Draw(sprite);
		}
		
		public virtual void DisposeNow() 
		{
			sprite.Dispose();
			texture.Dispose();
			toDelete = true;
		}

		public void LateDispose() 
		{
			lateDispose = true;
		}

		public virtual void CheckGarbash() 
		{
            if (lateDispose)
            {
				DisposeNow();
            }
		}

		public Vector2f GetPosition()
		{
			return currentPosition;
		}
	}
}
