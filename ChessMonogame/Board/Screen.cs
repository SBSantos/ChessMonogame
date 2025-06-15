using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Board
{
    class Screen
    {
        public static void TileToBoard(ChessBoard board) // Add the textures to the 8x8 board. It starts at 1 (white squares) and changes the textures when 1 or 0 is true
        {
            int index = 1;
            for (int x = 0; x < board.BoardSize.X; x++)
            {
                for (int y = 0; y < board.BoardSize.Y; y++)
                {
                    board.Tiles[x, y] = new(board.Textures[index], Map(x, y, 16, board));
                    if (index == 0) { index++; }
                    else if (index == 1) { index--; }
                }
                if (index == 0) { index++; }
                else if (index == 1) { index--; }
            }
        }

        private static Vector2 Map(int x, int y, int offset, ChessBoard board)
        {
            var screenX = x * board.TileSize.X + offset;
            var screenY = y * board.TileSize.Y + offset;
            return new Vector2(screenX, screenY);
        }

        public static void DrawFont(ChessBoard board) // Draws the numbers and letters to the board
        {
            board.Numbers = '1';
            board.Chars = 'a';

            // Columns
            for (int i = board.BoardSize.Y; i > 0; i--)
            {
                Globals.SpriteBatch.DrawString(board.Font, board.Numbers.ToString(), Map(0, i, 0, board), Color.White, 0f, new Vector2(-16 * 2.5f, -16 * 2), 0.25f, SpriteEffects.None, 0.1f);
                board.Numbers++;
            }
            // Rows
            int yPos = board.BoardSize.Y;
            for (int i = 0; i < board.BoardSize.X; i++)
            {
                Globals.SpriteBatch.DrawString(board.Font, board.Chars.ToString(), Map(i, yPos, 0, board), Color.White, 0f, new Vector2(-16 / 0.25f, -16 * (yPos / 2)), 0.25f, SpriteEffects.None, 0.1f);
                board.Chars++;
            }
        }

        public static void ReadMove() // Reads what the user writes to move a piece
        {

        }
    }
}
