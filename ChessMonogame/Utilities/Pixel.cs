using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Utilities
{
    class Pixel
    {
        private Rectangle _rect;
        private Texture2D _texture;

        public Pixel(Rectangle rect)
        {
            _rect = rect;
        }

        public void Draw(Color color, float layer)
        {
            _texture = new(Globals.GraphicsDevice, 1, 1);
            _texture.SetData([Color.White]);
            Globals.SpriteBatch.Draw(_texture, _rect, null, color, 0f, Vector2.Zero, SpriteEffects.None, layer);
        }
    }
}
