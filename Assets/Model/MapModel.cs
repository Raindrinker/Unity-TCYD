using System.Collections.Generic;
using Model;

namespace DefaultNamespace
{
    public class MapModel
    {
        private TileModel[,] tiles = new TileModel[5,5];
        private List<UnitModel> units = new List<UnitModel>();

        private UnitModel hero;

        public MapModel()
        {
            for(var i = 0; i < tiles.GetLength(0); i++)
            {
                for(var j = 0; j < tiles.GetLength(1); j++)
                {
                    var tileModel = new TileModel(new Position(i, j));
                    tiles[i, j] = tileModel;
                }
            }
            
            
            hero = new UnitModel(3, new Position(0, 2), UnitModel.UnitType.Hero, "Hero");
            
            units.Add(new UnitModel(4, new Position(3, 2), UnitModel.UnitType.Slime, "Slime"));
            
            units.Add(new UnitModel(3, new Position(4, 4), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));
            units.Add(new UnitModel(3, new Position(4, 3), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));
            units.Add(new UnitModel(3, new Position(3, 4), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));
            
        }

        public List<UnitModel> GetUnits()
        {
            return units;
        }

        public UnitModel GetHero()
        {
            return hero;
        }

        public TileModel GetTile(int x, int y)
        {
            return tiles[x, y];
        }
    }
}