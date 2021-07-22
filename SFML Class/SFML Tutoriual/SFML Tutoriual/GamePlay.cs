using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
    class GamePlay
    {
        private Player player;
        private Rock rock;
        private InvisibleWall InvisibleWall;
        public GamePlay()
        {
            player = new Player();
            rock = new Rock();

            InvisibleWall = new InvisibleWall(new SFML.System.Vector2f(300.0f, 300.0f), new SFML.System.Vector2f(200.0f, 200.0f));
        }

        public void Update()
        {
            if (player != null)
            {
                player.Update();
            }
        }

        public void Draw(RenderWindow window)
        {
            if (player != null)
            {
                player.Draw(window);
            }
            if (rock != null)
            {
                rock.Draw(window);
            }
        }

        public void CheckGarbash()
        {
            if (player != null)
            {
                player.CheckGarbash();
                if (player.toDelete)
                {
                    player = null;
                }
            }

            if (rock != null)
            {
                rock.CheckGarbash();
                if (rock.toDelete)
                {
                    rock = null;
                }
            }
        }
    }
}
