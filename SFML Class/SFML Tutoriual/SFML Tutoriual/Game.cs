using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_Tutoriual
{
	class Game
	{
		private static Vector2f windowSize;
		private RenderWindow window;
		private GamePlay gamePlay;

		public Game()
		{
			VideoMode videoMode = new VideoMode();
			videoMode.Width = 800;
			videoMode.Height = 600;

			window = new RenderWindow(videoMode, "My Game");
			window.Closed += CloseWindow;
			window.SetFramerateLimit(FrameRate.FRAMERATE_LIMIT);

			gamePlay = new GamePlay();
		}

		private void CloseWindow(object sender, EventArgs e)
		{
			window.Close();
		}

		public bool UpdateWindow()
		{
			window.DispatchEvents();
			window.Clear(Color.Black);
			return window.IsOpen;
		}

		public void UpdateGame()
		{
			gamePlay.Update();
			windowSize = window.GetView().Size;
		}
		public void DrawGame()
		{
			gamePlay.Draw(window);
			window.Display();
		}

		public static Vector2f GetWindowSize() 
		{
			return windowSize;
		}
	}
}
