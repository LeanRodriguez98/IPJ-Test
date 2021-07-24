using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
    public class Camera
    {
        private RenderWindow window;
        private View view;
        private Vector2f currentPosition;


        public Camera(RenderWindow window) 
        {
            this.window = window;
            view = window.GetView();
            currentPosition = view.Center;
        }


        public void UpdateCamera() 
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                currentPosition.X -= 100 * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                currentPosition.X += 100 * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                currentPosition.Y -= 100 * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                currentPosition.Y += 100 * FrameRate.GetDeltaTime();
            }
            view.Center = currentPosition;
            window.SetView(view);
        }
    }
}
