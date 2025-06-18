using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Utilities
{
    class Sprite : IDraw
    {
        protected Texture2D Texture;
        public Vector2 Position { get; set; }
        public Vector2 OriginPosition { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        public Color Color { get; set; }

        public Sprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            OriginPosition = Vector2.Zero;
            Color = Color.White;
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Rectangle, null, Color, 0f, OriginPosition, SpriteEffects.None, 0f);
        }
    }
}
