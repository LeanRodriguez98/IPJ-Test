using System;
using System.Collections.Generic;
using System.IO;
class Program
{
	static void Main(string[] args)
	{
		bool gameOpen = true;

		try
		{
			Game game = new Game();
			do
			{
				gameOpen = game.Play();
			} while (gameOpen);
		}
		catch (Exception e)
		{
			Console.WriteLine("ERROR INESPERADO!" + e.Message);
		}

	}
}
