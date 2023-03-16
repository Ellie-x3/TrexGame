using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics {
    public class Sprite {
        public Texture2D SpriteTexture { get; private set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Color Color { get; set; } = Color.White;

        public Sprite(Texture2D texture, int x, int y, int width, int height) {
            SpriteTexture = texture;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position) {
            spriteBatch.Draw(SpriteTexture, position, new Rectangle(X, Y, Width, Height), Color);
        }
    }
}
