using ChessMonogame.Board;
using ChessMonogame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Manager
{
    class GameManager : IUpdate, IDraw
    {
        private ChessBoard _chessBoard = new();
        private Matrix _screenScale;

        public void Draw()
        {
            Globals.SpriteBatch.Begin(SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: _screenScale);
            _chessBoard.Draw();
            Globals.SpriteBatch.End();
        }

        public void Update()
        {
            UpdateScaleScreen();
        }

        private void UpdateScaleScreen()
        {
            _screenScale = Matrix.CreateScale(2.5f);
        }
    }
}
