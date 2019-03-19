using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hand
{
    public class HandManager : MonoBehaviour
    {
        
        private bool[] slots = new bool[3];

        private DeckManager deckManager;
        private Arrow arrow;
        
        // Start is called before the first frame update
        void Start()
        {
            deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
            arrow = GameObject.Find("Arrow").GetComponent<Arrow>();
            arrow.setActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            for (var i = 0; i < 3; i++)
            {
                if (!slots[i])
                {
                    drawCard();
                }
            }
        }
        
        public void setArrow(Vector2 start, Vector2 end)
        {
            arrow.setArrow(start, end);
        }

        public void setArrowActive(bool active)
        {
            arrow.setActive(active);
        }

        public void drawCard()
        {
            Card card = deckManager.DrawCard();

            for (var i = 0; i < 3; i++)
            {
                if (!slots[i])
                {
                    slots[i] = true;
                    card.setCardPosition(new Vector2(-4.0f + 4.0f*i, 0));
                    card.setCardSlot(i);
                    
                    Debug.Log("DRAW CARD SLOT " + i);
                    break;
                }
            }
        }

        public void discardCard(int which, Card card)
        {
            deckManager.discardCard(card);
            slots[which] = false;
        }
    }
}
