using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool canPlayCards()
    {
        return !uiManager.isShowingUI();
    }
}
