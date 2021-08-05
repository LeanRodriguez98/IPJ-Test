using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
    class Camera
    {
        private View view;
        private RenderWindow renderWindow;
        private Vector2f currentPosition;
        public Camera(RenderWindow gameWindow)
        {
            renderWindow = gameWindow;
            view = renderWindow.GetView();
            currentPosition = view.Center;
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                currentPosition.X -= 100.0f * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                currentPosition.X += 100.0f * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                currentPosition.Y -= 100.0f * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                currentPosition.Y += 100.0f * FrameRate.GetDeltaTime();
            }
            view.Center = currentPosition;
            renderWindow.SetView(view);
        }
    }
}
