using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFML_Tutoriual
{
    public enum TileMapType { Background, Collisionable };
    class TileMap
    {

        private List<Tile> tiles;
        public TileMap(string tileMapPathTexture, string tileMapPathCSV, int tileWidht, int tileHeight, int tilesPerRow, Vector2f tilemapScale, TileMapType tileMapType)
        {
            tiles = new List<Tile>();
            List<List<int>> tileMapindexes = new List<List<int>>();
            string csvRawData = File.ReadAllText(tileMapPathCSV);
            csvRawData = csvRawData.Replace("\r", "");
            string[] rows = csvRawData.Split('\n');

            for (int i = 0; i < rows.Length - 1; i++)
            {
                tileMapindexes.Add(new List<int>());
                string[] indexes = rows[i].Split(',');
                for (int j = 0; j < indexes.Length; j++)
                {
                    tileMapindexes[i].Add(Convert.ToInt32(indexes[j]));
                }
            }

            for (int i = 0; i < tileMapindexes.Count; i++)
            {
                for (int j = 0; j < tileMapindexes[i].Count; j++)
                {
                    if (tileMapindexes[i][j] != -1)
                    {
                        IntRect tileArea = new IntRect();
                        tileArea.Height = tileHeight;
                        tileArea.Width = tileWidht;
                        tileArea.Top = (tileMapindexes[i][j] / tilesPerRow) * tileHeight;
                        tileArea.Left = (tileMapindexes[i][j] % tilesPerRow) * tileWidht;
                        switch (tileMapType)
                        {
                            case TileMapType.Background:
                                tiles.Add(new Tile(new Texture(tileMapPathTexture, tileArea), new Vector2f(tileHeight * j, tileWidht * i), tilemapScale));
                                break;
                            case TileMapType.Collisionable:
                                tiles.Add(new CollisionableTile(new Texture(tileMapPathTexture, tileArea), new Vector2f(tileHeight * j, tileWidht * i), tilemapScale));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

        }

        public void Draw(RenderWindow window)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].Draw(window);
            }
        }
    }
}
