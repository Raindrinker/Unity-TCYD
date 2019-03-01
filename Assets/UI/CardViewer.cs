using System.Collections;
using System.Collections.Generic;
using Cards;
using UI;
using UnityEngine;

public class CardViewer : MonoBehaviour
{

    private bool visible = false;
    private float talpha = 0;
    private float alpha = 0;

    private CardInfo cardInfo;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasGroup>().alpha = alpha;
        
        if (alpha < talpha) {
            alpha = Mathf.Lerp(alpha, talpha, 0.3f);
        } else {
            alpha = Mathf.Lerp(alpha, talpha, 0.5f);
        }
    }
    
    public void SetVisible(bool visible)
    {
        this.visible = visible;
        talpha = visible ? 1 : 0;
    }

    public void SetCardInfo(CardInfo cardInfo)
    {
        this.cardInfo = cardInfo;
        transform.Find("cardUI").GetComponent<CardUI>().setCardInfo(cardInfo);
    }
}
