using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace SFML_Tutoriual
{
    class InvisibleWall : IColisionable
    {
        private Vector2f position;
        private Vector2f size;
        public InvisibleWall(Vector2f position, Vector2f size) 
        {
            this.position = position;
            this.size = size;
            CollisionManager.GetInstance().AddToCollisionManager(this);
        }

        public FloatRect GetBounds()
        {
            return new FloatRect(position,size);
        }

        public void OnCollisionEnter(IColisionable other)
        {
        }

        public void OnCollisionExit(IColisionable other)
        {
        }

        public void OnCollisionStay(IColisionable other)
        {
        }
    }
}
