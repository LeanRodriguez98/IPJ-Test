using System;
using System.Collections.Generic;
using System.Text;

class Inn
{
	enum Options { Rest, GoToTower, Error };
	public Player Rest(Player player)
	{
		player.Heal();
		player.RestoreMana();
		return player;
	}

	public Player Stay(Player player)
	{
		bool stayInsideInn = true;
		Console.WriteLine("Welcome!");
		Options option;
		do
		{
			Console.WriteLine("Rest = 0   -   Leave = 1");

			int input = Convert.ToInt32(Console.ReadLine());

			if (input >= 0 && input < (int)Options.Error)
			{
				option = (Options)input;
			}
			else
			{
				option = Options.Error;
			}

			switch (option)
			{
				case Options.Rest:
					player = Rest(player);
					break;
				case Options.GoToTower:
					player.GoToTower();
					stayInsideInn = false;
					break;
				default:
					break;
			}
		} while (stayInsideInn);
		return player;
	}

}
