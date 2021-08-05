using SFML.Audio;
using SFML.System;
using SFML.Window;
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
			JoystickUtils.SetDrift(0.2f);
			while (game.UpdateWindow())
			{
				game.UpdateGame();
				CollisionManager.GetInstance().CheckCollisions();
				game.CheckGarbash();
				game.DrawGame();
				Joystick.Update();
				FrameRate.OnFrameEnd();
			}

		}
	}
}
