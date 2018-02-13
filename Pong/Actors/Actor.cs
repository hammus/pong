using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Actors
{
    public interface IActor
    {
        void LoadContent(Texture2D texture, bool originCenter);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void Initialize();
    }

    public enum VerticalLocation { Top, Bottom }
    public enum HorizontalLocation { Left, Right }

    public class Actor: IActor
    {

        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Origin = Vector2.Zero;
        public Color SpriteColor = Color.White;
        public SpriteEffects Effects = SpriteEffects.None;
        public Rectangle? SourceRect = null;
        public float Rotation = 0f;
        public float LayerDepth = 0f;
        public ActorTag ActorTag;
        
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

        public Rectangle DestinationRect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        protected GraphicsDeviceManager _graphics;
       

        public Actor(GraphicsDeviceManager graphics, ActorTag actorTag)
        {
            _graphics = graphics;
            ActorTag = actorTag;
            ActorManager.RegisterActor(this);
        }

        public virtual void Initialize() { }

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
                    DestinationRect,
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
};