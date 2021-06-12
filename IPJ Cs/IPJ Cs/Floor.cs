using System;
using System.Collections.Generic;
using System.Text;

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
			enemies.Add(new Enemy("HobGoblin", 20, 5, 2, 5));
		}
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
