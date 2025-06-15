using System;
using ChessMonogame.Utilities;
using Microsoft.Xna.Framework.Input;

namespace ChessMonogame.Manager
{
    class InputManager : IUserInputManager, IUpdate
    {
        public InputManager()
        {
        }

        public string GetUserInput(string command) // Trying to find a way to create something like a Console.Readline but in Monogame
        {
            return null;
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
