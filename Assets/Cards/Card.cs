using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using Hand;
using UnityEngine;

public class Card : MonoBehaviour
{
    private GameManager gm;
    private HandManager handManager;
    private DeckManager deckManager;
    private UIManager uiManager;
    private Map map;
    
    private CardInfo cardInfo;
    
    private Vector3 pos = Vector3.zero;
    private int slot;
    
    private bool active = false;

    private Transform cardImg;
    private float imgtx = 0.0f;
    private float imgty = 0.0f;
    private float imgx = 0.0f;
    private float imgy = 0.0f;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        uiManager = GameObject.Find("UI").GetComponent<UIManager>();
        deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
        map = GameObject.Find("Map").GetComponent<Map>();
        handManager = GameObject.Find("Hand").GetComponent<HandManager>();
    }

    public void setCardInfo(CardInfo ci)
    {
        cardInfo = ci;
        
        cardImg = transform.Find("CardImg");
        cardImg.GetComponent<SpriteRenderer>().sprite = cardInfo.getImage();
    }

    public CardInfo getCardInfo()
    {
        return cardInfo;
    }

    public void setCardPosition(Vector3 position)
    {
        pos = position;
    }

    public void setCardSlot(int i)
    {
        slot = i;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 0.3f);
        
        if (Input.GetMouseButtonUp(0))
        {
            if (active)
            {
                cardInfo.use(gameObject, deckManager, map, map.getHero());
                map.clearHighlights();
            }
            
            active = false;
            handManager.setArrowActive(false);
        }

        if (active)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dirdist = new Vector2(mousepos.x - transform.position.x, mousepos.y - transform.position.y);

            imgtx = dirdist.x * 0.01f;
            imgty = dirdist.y * 0.01f + 0.2f;
            
        }
        else
        {
            imgtx = 0;
            imgty = 0;
        }


        imgx = Mathf.Lerp(imgx, imgtx, 0.5f);
        imgy = Mathf.Lerp(imgy, imgty, 0.5f);
        cardImg.transform.localPosition = new Vector2(imgx, imgy);

        timer = Mathf.Min(timer + Time.deltaTime, 10.0f);

        if (active)
        {
            Vector2 arrowStart = new Vector2(cardImg.transform.position.x, cardImg.transform.position.y + 2);
            handManager.setArrow(arrowStart, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

    }

    private void OnMouseDown()
    {
        ActivateCard();
    }

    public void ActivateCard()
    {
        if (gm.canPlayCards())
        {
            map.HighlightValidTiles(cardInfo);

            active = true;
            timer = 0.0f;
            handManager.setArrowActive(true);
        }
    }

    private void OnMouseUp()
    {
        if (timer < 0.2)
        {
            uiManager.ShowCard(cardInfo);
        }
    }

    public void discard()
    {
        handManager.discardCard(slot, this);
        Destroy(gameObject);
        handManager.drawCard();
    }

}
