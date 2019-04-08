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
    private GameObject warningUp;
    private GameObject warningDown;
    private GameObject warningLeft;
    private GameObject warningRight;

    private GameObject caltrops;
    
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map").GetComponent<Map>();
        
        floorWarning = transform.Find("floorWarning").gameObject;
        floorWarning.SetActive(false);
        warningUp = transform.Find("warningUp").gameObject;
        warningUp.SetActive(false);
        warningDown = transform.Find("warningDown").gameObject;
        warningDown.SetActive(false);
        warningLeft = transform.Find("warningLeft").gameObject;
        warningLeft.SetActive(false);
        warningRight = transform.Find("warningRight").gameObject;
        warningRight.SetActive(false);
        
        caltrops = transform.Find("caltrops").gameObject;
        caltrops.SetActive(false);
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
        if (tileModel.hasCaltrops)
        {
            clearCaltrops();
            this.unit.takeDamage(1);
        }
    }

    public void Treathen()
    {
        threatened = true;
        floorWarning.SetActive(true);

    }
    
    public void TreathenWithDirection(Position pos)
    {
        threatened = true;
        floorWarning.SetActive(true);
        if (pos.x > 0 && pos.y == 0)
        {
            warningLeft.SetActive(true);
        }
        if (pos.x < 0 && pos.y == 0)
        {
            warningRight.SetActive(true);
        }
        if (pos.x == 0 && pos.y > 0)
        {
            warningUp.SetActive(true);
        }
        if (pos.x == 0 && pos.y < 0)
        {
            warningDown.SetActive(true);
        }
        
    }

    public void clearThreaten()
    {
        threatened = false;
        floorWarning.SetActive(false);
        warningUp.SetActive(false);
        warningDown.SetActive(false);
        warningLeft.SetActive(false);
        warningRight.SetActive(false);
    }

    public void setCaltrops()
    {
        tileModel.hasCaltrops = true;
        caltrops.SetActive(true);
    }

    public void clearCaltrops()
    {
        tileModel.hasCaltrops = false;
        caltrops.SetActive(false);
    }

    public UnitController getUnit()
    {
        return unit;
    }
}
