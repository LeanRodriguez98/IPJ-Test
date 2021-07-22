using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
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

        public override void CheckGarbash()
        {
        }

        public override void Dispose()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.Dispose();
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
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
                Dispose();
            }
        }
    }
}
