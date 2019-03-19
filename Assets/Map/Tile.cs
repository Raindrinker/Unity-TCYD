using DefaultNamespace;
using Model;
using Units.UnitLibrary;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Map map;
    
    private bool active;
    private bool highlighted;
    private bool threatened;

    private TileModel tileModel;
    
    private UnitController unit = null;

    private GameObject floorWarning;
    
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map").GetComponent<Map>();

        floorWarning = transform.Find("FloorWarning").gameObject;
        floorWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        highlighted = false;
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (map.getPosFromWorldPosition(mousepos).Equals(getPos()))
            {
                highlighted = true;
            }
            else
            {
                highlighted = false;
            }

        }

        if (active)
        {
            if (highlighted)
            {
                GetComponent<SpriteRenderer>().color = new Color(0.65f, 0.65f, 0.65f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f);
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        
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
        
    }

    public bool isWalkable()
    {
        return unit == null || !unit.getModel().alive;
    }

    public void setUnit(UnitController unit)
    {
        this.unit = unit;
    }

    public void Treathen()
    {
        threatened = true;
        floorWarning.SetActive(true);
    }

    public void clearThreaten()
    {
        threatened = false;
        floorWarning.SetActive(false);
    }

    public UnitController getUnit()
    {
        return unit;
    }
}
