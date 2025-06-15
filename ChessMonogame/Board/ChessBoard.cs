using System;
using ChessMonogame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Board
{
    class ChessBoard : IDraw
    {
        public Point BoardSize = new(8, 8);
        public Point TileSize;
        public Tile[,] Tiles { get; set; }
        public Texture2D[] Textures =
        {
            Globals.Content.Load<Texture2D>("BoardSquares/ChessBlackColor"),
            Globals.Content.Load<Texture2D>("BoardSquares/ChessWhiteColor")
        };
        public Pixel[] Background = new Pixel[2];
        public SpriteFont Font = Globals.Content.Load<SpriteFont>("Font/GameFont");
        public char Numbers { get; set; }
        public char Chars { get; set; }
        private Piece[,] _pieces;

        public ChessBoard()
        {
            Tiles = new Tile[BoardSize.X, BoardSize.Y];
            
            TileSize.X = Textures[0].Width;
            TileSize.Y = Textures[0].Height;

            Background[0] = new(new Rectangle(15, 15, 130, 130));
            Background[1] = new(new Rectangle(0, 0, 160, 160));

            Screen.TileToBoard(this);

            _pieces = new Piece[BoardSize.X, BoardSize.Y];
        }

        public void Draw()
        {
            for (int x = 0; x < BoardSize.X; x++)
            {
                for (int y = 0; y < BoardSize.Y; y++)
                {
                    Tiles[x, y].Draw();
                }
            }
            Background[0].Draw(Color.Beige, 0.1f); // The thin line that surrounds the chess board
            Background[1].Draw(new Color(21, 21, 21), 0f); // The last layer of the chess board
            Screen.DrawFont(this);
        }

        public Piece Piece(int row, int column)
        {
            return _pieces[row, column];
        }

        public Piece Piece(Vector2 pos)
        {
            return _pieces[(int)pos.X, (int)pos.Y];
        }

        public void PlacePiece(Piece p, Vector2 pos)
        {
            _pieces[(int)pos.X, (int)pos.Y] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Vector2 pos)
        {
            if (pos.X < 0 || pos.X >= BoardSize.X || pos.Y < 0 || pos.Y >= BoardSize.Y) { return false; }
            return true;
        }
    }
}
