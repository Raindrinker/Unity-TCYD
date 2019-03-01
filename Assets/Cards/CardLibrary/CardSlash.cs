using UnityEngine;

namespace Cards
{
    public class CardSlash : CardInfo
    {

        public CardSlash()
        {
            cardName = "Slash";
            imageName = "slash";

            useOnTile = true;
        }
        
        public override bool isTileValid(Map map, Unit hero, Tile t)
        {
            Vector2 heroPos = map.getHeroPos();
            Vector2 tilePos = map.getPosFromWorldPosition(t.transform.position);
            
            Debug.Log("TILE POS: " + tilePos.x + ", " + tilePos.y);
            
            return Vector2.Distance(heroPos, tilePos) == 1;
        }
        
        protected override void effect(GameObject card, DeckManager deckManager, Map map, Unit hero, Tile t)
        {
            if (t.getUnit() != null)
            {
                t.getUnit().destroy();
            }

            card.GetComponent<Card>().discard();
        }
    }
}