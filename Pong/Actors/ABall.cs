using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Utilities;

namespace Pong.Actors
{
    public class ABall : Actor, IActor
    {

        
        public float Speed = 300f;
        public Vector2 Direction = Vector2.One / 2;
        public VerticalLocation VerticalLocation;

        private Vector2 _startingPosition;

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

        public void Reset()
        {
            Position = _startingPosition.Clone();
            Direction = Vector2Extension.RandomUnitVector();
        }

        public ABall(GraphicsDeviceManager graphics, ActorTag actorType) : base(graphics, actorType)
        {
            //Set Starting Position
            _startingPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            Position = _startingPosition.Clone();
        }

        public override void Update(GameTime gameTime)
        {
            if (!StateManager.Playing) return;

            UpdateLocation();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            CheckCollision(deltaTime);

            Direction.Normalize();
            Position += Direction * Speed * deltaTime;

            base.Update(gameTime);
        }

        public void UpdateLocation()
        {
            int halfScreenWidth = (_graphics.PreferredBackBufferWidth / 2);
            int halfScreenHeight = (_graphics.PreferredBackBufferHeight / 2);

            if (Position.Y > halfScreenHeight)
            {
                VerticalLocation = VerticalLocation.Bottom;
            } else
            {
                VerticalLocation = VerticalLocation.Top;
            }
        }

        private void CheckCollision(float deltaTime)
        {
            Vector2 nextPosition = Position + (Direction * Speed * deltaTime);

            if (nextPosition.X >= MaxX || nextPosition.X <= MinX)
            {
                Direction.X *= -1f;
            }
            APlayer player = (APlayer)ActorManager.CheckCollision(this);
            if (player != null)
            {
                Direction.Y *= -1f;
                if (VerticalLocation == VerticalLocation.Bottom)
                {
                    //Move outside Collision Boundary 
                    Position.Y = player.CollisionBoundaryY - 1;
                } else if (VerticalLocation == VerticalLocation.Top)
                {
                    //Move outside Collision Boundary 
                    Position.Y = player.CollisionBoundaryY + 1;
                }
            }
            if (nextPosition.Y >= _graphics.PreferredBackBufferHeight)
            {
                StateManager.GoalP2();
                Reset();
            } else if (nextPosition.Y <= 0)
            {
                StateManager.GoalP1();
                Reset();
            }
        }
    }
}
