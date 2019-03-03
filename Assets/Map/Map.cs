using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public GameObject heroPrefab;
    public GameObject potPrefab;
    public GameObject diamondCrystalPrefab;
    public GameObject slimePrefab;
    
    public GameObject floorTilePrefab;



    private Tile[,] tiles = new Tile[5,5];
    private float tileSeparation = 3.0f;
    
    private List<Unit> units = new List<Unit>();

    private Hero hero;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < tiles.GetLength(0); i++)
        {
            for (var j = 0; j < tiles.GetLength(1); j++)
            {
                var tile = Instantiate(floorTilePrefab, transform, true).GetComponent<Tile>();
                
                tile.SetWorldPosition(tileToPos(i, j));
                tiles[i, j] = tile;
            }
        }
    
        hero = Instantiate(heroPrefab).GetComponent<Hero>();
        moveUnitToTile(hero, tiles[0,2]);
        
        spawnUnit(potPrefab, 0, 0);
        spawnUnit(potPrefab, 0, 4);
        spawnUnit(diamondCrystalPrefab, 4, 0);
        spawnUnit(diamondCrystalPrefab, 4, 4);
        
        spawnUnit(slimePrefab, 3, 1);
        spawnUnit(slimePrefab, 3, 3);
        
        //spawnUnit(potPrefab, 1, 1);
        //spawnUnit(potPrefab, 1, 3);
        //spawnUnit(potPrefab, 3, 1);
        
    }

    public Vector2 tileToPos(int xtile, int ytile)
    {
        return new Vector2(xtile * tileSeparation, -ytile * tileSeparation);
    }

    public Tile getTile(int xpos, int ypos)
    {
        if (xpos < tiles.GetLength(0) && xpos >= 0)
        {
            if (ypos < tiles.GetLength(1) && ypos >= 0) {
                return tiles[xpos, ypos];
            }
        }

        return null;
    }

    public Vector2 getPosFromWorldPosition(Vector2 worldPos)
    {
        float xposmap = worldPos.x - transform.position.x + tileSeparation/2;
        float yposmap = worldPos.y - transform.position.y - tileSeparation/2;

        int xpos = (int)(xposmap / tileSeparation);
        int ypos = (int)(yposmap / -tileSeparation);
    
        return new Vector2(xpos, ypos);
    }

    public Tile getTileFromWorldPosition(Vector2 worldPos)
    {
        Vector2 pos = getPosFromWorldPosition(worldPos);

        return getTile((int)pos.x, (int)pos.y);
    }

    public Vector2 getHeroPos()
    {
        return getPosFromWorldPosition(hero.transform.position);
    }

    public void HighlightValidTiles(CardInfo ci)
    {
        for (var i = 0; i < tiles.GetLength(0); i++)
        {
            for (var j = 0; j < tiles.GetLength(1); j++)
            {
                Tile t = tiles[i, j];
                if (ci.isTileValid(this, hero, t))
                {
                    t.SetActive(true);
                }
                else
                {
                    t.SetActive(false);
                }
            }
        }
    }

    public void clearHighlights()
    {
        for (var i = 0; i < tiles.GetLength(0); i++)
        {
            for (var j = 0; j < tiles.GetLength(1); j++)
            {
                Tile t = tiles[i, j];
                t.SetActive(false);
            }
        }
    }

    public void moveUnitToTile(Unit unit, Tile t)
    {
        t.setUnit(unit);
        if (unit.getTile() != null)
        {
            unit.getTile().setUnit(null);
        }
        unit.setTile(t);
    }

    public Hero getHero()
    {
        return hero;
    }

    private void spawnUnit(GameObject unitGO, int xpos, int ypos)
    {
        Unit unit = Instantiate(unitGO).GetComponent<Unit>();
        moveUnitToTile(unit, tiles[xpos, ypos]);
        units.Add(unit);
    }

    public void takeUnitsTurn()
    {
        Debug.Log("Units turn, num units: " + units.Count);
        
        foreach (Unit u in units)
        {
            if (u != null)
            {
                Debug.Log("UNIT");
                u.takeTurn();
            }
        }
    }
}





