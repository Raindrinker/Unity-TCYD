using System.Collections.Generic;
using Model;
using Units.UnitLibrary;
using UnityEngine;

public class DiamondCrystal : UnitController
{
    public GameObject floorWarningGO;
    public GameObject thunderGO;

    enum State {IDLE, TARGETING};

    private State state = State.IDLE;
    
    private Tile targetTile;
    private GameObject floorWarning;

    public void Start()
    {
        base.Start();
    }
    
    public override void takeTurn()
    {
        Debug.Log("Diamond Crystal turn");
        
        switch (state)
        {
            case State.IDLE:
                prepareAttack();
                break;
            case State.TARGETING:
                doAttack();
                break;
        }
    }

    private void prepareAttack()
    {
        Position heroPos = map.getHeroPos();
        List<Tile> targetTiles = new List<Tile>();

        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                Tile t = map.getTile((int) heroPos.x + i, (int) heroPos.y + j);
                if (t != null)
                {
                    targetTiles.Add(t);
                }
            }
        }
            
        int choice = rand.Next(targetTiles.Count);
        targetTile = targetTiles[choice];

        floorWarning = Instantiate(floorWarningGO, transform);
        floorWarning.transform.position = targetTile.transform.position;

        state = State.TARGETING;
        
        GetComponent<Animator>().SetBool("active", true);
    }

    private void doAttack()
    {
        GameObject thunder = Instantiate(thunderGO, targetTile.transform);
        thunder.transform.position = targetTile.transform.position;
        
        UnitController unit = targetTile.getUnit();
        if (unit != null)
        {
            unit.takeDamage(1);
        }
        
        targetTile = null;
        Destroy(floorWarning);

        state = State.IDLE;
        
        GetComponent<Animator>().SetBool("active", false);
    }
}
