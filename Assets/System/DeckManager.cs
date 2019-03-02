using System.Collections.Generic;
using Cards;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    System.Random rand = new System.Random();
    
    List<CardInfo> deck = new List<CardInfo>();
    List<CardInfo> drawPile = new List<CardInfo>();
    List<CardInfo> discardPile = new List<CardInfo>();

    public GameObject cardGO;
    
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 4; i++)
        {
            deck.Add(new CardStep());
        }
        deck.Add(new CardSlash());
        deck.Add(new CardSlash());
        deck.Add(new CardQuickstep());
        
        foreach (var card in deck)
        {
            drawPile.Add(card);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<CardInfo> getDeck()
    {
        return deck;
    }
    
    public List<CardInfo> getDrawPile()
    {
        return drawPile;
    }

    public Card DrawCard()
    {
        if (drawPile.Count == 0)
        {
            reshuffle();
        }
        
        int choice = rand.Next(drawPile.Count);

        GameObject newCardObj = Instantiate(cardGO);
        Card newCard = newCardObj.GetComponent<Card>();

        newCard.transform.parent = GameObject.Find("Hand").transform;

        Vector3 worldPoint = GameObject.Find("DeckButton").GetComponent<RectTransform>().position;
        newCard.transform.position = worldPoint;
        
        newCard.GetComponent<Card>().setCardInfo(drawPile[choice]);
        
        drawPile.RemoveAt(choice);
        
        if (drawPile.Count == 0)
        {
            reshuffle();
        }

        return newCard;
    }

    public void discardCard(Card card)
    {
        discardPile.Add(card.getCardInfo());
    }

    public void reshuffle()
    {
        drawPile.Clear();
        foreach (var card in discardPile)
        {
            drawPile.Add(card);
        }
        discardPile.Clear();
        
        Debug.Log("RESHUFFLE");
    }
}
