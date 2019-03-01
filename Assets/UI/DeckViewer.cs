using System.Collections;
using System.Collections.Generic;
using Cards;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class DeckViewer : MonoBehaviour
{

    public GameObject cardUiPrefab;

    private DeckManager deckManager;

    private GameObject cardGrid;
    
    
    private float talpha = 1;
    private float alpha = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
        cardGrid = GameObject.Find("CardGrid");
    }

    // Update is called once per frame
    private void Update()
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
        talpha = visible ? 1 : 0;
    }

    public void Populate()
    {
        GameObject newObj;

        List<CardInfo> deck = deckManager.getDeck();
        
        foreach (Transform child in cardGrid.transform) {
            Destroy(child.gameObject);
        }
        
        for (var i = 0; i < deck.Count; i++)
        {
            newObj = Instantiate(cardUiPrefab, transform);
            newObj.GetComponent<CardUI>().setCardInfo(deck[i]);
            newObj.transform.SetParent(cardGrid.transform);
        }
    }
}
