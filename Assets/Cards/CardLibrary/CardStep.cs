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
        
        public override bool isTileValid(Map map, Hero hero, Tile t)
        {
            if (!t.isWalkable())
            {
                return false;
            }
            
            Vector2 heroPos = map.getHeroPos();
            Vector2 tilePos = map.getPosFromWorldPosition(t.transform.position);
            
            return Vector2.Distance(heroPos, tilePos) == 1;
           
        }
        
        protected override void effect(GameObject card, DeckManager deckManager, Map map, Hero hero, Tile t)
        {
            map.moveUnitToTile(hero, t);

            card.GetComponent<Card>().discard();
            
            map.takeUnitsTurn();
        }

    }
}