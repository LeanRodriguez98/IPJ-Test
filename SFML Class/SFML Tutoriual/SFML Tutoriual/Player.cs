using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using System.IO;

namespace SFML_Tutoriual
{
	class Player : GameObjectBase
	{
		private float speed;
		private List<Bullet> bullets;
		public Player() : base("Sprites" + Path.DirectorySeparatorChar + "pig.png", new Vector2f(0.0f, 0.0f))
		{
			sprite.Scale = new Vector2f(4.0f, 4.0f);
			speed = 250.0f;
			bullets = new List<Bullet>();
		}

		public override void Update()
		{
			Movement();
			Shoot();
			DeleteOldBullets();
			base.Update();
		}

		public override void Draw(RenderWindow window)
		{
			base.Draw(window);
			for (int i = 0; i < bullets.Count; i++)
			{
				bullets[i].Draw(window);
			}
		}

		private void Movement() 
		{
			if (Keyboard.IsKeyPressed(Keyboard.Key.D))
			{
				currentPosition.X += speed * FrameRate.GetDeltaTime();
			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.A))
			{
				currentPosition.X -= speed * FrameRate.GetDeltaTime();
			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.S))
			{
				currentPosition.Y += speed * FrameRate.GetDeltaTime();
			}
			if (Keyboard.IsKeyPressed(Keyboard.Key.W))
			{
				currentPosition.Y -= speed * FrameRate.GetDeltaTime();
			}
		}

		private void Shoot() 
		{
			if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
			{
				Vector2f spawnPosition = currentPosition;
				spawnPosition.X += (texture.Size.X * sprite.Scale.X) / 2.0f;
				spawnPosition.Y += (texture.Size.Y * sprite.Scale.Y) / 2.0f;
				bullets.Add(new Bullet(spawnPosition));
			}
		}

		private void DeleteOldBullets() 
		{
			List<int> indexToDelete = new List<int>();
			for (int i = 0; i < bullets.Count; i++)
			{
				bullets[i].Update();
				if (bullets[i].GetPosition().X > Game.GetWindowSize().X)
				{
					indexToDelete.Add(i);
				}
			}

			for (int i = indexToDelete.Count - 1; i >= 0; i--)
			{
				bullets[i].Dispose();
				bullets.RemoveAt(i);
			}
		}
	}
}
