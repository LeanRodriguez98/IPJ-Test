using System;
using System.Collections.Generic;
using System.IO;
class Program
{
	static void Main(string[] args)
	{
		bool gameOpen = true;

		//try
		//{
			Game game = Game.GetInstance();

			do
			{
				gameOpen = game.Update();
			} while (gameOpen);
		//}
		//catch (Exception e)
		//{
		//	Console.WriteLine("ERROR INESPERADO!" + e.Message);
		//}

	}
}
