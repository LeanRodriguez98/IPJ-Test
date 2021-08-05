using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_Tutoriual
{
    class Rock : GameObjectBase , IColisionable
    {
        private Sound sound;

        public Rock() : base("Sprites" + Path.DirectorySeparatorChar + "pig.png", new Vector2f(200.0f, 200.0f)) 
        {
            sprite.Scale = new Vector2f(10, 10);
            sprite.Color = Color.Blue;
            CollisionManager.GetInstance().AddToCollisionManager(this);
            SoundBuffer soundBuffer = new SoundBuffer("Audio" + Path.DirectorySeparatorChar + "Sounds" + Path.DirectorySeparatorChar + "Sound1.ogg");
            sound = new Sound(soundBuffer);
        }

        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
        }

        public override void Update()
        {
            //if (MouseUtils.MouseOver(GetBounds()))
            //{
            //    Console.WriteLine("Mouse over");
            //}

            if (MouseUtils.ClickOn(GetBounds(),Mouse.Button.Left))
            {
                Console.WriteLine("Mouse Left");
            }

            if (MouseUtils.ClickOn(GetBounds(), Mouse.Button.Right))
            {
                Console.WriteLine("Mouse Right");
            }

            if (MouseUtils.ClickOn(GetBounds(), Mouse.Button.Middle))
            {
                Console.WriteLine("Mouse Middle");
            }
            base.Update();
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public void OnCollision(IColisionable other)
        {
            if (other is Bullet)
            {
                sound.Play();
                LateDispose();
            }
        }

        public void OnCollisionEnter(IColisionable other)
        {
            if (other is Player)
            {
                Console.WriteLine("Rock enter");
            }
        }

        public void OnCollisionExit(IColisionable other)
        {
            if (other is Player)
            {
                Console.WriteLine("Rock exit");
            }
        }
    }
}
