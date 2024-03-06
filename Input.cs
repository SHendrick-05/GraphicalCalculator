using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalCalculator
{
    internal static class Input
    {
        internal static MouseState mouseState;
        internal static MouseState prevMouseState;

        internal static void Update()
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
        }
    }
}
