using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Utilities
{
    public static class Vector2Extension
    {
        public static Vector2 Clone(this Vector2 sourceVec)
        {
            return new Vector2(sourceVec.X, sourceVec.Y);
        }
    }
}
