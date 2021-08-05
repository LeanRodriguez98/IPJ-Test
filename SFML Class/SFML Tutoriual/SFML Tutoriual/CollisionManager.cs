using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
    class CollisionManager
    {
        private static CollisionManager instance;
        public static CollisionManager GetInstance()
        {
            if (instance == null)
            {
                instance = new CollisionManager();
            }
            return instance;
        }

        private List<IColisionable> colisionables;
        private List<KeyValuePair<IColisionable, IColisionable>> collisionRegister;

        private CollisionManager()
        {
            colisionables = new List<IColisionable>();
            collisionRegister = new List<KeyValuePair<IColisionable, IColisionable>>(); 
        }

        public void AddToCollisionManager(IColisionable colisionable)
        {
            colisionables.Add(colisionable);
        }

        public void RemoveFromCollisionManager(IColisionable colisionable)
        {
            if (colisionables.Contains(colisionable))
            {
                colisionables.Remove(colisionable);
            }
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < colisionables.Count; i++)// 1[0] - 2[1] - 3[2]
            {
                for (int j = 0; j < colisionables.Count; j++)// 1[0] - 2[1] - 3[2]
                {
                    if (i != j)
                    {
                        KeyValuePair<IColisionable, IColisionable> register = new KeyValuePair<IColisionable, IColisionable>(colisionables[i], colisionables[j]);

                        if (colisionables[i].GetBounds().Intersects(colisionables[j].GetBounds()))
                        {
                            colisionables[i].OnCollision(colisionables[j]);

                            if (!collisionRegister.Contains(register))
                            {
                                colisionables[i].OnCollisionEnter(colisionables[j]);
                                collisionRegister.Add(register);
                            }
                        }
                        else
                        {
                            if (collisionRegister.Contains(register)) 
                            {
                                colisionables[i].OnCollisionExit(colisionables[j]);
                                collisionRegister.Remove(register);
                            }
                        }
                    }
                }
            }
        }
    }
}