using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Utilities;

namespace Pong.Actors
{
    public class APlayer : Actor, IActor
    {
        public bool IsPlayerControlled = true;
        public PlayerIndex ControllerIndex;
        public float Speed = 400.0f;
        public float CollisionBoundaryY;


        public APlayer(GraphicsDeviceManager graphics, ActorTag actorType, PlayerIndex controllerIndex, Vector2 startingPosition) : base(graphics, actorType)
        {
            //Set Starting Position
            Position = startingPosition;
            ControllerIndex = controllerIndex;
            ActorTag = actorType;
            
        }


        public override void LoadContent(Texture2D texture, bool originCenter = true)
        {
            base.LoadContent(texture, originCenter);
            CollisionBoundaryY = (ActorTag == ActorTag.Player1) ? Position.Y - (Texture.Height) : Position.Y + (Texture.Height);
        }

        public override void Update(GameTime gameTime)
        { 

            //TODO(liam): Change this. This will make ALL players >2 use Keyboard as input.
            Vector2 finalPosition = (ControllerIndex == PlayerIndex.One) ? UpdatePad(gameTime) : UpdateKeyboard(gameTime);
            finalPosition = ApplyBounds(finalPosition);

            Position = finalPosition;

            base.Update(gameTime);
        }

        private Vector2 UpdateKeyboard(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 finalPosition = Position.Clone();

            KeyboardState keyState = Keyboard.GetState();
            if(keyState.IsKeyDown(Keys.A))
            {
                finalPosition.X = Position.X - Speed * deltaTime;
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                finalPosition.X = Position.X + Speed * deltaTime;
            }

            return finalPosition;


        }

        private Vector2 UpdatePad(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 finalPosition = Position.Clone();
            GamePadState padState = GamePad.GetState(ControllerIndex);
           
            if (padState.IsConnected)
            {
                finalPosition.X = Position.X + padState.ThumbSticks.Left.X * Speed * deltaTime;
            }

            return finalPosition;
        }

        private Vector2 ApplyBounds(Vector2 finalPosition)
        {
            if(finalPosition.X <= (Width/2))
            {
                finalPosition.X = Width / 2;
            }

            if (finalPosition.X >= _graphics.PreferredBackBufferWidth - (Width / 2))
            {
                finalPosition.X = _graphics.PreferredBackBufferWidth - (Width / 2);
            }

            return finalPosition;

        }
    }
}
