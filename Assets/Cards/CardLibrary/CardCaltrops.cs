using DefaultNamespace;
using Model;
using Units.UnitLibrary;
using UnityEngine;

namespace Cards
{
    public class CardCaltrops : CardInfo
    {

        public CardCaltrops()
        {
            cardName = "Caltrops";
            imageName = "caltrops";

            useOnTile = true;
        }
        
        public override bool isTileValid(Map map, UnitController hero, Tile t)
        {
            if (!t.isWalkable())
            {
                return false;
            }

            Position heroPos = hero.getPos();
            Position tilePos = t.getPos();
            
            return Position.Distance(heroPos, tilePos) == 1;
           
        }
        
        protected override void effect(GameObject card, DeckManager deckManager, Map map, UnitController hero, Tile t)
        {
            t.setCaltrops(); 
            GameObject.Find("AudioManager").GetComponent<AudioManager>().playClip("metaldrop");
            
            map.takeUnitsTurn();
            
            card.GetComponent<Card>().discard();
        }

    }
}