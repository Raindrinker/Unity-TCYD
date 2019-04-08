using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    private GameObject hpBar;
    private GameObject hpText;
    
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GameObject.Find("hpBar");
        hpText = GameObject.Find("hpText");
    }

    // Update is called once per frame
    public void SetHp(int hp, int maxhp)
    {
        hpBar.transform.localScale = new Vector3(hp / (float)maxhp, 1, 1);
        hpText.GetComponent<Text>().text = hp + "/" + maxhp;
    }
}
