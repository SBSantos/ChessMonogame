using System;
using System.Runtime.CompilerServices;
using ChessMonogame.Utilities;
using Microsoft.Xna.Framework;

namespace ChessMonogame.Board
{
    abstract class Piece : IDraw
    {
        public Vector2? Position { get; set; }
        public Turn PlayerTurn { get; protected set; }
        private int MovementsQuantity { get; set; }
        private ChessBoard ChessBoard { get; set; }

        public Piece(ChessBoard chessBoard, Turn playerTurn)
        {
            Position = null;
            ChessBoard = chessBoard;
            PlayerTurn = playerTurn;
            MovementsQuantity = 0;
        }

        public void Draw()
        {
        }

        public void IncreaseMovementQuantity()
        {
            MovementsQuantity++;
        }

        public void DecreaseMovementQuantity()
        {
            MovementsQuantity--;
        }

        /// <summary>
        /// Verifies if theres movements available.
        /// </summary>
        /// <returns></returns>
        public bool TheresMovementAvailable()
        {
            bool[,] matrix = PossibleMovements();
            for (int i = 0; i < ChessBoard.BoardSize.X; i++)
            {
                for (int j = 0; j < ChessBoard.BoardSize.Y; j++)
                {
                    if (matrix[i, j]) { return true; }
                }
            }
            return false;
        }

        public bool PossibleMove(Vector2 pos)
        {
            return PossibleMovements()[(int)pos.X, (int)pos.Y];
        }

        public abstract bool[,] PossibleMovements();
    }
}
