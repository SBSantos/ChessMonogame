using ChessMonogame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Board
{
    class Tile : IDraw
    {
        private Texture2D _texture;
        private Vector2 _position;

        public Tile(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, _position, null, Color.Beige, 0f, Vector2.Zero, 1f,SpriteEffects.None, 0.1f);
        }

        public void Draw(Color color, float layer)
        {
            Globals.SpriteBatch.Draw(_texture, _position, null, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, layer);
        }
    }
}
