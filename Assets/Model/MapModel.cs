using Boo.Lang;

namespace DefaultNamespace
{
    public class MapModel
    {
        private int[,] tiles = new int[5,5];
        private List<UnitModel> units = new List<UnitModel>();

        public MapModel()
        {
            units.Add(new UnitModel(2, new Position(3, 3), UnitModel.UnitType.Diamondcrystal));
            units.Add(new UnitModel(2, new Position(3, 4), UnitModel.UnitType.Diamondcrystal));
            units.Add(new UnitModel(2, new Position(4, 3), UnitModel.UnitType.Diamondcrystal));
            
            units.Add(new UnitModel(4, new Position(4, 0), UnitModel.UnitType.Slime));
        }

        public List<UnitModel> GetUnits()
        {
            return units;
        }
    }
}