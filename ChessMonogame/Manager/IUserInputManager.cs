using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMonogame.Manager
{
    interface IUserInputManager
    {
        public string GetUserInput(string command);
    }
}
