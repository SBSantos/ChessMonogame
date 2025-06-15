using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChessMonogame.Board;

namespace ChessMonogame.Pieces
{
    class King : Piece
    {
        public King(ChessBoard chessBoard, Turn playerTurn) : base(chessBoard, playerTurn)
        {
        }

        public override bool[,] PossibleMovements()
        {
            throw new System.NotImplementedException();
        }
    }
}
