using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
	class Bullet : GameObjectBase
	{
		public Bullet(Vector2f startPosition) : base("Sprites/pig.png", startPosition)
		{
		}

		public override void Update()
		{
			currentPosition.X += 50 * FrameRate.GetDeltaTime();
			base.Update();
		}
	}
}
