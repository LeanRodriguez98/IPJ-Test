using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
	class GamePlay
	{
		private Player player;
		public GamePlay() 
		{
			player = new Player();
		}

		public void Update()
		{

			player.Update();
		}

		public void Draw(RenderWindow window)
		{
			player.Draw(window);
		}
	}
}
