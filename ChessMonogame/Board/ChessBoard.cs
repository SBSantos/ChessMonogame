using System;
using ChessMonogame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Board
{
    class ChessBoard : IDraw
    {
        private Point _boardSize = new(8, 8);
        private Point _tileSize;
        private Tile[,] _tiles;
        private Texture2D[] _textures =
        {
            Globals.Content.Load<Texture2D>("BoardSquares/ChessBlackColor"),
            Globals.Content.Load<Texture2D>("BoardSquares/ChessWhiteColor")
        };
        private Pixel[] _background = new Pixel[2];

        public ChessBoard()
        {
            _tiles = new Tile[_boardSize.X, _boardSize.Y];
            
            _tileSize.X = _textures[0].Width;
            _tileSize.Y = _textures[0].Height;

            _background[0] = new(new Rectangle(15, 15, 130, 130));
            _background[1] = new(new Rectangle(0, 0, 160, 160));

            TileToBoard();
        }

        public void TileToBoard()
        {
            int index = 1;
            for (int x = 0; x < _boardSize.X; x++)
            {
                for (int y = 0; y < _boardSize.Y; y++)
                {
                    _tiles[x, y] = new(_textures[index], Map(x, y));
                    if (index == 0) { index++; }
                    else if (index == 1) { index--; }
                }
                if (index == 0) { index++; }
                else if (index == 1) { index--; }
            }
        }

        private Vector2 Map(int x, int y)
        {
            var screenX = x * _tileSize.X + 16;
            var screenY = y * _tileSize.Y + 16;
            return new Vector2(screenX, screenY);
        }

        public void Draw()
        {
            for (int x = 0; x < _boardSize.X; x++)
            {
                for (int y = 0; y < _boardSize.Y; y++)
                {
                    _tiles[x, y].Draw();
                }
            }
            _background[0].Draw(Color.Beige, 0f);
            _background[1].Draw(new Color(21, 21, 21), 0f);
        }
    }
}
