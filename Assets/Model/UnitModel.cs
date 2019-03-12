namespace DefaultNamespace
{
    public class UnitModel
    {
        public enum UnitType
        {
            Hero,
            Pot,
            Slime,
            Diamondcrystal
        }
        
        public int maxhp;
        public int hp;
        public Position pos;
        public UnitType type;

        public UnitModel(int maxhp, Position pos, UnitType type)
        {
            this.maxhp = maxhp;
            this.hp = maxhp;
            this.pos = pos;
            this.type = type;
        }
    }
}