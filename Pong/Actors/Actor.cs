using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Actors
{
    public class Actor
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Origin = Vector2.Zero;
        public Color SpriteColor = Color.White;
        public SpriteEffects Effects = SpriteEffects.None;
        public Rectangle? SourceRect = null;
        public float Rotation = 0f;
        public float LayerDepth = 0f;

        public int Width
        {
            get
            {
                return Texture.Width;
            }
        }

        public int Height
        {
            get
            {
                return Texture.Height;
            }
        }

        protected GraphicsDeviceManager _graphics;
        protected Rectangle _destinationRect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        public Actor(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }

        public virtual void LoadContent(Texture2D texture, bool originCenter = true)
        {
            Texture = texture;
            Origin = (originCenter) ? new Vector2(Texture.Width / 2, Texture.Height / 2) : Vector2.Zero;

        }
        //new Rectangle(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2, Texture.Width, Texture.Height),

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                    Texture,
                    _destinationRect,
                    SourceRect, //source rect
                    SpriteColor,
                    Rotation, // rotation
                    Origin, //origin
                    Effects,
                    LayerDepth //layer depth
                );
        }

        public virtual void Update(GameTime gameTime) { }
    }
}
;