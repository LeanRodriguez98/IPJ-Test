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
        bool a = true;
        public Player() : base("Sprites" + Path.DirectorySeparatorChar + "pig.png", new Vector2f(0.0f, 0.0f))
        {
            sprite.Scale = new Vector2f(4.0f, 4.0f);
            speed = 250.0f;
            bullets = new List<Bullet>();
            CollisionManager.GetInstance().AddToCollisionManager(this);
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
            if (Joystick.IsConnected(0))
            {
                if (JoystickUtils.GetAxis(0, Joystick.Axis.U) != 0)
                {
                    currentPosition.X += JoystickUtils.GetAxis(0, Joystick.Axis.U) * speed * FrameRate.GetDeltaTime();
                }
                if (JoystickUtils.GetAxis(0, Joystick.Axis.V) != 0)
                {
                    currentPosition.Y += JoystickUtils.GetAxis(0, Joystick.Axis.V) * speed * FrameRate.GetDeltaTime();
                }

                if (Joystick.IsButtonPressed(0,JoystickUtils.GetButton(JoystickType.XBOX360,GameButtons.MainButtonDown)))
                {
                    FrameRate.SetTimeScale(0.5f);
                }

                if (Joystick.IsButtonPressed(0, JoystickUtils.GetButton(JoystickType.XBOX360, GameButtons.MainButtonRight)))
                {
                    FrameRate.SetTimeScale(1.0f);
                }



            }
            else
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
            //Console.WriteLine(Joystick.GetAxisPosition(0, Joystick.Axis.PovX));  Cruzeta
            //Console.WriteLine(Joystick.GetAxisPosition(0, Joystick.Axis.PovY));

            //Console.WriteLine(Joystick.GetAxisPosition(0, Joystick.Axis.U));  Stick derecho
            //Console.WriteLine(Joystick.GetAxisPosition(0, Joystick.Axis.V));

            //Console.WriteLine(Joystick.GetAxisPosition(0, Joystick.Axis.X));   Stick izquierdo
            //Console.WriteLine(Joystick.GetAxisPosition(0, Joystick.Axis.Y));

            //Console.WriteLine(Joystick.GetAxisPosition(0, Joystick.Axis.R));   triggers
            //Console.WriteLine(Joystick.GetAxisPosition(0, Joystick.Axis.Z));

            if (Keyboard.IsKeyPressed(Keyboard.Key.J))
            {
                LateDispose();
            }
        }

        private void Shoot()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && a)
            {
                Vector2f spawnPosition = currentPosition;
                spawnPosition.X += (texture.Size.X * sprite.Scale.X) / 2.0f;
                spawnPosition.Y += (texture.Size.Y * sprite.Scale.Y) / 2.0f;
                bullets.Add(new Bullet(spawnPosition));
                a = false;
            }
        }

        private void DeleteOldBullets()
        {
            List<int> indexToDelete = new List<int>();
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
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

        public void OnCollision(IColisionable other)
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
