using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFML_Tutoriual
{
    class GamePlay
    {
        private Player player;
        private Rock rock;
        private InvisibleWall InvisibleWall;
        private Title title;

        private TileMap background;
        private TileMap collisiones;
        public GamePlay()
        {
            //player = new Player();
            //rock = new Rock();
            //title = new Title("Hello world", new SFML.System.Vector2f(100.0f, 100.0f));
            //InvisibleWall = new InvisibleWall(new SFML.System.Vector2f(300.0f, 300.0f), new SFML.System.Vector2f(200.0f, 200.0f));
            background = new TileMap("TileMap" + Path.DirectorySeparatorChar + "Tilemap.png", "TileMap" + Path.DirectorySeparatorChar + "Tilemap.csv", 32, 32, 14, new SFML.System.Vector2f(2.0f,2.0f), TileMapType.Background);
            collisiones = new TileMap("TileMap" + Path.DirectorySeparatorChar + "Tilemap.png", "TileMap" + Path.DirectorySeparatorChar + "TileMapCollisionable.csv", 32, 32, 14, new SFML.System.Vector2f(2.0f,2.0f), TileMapType.Collisionable);
        }

        public void Update()
        {
            if (player != null)
            {
                player.Update();
            }
            if (rock != null)
            {
                rock.Update();
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
            if (title != null)
            {
                title.Draw(window);
            }
            background.Draw(window);
            collisiones.Draw(window);
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
