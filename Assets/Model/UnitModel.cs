using System;
using Model;

namespace DefaultNamespace
{
    public class UnitModel
    {
        public enum UnitType
        {
            Hero,
            Pot,
            Slime,
            Diamondcrystal,
            Chaser,
            QueenHeart,
            CardiacMonarch
        }

        public bool alive = true;
        public int maxhp;
        public int hp;
        public Position pos;
        public UnitType type;
        public String name;

        public int state;

        public UnitModel(int maxhp, Position pos, UnitType type, String name)
        {
            this.maxhp = maxhp;
            this.hp = maxhp;
            this.pos = pos;
            this.type = type;
            this.name = name;
            this.state = 0;
        }
    }
}