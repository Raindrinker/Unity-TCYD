using DefaultNamespace;
using Model;
using Units.UnitLibrary;
using UnityEngine;

namespace Cards
{
    public class CardQuickstep : CardInfo
    {

        public CardQuickstep()
        {
            cardName = "Quickstep";
            imageName = "quickstep";

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

            card.GetComponent<Card>().discard();
        }

    }
}