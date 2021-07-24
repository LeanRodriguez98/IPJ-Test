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
		private Camera camera;

		public Game()
		{
			VideoMode videoMode = new VideoMode();
			videoMode.Width = 800;
			videoMode.Height = 600;

			window = new RenderWindow(videoMode, "My Game");
			window.Closed += CloseWindow;
			window.SetFramerateLimit(FrameRate.FRAMERATE_LIMIT);

			camera = new Camera(window);
			gamePlay = new GamePlay();
			MouseUtils.SetWindow(window);
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
			camera.UpdateCamera();
			windowSize = window.GetView().Size;
		}
		public void DrawGame()
		{
			gamePlay.Draw(window);
			window.Display();
		}

		public void CheckGarbash() 
		{
			gamePlay.CheckGarbash();
		}

		public static Vector2f GetWindowSize() 
		{
			return windowSize;
		}
	}
}
