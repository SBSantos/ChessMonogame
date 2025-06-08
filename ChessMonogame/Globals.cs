using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame
{
    public static class Globals
    {
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }
        public static Point WindowsSize { get; set; }
        public static float Time { get; private set; }
        public static Texture2D Texture { get; set; }
        public static GraphicsDeviceManager Graphics { get; set; }

        public static void Update(GameTime gameTime)
        {
            Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public static void Resolution()
        {
            WindowsSize = new(640, 480);
            Graphics.PreferredBackBufferWidth = WindowsSize.X;
            Graphics.PreferredBackBufferHeight = WindowsSize.Y;
            Graphics.ApplyChanges();
        }
    }
}
