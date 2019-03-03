using System.Collections.Generic;
using UnityEngine;

public class Slime : Unit
{
    public GameObject bonkPrefab;
    
    enum State {IDLE, ATTACKING};

    private State state = State.IDLE;
    
    private Tile targetTile;

    public void Start()
    {
        base.Start();

        health = 4;
    }
    
    public override void takeTurn()
    {
        Debug.Log("Diamond Crystal turn");
        
        switch (state)
        {
            case State.IDLE:
                prepareAttack();
                break;
            case State.ATTACKING:
                doAttack();
                break;
        }
    }

    private void prepareAttack()
    {
        Vector2 heroPos = map.getHeroPos();
        Vector2 myPos = map.getPosFromWorldPosition(transform.position);
        targetTile = null;
        
        if (myPos.x == heroPos.x)
        {
            targetTile = map.getTile((int)myPos.x, (int)(myPos.y + Mathf.Sign(heroPos.y - myPos.y)));
        }
        
        if (myPos.y == heroPos.y)
        {
            targetTile = map.getTile((int)(myPos.x + Mathf.Sign(heroPos.x - myPos.x)), (int)myPos.y);
        }

        if (targetTile != null)
        {
            state = State.ATTACKING;
            GetComponent<Animator>().SetBool("attacking", true);
        }
    }

    private void doAttack()
    {
        if (targetTile != null)
        {

            Vector2 heroPos = map.getHeroPos();
            Vector2 targetTilePos = map.getPosFromWorldPosition(targetTile.transform.position);

            if (heroPos == targetTilePos)
            {
                map.getHero().takeDamage(1);
                var bonk = GameObject.Instantiate(bonkPrefab, targetTile.transform);
                bonk.transform.position = targetTile.transform.position;
            }
            else
            {
                if (targetTile.isWalkable())
                {
                    map.moveUnitToTile(this, targetTile);
                }
            }

            targetTile = null;
        }

        state = State.IDLE;
        
        GetComponent<Animator>().SetBool("attacking", false);
    }
}
