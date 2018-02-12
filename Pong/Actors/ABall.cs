using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Actors
{
    public class ABall : Actor
    {

        public float Speed = 300f;
        public Vector2 Direction = Vector2.One / 2;

        public int MaxX
        {
            get
            {
                return _graphics.PreferredBackBufferWidth - (Width / 2);
            }
        }
        public int MinX
        {
            get
            {
                return (Width / 2);
            }
        }
        public int MaxY
        {
            get
            {
                return _graphics.PreferredBackBufferHeight - (Height / 2);
            }
        }
        public int MinY
        {
            get
            {
                return (Height / 2);
            }
        }

        public ABall(GraphicsDeviceManager graphics) : base(graphics)
        {
            //Set Starting Position
            Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (!StateManager.Playing) return;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            CheckBounds(deltaTime);

            Direction.Normalize();
            Position += Direction * Speed * deltaTime;





            base.Update(gameTime);
        }

        private void CheckBounds(float deltaTime)
        {
            Vector2 nextPosition = Position + (Direction * Speed * deltaTime);

            if (nextPosition.X >= MaxX || nextPosition.X <= MinX)
            {
                Direction.X *= -1f;
            }

            if (nextPosition.Y >= MaxY || nextPosition.Y <= MinY)
            {
                Direction.Y *= -1f;
            }
        }
    }
}
