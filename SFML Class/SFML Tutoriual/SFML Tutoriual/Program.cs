using SFML.Audio;
using SFML.System;
using System;
using System.IO;

namespace SFML_Tutoriual
{
	class Program
	{
		static void Main(string[] args)
		{



			Game game = new Game();
			MusicManager.GetInstance().Play();
			FrameRate.InitFrameRateSystem();

			while (game.UpdateWindow())
			{
				game.UpdateGame();
				CollisionManager.GetInstance().CheckCollisions();
				game.CheckGarbash();
				game.DrawGame();

				FrameRate.OnFrameEnd();
			}

		}
	}
}
