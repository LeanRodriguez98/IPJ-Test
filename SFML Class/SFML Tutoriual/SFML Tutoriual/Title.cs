using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFML_Tutoriual
{
    class Title
    {
        private Text text;
        private Texture texture;
        private RenderStates renderState;
        private Vector2f currentPosition;
        public Title()
        {
            texture = new Texture("Sprites" + Path.DirectorySeparatorChar + "pig.png");
            renderState = new RenderStates(texture);
            Font arial = new Font("Fonts" + Path.DirectorySeparatorChar + "arial.ttf");
            text = new Text("Hello world!", arial);
            text.FillColor = Color.Red;
            // text.OutlineColor = Color.Yellow;
            // text.OutlineThickness = 2.0f;
            // text.Position = new SFML.System.Vector2f(100.0f, 100.0f);
            // text.Rotation = 30.0f;
            // text.Scale = new SFML.System.Vector2f(5.0f, 3.0f);
            currentPosition = text.Position;
        }

        public void DrawText(RenderWindow window)
        {
            text.Draw(window, renderState);
        }

        public void UpdateText()
        {
            currentPosition.X += 100.0f * FrameRate.GetDeltaTime();
            text.Position = currentPosition;
        }

    }
}
