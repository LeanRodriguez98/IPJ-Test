using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
class Floor
{
	public List<Enemy> enemies;
	public Floor(int maxEnemeiesInFloor)
	{
		enemies = new List<Enemy>();
		Random random = new Random();
		int enemiesInFloor = random.Next(1, maxEnemeiesInFloor);
		for (int i = 0; i < enemiesInFloor; i++)
		{
			enemies.Add(new Enemy("Beholder", 1000, 50, 20, 50));
		}
	}

	public BinaryWriter Save(BinaryWriter bw) 
	{
		bw.Write(enemies.Count);
		for (int i = 0; i < enemies.Count; i++)
		{
			bw = enemies[i].Save(bw);
		}
		return bw;
	}

	public Player Fight(Player player)
	{
		for (int i = 0; i < enemies.Count; i++)
		{
			player = enemies[i].Attack(player);
		}

		enemies = player.Attack(enemies);

		List<Enemy> enemiesAlive = new List<Enemy>();
		for (int i = 0; i < enemies.Count; i++)
		{
			if (enemies[i].IsDead() == false)
			{
				enemiesAlive.Add(enemies[i]);
			}
		}
		enemies = enemiesAlive;
		return player;
	}
}
