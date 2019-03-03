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
        
        public override bool isTileValid(Map map, Hero hero, Tile t)
        {
            Vector2 heroPos = map.getHeroPos();
            Vector2 tilePos = map.getPosFromWorldPosition(t.transform.position);
            
            Debug.Log("TILE POS: " + tilePos.x + ", " + tilePos.y);
            
            return Vector2.Distance(heroPos, tilePos) == 1;
        }
        
        protected override void effect(GameObject card, DeckManager deckManager, Map map, Hero hero, Tile t)
        {
            var slash = GameObject.Instantiate(hero.slashPrefab, t.transform);
            slash.transform.position = t.transform.position;
            
            if (t.getUnit() != null)
            {
                t.getUnit().takeDamage(1);
            }

            card.GetComponent<Card>().discard();
            
            map.takeUnitsTurn();
        }
    }
}