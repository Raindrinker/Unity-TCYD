using System.Collections.Generic;
using Model;
using UnityEngine.Analytics;

namespace DefaultNamespace
{
    public static class Data
    {
        public static int level = 1;
    }
    
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
            hero = new UnitModel(10, new Position(2, 2), UnitModel.UnitType.Hero, "Hero");
            

            switch (Data.level)
            {
                case 1:
                    units.Add(new UnitModel(4, new Position(4, 4), UnitModel.UnitType.Slime, "Slime"));
                    break;
                case 2:
                    units.Add(new UnitModel(4, new Position(0, 0), UnitModel.UnitType.Slime, "Slime"));
                    units.Add(new UnitModel(4, new Position(4, 0), UnitModel.UnitType.Slime, "Slime"));
                    units.Add(new UnitModel(4, new Position(0, 0), UnitModel.UnitType.Slime, "Slime"));
                    units.Add(new UnitModel(4, new Position(4, 4), UnitModel.UnitType.Slime, "Slime"));
                    break;
                case 3:
                    units.Add(new UnitModel(1, new Position(0, 0), UnitModel.UnitType.Slime, "Slime"));
                    units.Add(new UnitModel(3, new Position(4, 4), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));
                    units.Add(new UnitModel(3, new Position(4, 3), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));
                    units.Add(new UnitModel(3, new Position(3, 4), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));
                    break;
                case 4:
                    units.Add(new UnitModel(5, new Position(1, 1), UnitModel.UnitType.QueenHeart, "Heart"));
                    units.Add(new UnitModel(3, new Position(2, 1), UnitModel.UnitType.CardiacMonarch, "Queen"));
                    units.Add(new UnitModel(5, new Position(3, 1), UnitModel.UnitType.QueenHeart, "Heart"));
                    break;
            }

            Data.level++;

            if (Data.level > 4)
            {
                Data.level = 1;
            }
            
            
            
            
            /*units.Add(new UnitModel(5, new Position(1, 1), UnitModel.UnitType.QueenHeart, "Heart"));
            units.Add(new UnitModel(3, new Position(2, 1), UnitModel.UnitType.CardiacMonarch, "Queen"));
            units.Add(new UnitModel(5, new Position(3, 1), UnitModel.UnitType.QueenHeart, "Heart"));*/
            
            //units.Add(new UnitModel(1, new Position(2, 3), UnitModel.UnitType.Slime, "Slime"));
            //units.Add(new UnitModel(4, new Position(4, 0), UnitModel.UnitType.Slime, "Slime"));
            //units.Add(new UnitModel(4, new Position(0, 0), UnitModel.UnitType.Slime, "Slime"));
            //units.Add(new UnitModel(4, new Position(4, 4), UnitModel.UnitType.Slime, "Slime"));
            
            /*units.Add(new UnitModel(3, new Position(4, 4), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));
            units.Add(new UnitModel(3, new Position(4, 3), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));
            units.Add(new UnitModel(3, new Position(3, 4), UnitModel.UnitType.Diamondcrystal, "DiamondCrystal"));*/
            
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