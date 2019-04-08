using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //private bool showCard = false;
    //private CardViewer cardViewer;
    
    private bool showDeck = false;
    private DeckViewer deckViewer;
    private Button deckButton;

    private BattleUI battleUI;
    
    // Start is called before the first frame update
    void Start()
    {
        //cardViewer = GameObject.Find("CardViewer").GetComponent<CardViewer>();
        //cardViewer.SetVisible(showCard);
        deckViewer = GameObject.Find("DeckViewer").GetComponent<DeckViewer>();
        deckButton = GameObject.Find("DeckButton").GetComponent<Button>();
        deckViewer.SetVisible(showDeck);
        deckButton.onClick.AddListener(OnDeckButtonClick);
        
        battleUI = GameObject.Find("BattleUI").GetComponent<BattleUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showDeck)
            {
                SetShowDeck(false);
            }
            
        }
    }

    public void SetShowDeck(bool show)
    {
        showDeck = show;
        deckViewer.SetVisible(showDeck);
        deckViewer.Populate();
    }
    
    public void ShowCard(CardInfo ci)
    {
        //showCard = true;
        //cardViewer.SetVisible(showCard);
        //cardViewer.SetCardInfo(ci);
    }

    public void HideCard()
    {
        //showCard = false;
        //cardViewer.SetVisible(showCard);
    }

    public void SetHp(int hp, int maxhp)
    {
        battleUI.SetHp(hp, maxhp);
    }

    private void OnDeckButtonClick()
    {
        SetShowDeck(!showDeck);
        GameObject.Find("MusicManager").GetComponent<MusicManager>().setOccluded(showDeck);
    }

    public bool isShowingUI()
    {
        return showDeck;
    }
}
