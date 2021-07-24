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
    class Rock : GameObjectBase, IColisionable
    {

        public Rock() : base("Sprites" + Path.DirectorySeparatorChar + "pig.png", new Vector2f(200.0f, 200.0f))
        {
            sprite.Scale = new Vector2f(10, 10);
            sprite.Color = Color.Blue;
            CollisionManager.GetInstance().AddToCollisionManager(this);

        }

        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }

        public override void Update()
        {
            if (MouseUtils.ClickOn(GetBounds(), Mouse.Button.Left))
            {
                Console.WriteLine("Mouse left");
            }

            base.Update();
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
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

        public void OnCollisionStay(IColisionable other)
        {
            if (other is Bullet)
            {
                LateDispose();
            }
        }
    }
}
