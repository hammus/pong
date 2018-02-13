using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Pong.Utilities
{
    public static class Vector2Extension
    {
        public static Vector2 Clone(this Vector2 sourceVec)
        {
            return new Vector2(sourceVec.X, sourceVec.Y);
        }
    }

    public static class EnumerableExtension
    {
        private static Random rng = new Random();

        public static T RandomElement<T>(this IList<T> list)
        {
            return list[rng.Next(list.Count)];
        }

        public static T RandomElement<T>(this T[] array)
        {
            return array[rng.Next(array.Length)];
        }
    }
}
