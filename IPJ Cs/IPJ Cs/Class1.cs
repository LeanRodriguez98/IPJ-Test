using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IPJ_Cs
{
    class Shop
    {
        int coins;
        int shopSize;
        Inventory inventory;
        bool browsing;
        Shop(int shopSize)
        {
            this.shopSize = shopSize;
            inventory = new Inventory(this.shopSize);

        }

        public void Browse(Player player)
        {
            do
            {
                for (int i = 0; i < inventory.GetInventories().Count; i++)
                {
                    Console.WriteLine(i + ". " + inventory.GetInventories()[i].item.name + " " + inventory.GetInventories()[i].item.price);
                    Console.WriteLine("Choose which number of item you wish to ");
                }
                int opcion = Convert.ToInt32(Console.ReadLine());
                if (player.coins >= inventory.GetInventories()[opcion].item.price)
                {
                    player.coins = player.coins - inventory.GetInventories()[opcion].item.price;
                    Console.WriteLine("You have purchased " + inventory.GetInventories()[opcion].item.name + " for " + inventory.GetInventories()[opcion].item.price);
                }
                Console.WriteLine("Are you done buying? 1: yes  2: no");
                opcion = Convert.ToInt32(Console.ReadLine());
            } while (browsing);
        }
        void FillShop()
        {
            for (int i = 0; i < shopSize; i++)
            {
                
            }
        }
    }
}
