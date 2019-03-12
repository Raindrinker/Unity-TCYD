using UnityEngine;

namespace DefaultNamespace
{
    public struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position(Vector2 v)
        {
            x = (int) v.x;
            y = (int) v.y;
        }
    }
}