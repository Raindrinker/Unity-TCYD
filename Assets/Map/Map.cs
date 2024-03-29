﻿using System.Collections;
using System.Collections.Generic;
using Cards;
using DefaultNamespace;
using Model;
using Units;
using Units.UnitLibrary;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Map : MonoBehaviour
{   
    public GameObject floorTilePrefab;
    public GameObject unitPrefab;

    private MapModel mapModel;

    private Tile[,] tiles = new Tile[5,5];
    private float tileSeparation = 3.0f;
    
    private List<UnitController> units = new List<UnitController>();

    private UnitHero hero;

    // Start is called before the first frame update
    void Start()
    {
        mapModel = new MapModel();
        
        for (var i = 0; i < tiles.GetLength(0); i++)
        {
            for (var j = 0; j < tiles.GetLength(1); j++)
            {
                var tile = Instantiate(floorTilePrefab, transform, true).GetComponent<Tile>();
                
                tile.SetWorldPosition(tileToLocalPos(i, j));
                tile.setModel(mapModel.GetTile(i, j));
                tiles[i, j] = tile;
            }
        }

        spawnHero();
        spawnUnits();
        
    }

    public Vector2 tileToLocalPos(int xtile, int ytile)
    {
        return new Vector2(xtile * tileSeparation, -ytile * tileSeparation);
    }
    
    public Vector2 tileToLocalPos(Position pos)
    {
        return tileToLocalPos(pos.x, pos.y);
    }
    
    public Vector2 tileToGlobalPos(Position pos)
    {
        return tileToLocalPos(pos.x, pos.y) + (Vector2)transform.position;
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
    
    public Tile getTile(Position pos)
    {
        if (pos.x < tiles.GetLength(0) && pos.x >= 0)
        {
            if (pos.y < tiles.GetLength(1) && pos.y >= 0) {
                return tiles[pos.x, pos.y];
            }
        }

        return null;
    }

    public Position getPosFromWorldPosition(Vector2 worldPos)
    {
        float xposmap = worldPos.x - transform.position.x + tileSeparation/2;
        float yposmap = worldPos.y - transform.position.y - tileSeparation/2;

        int xpos = (int)(xposmap / tileSeparation);
        int ypos = (int)(yposmap / -tileSeparation);
    
        return new Position(xpos, ypos);
    }

    public Tile getTileFromWorldPosition(Vector2 worldPos)
    {
        Position pos = getPosFromWorldPosition(worldPos);

        return getTile(pos.x, pos.y);
    }

    public Position getHeroPos()
    {
        return hero.getPos();
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

    public void moveUnitToTile(UnitController unit, Position pos)
    {
        if (getTile(pos) != null)
        {
            if (getTile(pos).getUnit() == null)
            {
                Position unitPos = unit.getPos();
                tiles[unitPos.x, unitPos.y].setUnit(null);
                unit.setPosition(pos);
                tiles[pos.x, pos.y].setUnit(unit);
            }
        }
    }

    public UnitController getHero()
    {
        return hero;
    }

    private void spawnHero()
    {
        UnitModel unitModel = mapModel.GetHero();
        
        GameObject unitGO = Instantiate(unitPrefab, transform);
        UnitHero unit;
        unit = unitGO.AddComponent<UnitHero>();
        
        unit.setMap(this);
        unit.setModel(unitModel);
        hero = unit;
        
        tiles[unitModel.pos.x, unitModel.pos.y].setUnit(unit);
    }

    private void spawnUnits()
    {
        List<UnitModel> unitModels = mapModel.GetUnits();

        for (int i = 0; i < unitModels.Count; i++)
        {
            spawnUnit(unitModels[i]);
        }
       
    }

    private void spawnUnit(UnitModel unitModel)
    {
        GameObject unitGO = Instantiate(unitPrefab, transform);
        UnitController unit;
        
        switch (unitModel.type)
        {
            case UnitModel.UnitType.Slime:
                unit = unitGO.AddComponent<UnitSlime>();
                break;
            case UnitModel.UnitType.Diamondcrystal:
                unit = unitGO.AddComponent<UnitDiamondCrystal>();
                break;
            case UnitModel.UnitType.Chaser:
                unit = unitGO.AddComponent<UnitChaser>();
                break;
            case UnitModel.UnitType.QueenHeart:
                unit = unitGO.AddComponent<UnitQueenHeart>();
                break;
            case UnitModel.UnitType.CardiacMonarch:
                unit = unitGO.AddComponent<UnitCardiacMonarch>();
                break;
            default:
                unit = unitGO.AddComponent<UnitController>();
                break;
        }
        
        unit.setMap(this);
        unit.setModel(unitModel);  
        units.Add(unit);
        
        tiles[unitModel.pos.x, unitModel.pos.y].setUnit(unit);
    }

    public void takeUnitsTurn()
    {
        for (var i = 0; i < tiles.GetLength(0); i++)
        {
            for (var j = 0; j < tiles.GetLength(1); j++)
            {
                tiles[i, j].clearThreaten();
            }
        }

        foreach (UnitController u in units)
        {
            if (u != null)
            {
                if (u.getModel().alive)
                {
                    u.takeTurn();
                }
            }
        }
    }

    public void checkLevelEnd()
    {
        bool alldead = true;
        
        for (var i = 0; i < units.Count; i++)
        {
            UnitController unit = units[i];

            if (unit.getModel().alive)
            {
                alldead = false;
            }
            
        }

        if (alldead)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}





