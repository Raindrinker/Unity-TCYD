using System;
using UnityEngine;

namespace Model
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

        public static int Distance(Position pos1, Position pos2)
        {
            return Mathf.Abs(pos1.x - pos2.x) + Mathf.Abs(pos1.y - pos2.y);
        }
    }
}