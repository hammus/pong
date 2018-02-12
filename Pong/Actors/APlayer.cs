using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Actors
{
    public class APlayer : Actor
    {
        public APlayer(GraphicsDeviceManager graphics, Vector2 startingPosition) : base(graphics)
        {
            //Set Starting Position
            Position = startingPosition;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
