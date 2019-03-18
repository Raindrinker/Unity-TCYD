using DefaultNamespace;
using Model;
using Units.UnitLibrary;
using UnityEngine;

namespace Cards
{
    public class CardStep : CardInfo
    {

        public CardStep()
        {
            cardName = "Step";
            imageName = "step";

            useOnTile = true;
        }
        
        public override bool isTileValid(Map map, UnitController hero, Tile t)
        {
            if (!t.isWalkable())
            {
                return false;
            }

            Position heroPos = hero.getPosition();
            Position tilePos = t.getPos();
            
            return Position.Distance(heroPos, tilePos) == 1;
           
        }
        
        protected override void effect(GameObject card, DeckManager deckManager, Map map, UnitController hero, Tile t)
        {
            Vector2 tilePos = map.getPosFromWorldPosition(t.transform.position);
            
            map.moveUnitToTile(hero, new Position((int)tilePos.x, (int)tilePos.y));
            
            map.takeUnitsTurn();
            
            card.GetComponent<Card>().discard();
        }

    }
}