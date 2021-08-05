using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using System.IO;

namespace SFML_Tutoriual
{
    class Bullet : GameObjectBase, IColisionable
    {

        public Bullet(Vector2f startPosition) : base("Sprites" + Path.DirectorySeparatorChar + "pig.png", startPosition)
        {
            CollisionManager.GetInstance().AddToCollisionManager(this);
            
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }


        public void OnCollision(IColisionable other)
        {
            if (other is Rock)
            {
                LateDispose();
            }
        }

        public override void Update()
        {
            currentPosition.X += 50 * FrameRate.GetDeltaTime();
            base.Update();
        }

        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }

        public void OnCollisionEnter(IColisionable other)
        {
        }

        public void OnCollisionExit(IColisionable other)
        {
        }
    }
}
