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
        
        public static Position operator +(Position p1, Position p2) 
        {
            return new Position(p1.x + p2.x, p1.y + p2.y);
        }
        
        public static Position operator -(Position p1, Position p2) 
        {
            return new Position(p1.x - p2.x, p1.y - p2.y);
        }
        
        public static Position operator *(Position p1, int i) 
        {
            return new Position(p1.x * i, p1.y * i);
        }
    }
}