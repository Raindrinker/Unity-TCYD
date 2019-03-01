using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private Map map;
    
    private bool active;
    
    private Unit unit = null;
    
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map").GetComponent<Map>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWorldPosition(Vector3 worldPos)
    {
        transform.localPosition = worldPos;
    }

    public void SetActive(bool active)
    {
        this.active = active;
        if (active)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public bool isWalkable()
    {
        return unit == null;
    }

    public void setUnit(Unit unit)
    {
        this.unit = unit;
    }

    public Unit getUnit()
    {
        return unit;
    }
}
