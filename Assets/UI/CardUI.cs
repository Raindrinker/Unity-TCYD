using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CardUI : MonoBehaviour
    {

        private UIManager uiManager;
        
        private CardInfo cardInfo;

        public void Start()
        {
            uiManager = GameObject.Find("UI").GetComponent<UIManager>();
        }

        public void setCardInfo(CardInfo ci)
        {
            cardInfo = ci;
            GetComponent<Image>().sprite = cardInfo.getImage();
        }
    }
}
