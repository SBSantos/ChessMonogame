using ChessMonogame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMonogame.Board
{
    class Tile : Sprite
    {
        public Tile(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Position, null, Color.Beige, 0f, Vector2.Zero, 1f,SpriteEffects.None, 0.2f);
        }

        public void Draw(Color color, float layer)
        {
            Globals.SpriteBatch.Draw(Texture, Position, null, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, layer);
        }
    }
}
