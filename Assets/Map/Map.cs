using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public GameObject heroGO;
    public GameObject potGO;

    public GameObject floorTileGO;



    private Tile[,] tiles = new Tile[5,6];
    private float tileSeparation = 3.0f;

    private Unit hero;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < tiles.GetLength(0); i++)
        {
            for (var j = 0; j < tiles.GetLength(1); j++)
            {
                var tile = Instantiate(floorTileGO, transform, true).GetComponent<Tile>();
                
                tile.SetWorldPosition(tileToPos(i, j));
                tiles[i, j] = tile;
            }
        }
    
        hero = Instantiate(heroGO).GetComponent<Unit>();
        moveUnitToTile(hero, tiles[1,1]);
        
        Unit pot = Instantiate(potGO).GetComponent<Unit>();
        moveUnitToTile(pot, tiles[3,3]);
        
        pot = Instantiate(potGO).GetComponent<Unit>();
        moveUnitToTile(pot, tiles[0,4]);
        
        pot = Instantiate(potGO).GetComponent<Unit>();
        moveUnitToTile(pot, tiles[2,0]);
        
        pot = Instantiate(potGO).GetComponent<Unit>();
        moveUnitToTile(pot, tiles[4,5]);
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

    public Unit getHero()
    {
        return hero;
    }
}





