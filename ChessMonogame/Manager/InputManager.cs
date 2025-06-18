using System;
using ChessMonogame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ChessMonogame.Manager
{
    class InputManager
    {
        private static MouseState _lastMouseState;
        public static bool Clicked { get; private set; }
        public static Rectangle MouseRectangle { get; private set; }

        public static void Update()
        {
            var mouseState = Mouse.GetState();

            Clicked = mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released;
            MouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

            _lastMouseState = mouseState;
        }
    }
}
