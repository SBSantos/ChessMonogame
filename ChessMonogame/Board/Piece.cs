using System;
using System.Runtime.CompilerServices;
using ChessMonogame.Manager;
using ChessMonogame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Board
{
    class Piece : Sprite, IUpdate
    {
        public Turn PlayerTurn { get; protected set; }
        private int MovementsQuantity { get; set; }
        private ChessBoard ChessBoard { get; set; }
        private bool PieceClicked { get; set; }

        public Piece(Texture2D texture, Vector2 position, Turn playerTurn) : base(texture, position)
        {
            PlayerTurn = playerTurn;
            MovementsQuantity = 0;
        }

        public override void Draw()
        {
        }

        public void Update()
        {
            if (Rectangle.Contains(InputManager.MouseRectangle))
            {
                if (InputManager.Clicked) { Color = Color.Green; }
            }

            Color = PieceClicked ? Color.Green : Color; // A piece clicked will change it's color.
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

        public virtual bool[,] PossibleMovements()
        {
            return PossibleMovements();
        }
    }
}
