using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Pong.Utilities
{
    public static class Vector2Extension
    {
        public static Random rng = new Random();
        public static Vector2 Clone(this Vector2 sourceVec)
        {
            return new Vector2(sourceVec.X, sourceVec.Y);
        }
        private static List<Vector2> _forbiddenStartingDirections = new List<Vector2> { new Vector2(1f,0f), new Vector2(-1f,0f) };
        private static List<Vector2> _startingDirections = new List<Vector2> { new Vector2(1.5f, 1), new Vector2(-1.5f, -1f), new Vector2(-1.5f, 1f), new Vector2(1.5f, -1f) };
        /// <summary>
        /// Generates a random unit vector (in the -1 to 1 space) 
        /// </summary>
        /// <returns></returns>
        public static Vector2 RandomUnitVector()
        {
            Vector2 result = GetRandomUnitVector();
            if (_forbiddenStartingDirections.Find(v => v == result) != default(Vector2))
            {
                return RandomUnitVector();
            }
            return result;
        }

        private static Vector2 GetRandomUnitVector()
        {
            float x = RandomOrdinateF();
            float y = RandomOrdinateF();
            return new Vector2(x, y);
        }

        public static Vector2 RandomStartingVector()
        {
            return _startingDirections[rng.Next(_startingDirections.Count)];
        }

        /// <summary>
        /// Returns a Random float, used to generate random Ordinate x or y for a Vector2, value between -1 and 1
        /// </summary>
        /// <returns></returns>
        public static float RandomOrdinateF()
        {
            var next = rng.NextDouble();
            float min = -1.5f;
            float max = 1.5f;
            return min + ((float)next * (max - min));
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
