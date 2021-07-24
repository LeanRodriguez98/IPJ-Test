using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using System.IO;
namespace SFML_Tutoriual
{
    class Player : GameObjectBase, IColisionable
    {
        private float speed;
        private List<Bullet> bullets;
        private float fireDelay;
        private float fireRate;
        public Player() : base("Sprites" + Path.DirectorySeparatorChar + "pig.png", new Vector2f(0.0f, 0.0f))
        {
            sprite.Scale = new Vector2f(4.0f, 4.0f);
            speed = 250.0f;
            bullets = new List<Bullet>();
            CollisionManager.GetInstance().AddToCollisionManager(this);
            fireRate = 2.0f;
            fireDelay = 2.0f;
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
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && fireDelay >= fireRate )
            {
                Vector2f spawnPosition = currentPosition;
                spawnPosition.X += (texture.Size.X * sprite.Scale.X) / 2.0f;
                spawnPosition.Y += (texture.Size.Y * sprite.Scale.Y) / 2.0f;
                bullets.Add(new Bullet(spawnPosition));
                fireDelay = 0.0f;
            }
            fireDelay += FrameRate.GetDeltaTime();
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
                bullets[i].DisposeNow();
                bullets.RemoveAt(i);
            }
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }
        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }

        public override void CheckGarbash()
        {
            List<int> indexToDelete = new List<int>();
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].CheckGarbash();
                if (bullets[i].toDelete)
                {
                    indexToDelete.Add(i);
                }
            }
            for (int i = 0; i < indexToDelete.Count; i++)
            {
                bullets.RemoveAt(i);
            }
            if (toDelete == true)
            {
                DisposeNow();
            }
            base.CheckGarbash();
        }

        public void OnCollisionStay(IColisionable other)
        {
        }

        public void OnCollisionEnter(IColisionable other)
        {
            if (other is Rock)
            {
                Console.WriteLine("Player enter");
            }
        }

        public void OnCollisionExit(IColisionable other)
        {
            if (other is Rock)
            {
                Console.WriteLine("Player exit");
            }
        }
    }
}
