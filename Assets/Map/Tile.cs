using DefaultNamespace;
using Model;
using Units.UnitLibrary;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Map map;
    
    private bool active;

    private TileModel tileModel;
    
    private UnitController unit = null;
    
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map").GetComponent<Map>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setModel(TileModel tileModel)
    {
        this.tileModel = tileModel;
    }

    public Position getPos()
    {
        return tileModel.pos;
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

    public void setUnit(UnitController unit)
    {
        this.unit = unit;
    }

    public UnitController getUnit()
    {
        return unit;
    }
}
