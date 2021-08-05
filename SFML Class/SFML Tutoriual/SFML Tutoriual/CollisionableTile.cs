using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
    class CollisionableTile : Tile , IColisionable
    {
        public CollisionableTile(Texture texture, Vector2f position, Vector2f scale) : base(texture, position, scale)
        {
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public void OnCollision(IColisionable other)
        {
        }

        public void OnCollisionEnter(IColisionable other)
        {
        }

        public void OnCollisionExit(IColisionable other)
        {
        }
    }
}
