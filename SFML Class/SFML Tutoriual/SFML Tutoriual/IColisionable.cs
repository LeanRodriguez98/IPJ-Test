using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_Tutoriual
{
    interface IColisionable
    {
        public FloatRect GetBounds();
        public void OnCollisionStay(IColisionable other);
        public void OnCollisionEnter(IColisionable other);
        public void OnCollisionExit(IColisionable other);
    }
}
