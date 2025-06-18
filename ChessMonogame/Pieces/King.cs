using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChessMonogame.Board;

namespace ChessMonogame.Pieces
{
    class King : Piece
    {
        public King(Texture2D texture, Vector2 position, Turn playerTurn) : base(texture, position, playerTurn)
        {
            Texture = Globals.Content.Load<Texture2D>("Pieces/White_King");
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Rectangle, null, Color, 0f, OriginPosition, SpriteEffects.None, 0.2f);
        }

        public override bool[,] PossibleMovements()
        {
            throw new System.NotImplementedException();
        }
    }
}
