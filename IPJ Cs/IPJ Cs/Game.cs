using System;
using System.Collections.Generic;
using System.Text;

class Game
{
	private Player player;
	private Inn inn;
	private Tower tower;

	public Game()
	{
		player = new Player("Pepe",100,20, Location.Inn);
		inn = new Inn();
		tower = new Tower(10);
	}

	public bool Play() 
	{
		switch (player.GetLocation())
		{
			case Location.Inn:
				player = inn.Stay(player);
				break;
			case Location.Tower:
				player = tower.StayInside(player);
				break;
			default:
				Console.WriteLine("ERROR!");
				break;
		}

		return true;
	}
}
