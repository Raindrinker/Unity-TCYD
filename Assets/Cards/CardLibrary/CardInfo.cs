using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class CardInfo
    {

        protected string cardName;
        protected string imageName;

        protected bool useOnTile;

        public CardInfo()
        {
            cardName = "blank";
            imageName = "blank";
        }

        public Sprite getImage()
        {
            return Resources.Load <Sprite> ("CardSprites/" + imageName);
        }

        public virtual void use(GameObject card, DeckManager deckManager, Map map, Unit hero)
        {
            Tile t;
            if (useOnTile)
            {
                t = map.getTileFromWorldPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (t != null)
                {
                    if (isTileValid(map, hero, t))
                    {
                        effect(card, deckManager, map, hero, t);
                    }
                    else
                    {
                        Debug.Log("INVALID TILE");
                    }
                }
                else
                {
                    Debug.Log("NULL TILE");
                }
            }
            else
            {
                effect(card, deckManager, map, hero,null);
            }
        }

        public virtual bool isTileValid(Map map, Unit hero, Tile t)
        {
            return false;
        }

        protected virtual void effect(GameObject card, DeckManager deckManager, Map map, Unit hero, Tile t)
        {
            Debug.Log("Use " + cardName);
        }
        
    }
}