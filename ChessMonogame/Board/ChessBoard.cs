using System;
using System.Collections.Generic;
using ChessMonogame.Pieces;
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
        public Texture2D Texture = Globals.Content.Load<Texture2D>("BoardSquares/ChessWhiteColor");
        public Pixel[] Background = new Pixel[2];
        public SpriteFont Font = Globals.Content.Load<SpriteFont>("Font/GameFont");
        public char Numbers { get; set; }
        public char Chars { get; set; }
        public Piece[,] Pieces { get; set; }
        private readonly Color[] color = [Color.Beige, new Color(21, 21, 21)];

        public ChessBoard()
        {
            Tiles = new Tile[BoardSize.X, BoardSize.Y];
            Pieces = new Piece[BoardSize.X, BoardSize.Y];

            TileSize.X = Texture.Width;
            TileSize.Y = Texture.Height;

            Background[0] = new(new Rectangle(15, 15, 130, 130));
            Background[1] = new(new Rectangle(0, 0, 160, 160));

            TileToBoard();
            PieceToBoard();
        }

        public void Draw()
        {
            DrawTiles();
            Background[0].Draw(Color.Beige, 0.1f); // The thin line that surrounds the chess board
            Background[1].Draw(new Color(21, 21, 21), 0f); // The last layer of the chess board
            DrawFont();
            PlaceNewPieces();
        }

        public void TileToBoard()
        {
            for (int x = 0; x < BoardSize.X; x++)
            {
                for (int y = 0; y < BoardSize.Y; y++)
                {
                    Tiles[x, y] = new(Texture, Map(x, y, 16));
                }
            }
        }

        public void DrawTiles()
        {
            int colIndex = 0; // Changes the color of the squares
            for (int x = 0; x < BoardSize.X; x++)
            {
                for (int y = 0; y < BoardSize.Y; y++)
                {
                    Tiles[x, y].Draw(color[colIndex], 0.2f);
                    if (colIndex == 0) { colIndex++; }
                    else if (colIndex == 1) { colIndex--; }
                }
                if (colIndex == 0) { colIndex++; }
                else if (colIndex == 1) { colIndex--; }
            }
        }

        public void PieceToBoard()
        {
            // White pieces
            for (int i = 0; i < BoardSize.X; i++)
            {
                for (int j = 0; j < BoardSize.Y; j++)
                {
                    Pieces[i, j] = new(Texture, Map(i, j, 16), Turn.PlayerOne);
                }
            }
        }

        private Vector2 Map(int x, int y, int offset)
        {
            var screenX = x * TileSize.X + offset;
            var screenY = y * TileSize.Y + offset;
            return new Vector2(screenX, screenY);
        }

        public void DrawFont() // Draws the numbers and letters to the board
        {
            Numbers = '1';
            Chars = 'a';

            // Columns
            for (int i = BoardSize.Y; i > 0; i--)
            {
                Globals.SpriteBatch.DrawString(Font, Numbers.ToString(), Map(0, i, 0), color[0], 0f, new Vector2(-16 * 2.5f, -16 * 2), 0.25f, SpriteEffects.None, 0.1f);
                Numbers++;
            }
            // Rows
            int yPos = BoardSize.Y;
            for (int i = 0; i < BoardSize.X; i++)
            {
                Globals.SpriteBatch.DrawString(Font, Chars.ToString(), Map(i, yPos, 0), color[0], 0f, new Vector2(-16 / 0.25f, -16 * (yPos / 2)), 0.25f, SpriteEffects.None, 0.1f);
                Chars++;
            }
        }

        public void PlacePiece(Piece p)
        {
            for (int i = 0; i < BoardSize.X; i++)
            {
                for (int j = 0; j < BoardSize.Y; j++)
                {
                    if (ValidPosition(new Vector2(i, j))) { p.Draw(); }
                }
            }
        }

        public bool ValidPosition(Vector2 pos)
        {
            if (pos.X < 0 || pos.X >= BoardSize.X || pos.Y < 0 || pos.Y >= BoardSize.Y) { return false; }
            return true;
        }

        public void PlaceNewPieces()
        {
            PlacePiece(new King(Texture, Map(4, 7, 16), Turn.PlayerOne));
        }
    }
}
