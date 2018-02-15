using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Actors
{
    public enum ActorTag { Player1, Player2, Ball }
    public static class ActorManager
    {
        public static List<Actor> Actors = new List<Actor>();

        public static APlayer GetPlayer(ActorTag actorTag)
        {
            return (APlayer)Actors.Find(x => x.ActorTag == actorTag);

        }

        public static void RegisterActor(Actor actor)
        {
            Actors.Add(actor);
        }


        public static Actor CheckCollision(ABall ball)
        {
            APlayer player;
            switch (ball.VerticalLocation)
            {
                case VerticalLocation.Bottom:
                    player = GetPlayer(ActorTag.Player1);
                    return AABBCollision(ball, player);
                case VerticalLocation.Top:
                    player = GetPlayer(ActorTag.Player2);
                    return AABBCollision(ball, player);
                default:
                    return null;
            }
        }

        private static APlayer AABBCollision(ABall ball, APlayer player)
        {
            Rectangle rect1 = ball.DestinationRect;
            Rectangle rect2 = player.DestinationRect;

            return (
                rect1.X < rect2.X + rect2.Width &&
                rect1.X + rect1.Width > rect2.X &&
                rect1.Y < rect2.Y + rect2.Height &&
                rect1.Height + rect1.Y > rect2.Y
            ) ? player : null;

        }



    }
}
