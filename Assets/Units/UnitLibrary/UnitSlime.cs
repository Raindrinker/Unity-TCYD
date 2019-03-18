using System;
using Model;
using UnityEngine;

namespace Units.UnitLibrary
{
    public class UnitSlime : UnitController
    {
        
        enum State {IDLE, ATTACKING};

        private Tile targetTile;

        private GameObject slimePrefab;

        private void Start()
        {
            base.Start();
            
            slimePrefab = Resources.Load("UnitPrefabs/SlimeResources/Slime") as GameObject;
            createView(slimePrefab);
        }

        public override void takeTurn()
        {
            base.takeTurn();

            State state = (State)unitModel.state;
        
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
            Position heroPos = map.getHeroPos();
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
                unitModel.state = (int)State.ATTACKING;
                unitTweener.GetUnitView().GetComponent<Animator>().SetBool("attacking", true);
            }
        }

        private void doAttack()
        {
            if (targetTile != null)
            {

                Position heroPos = map.getHeroPos();
                Position targetTilePos = targetTile.getPos();

                if (heroPos.Equals(targetTilePos))
                {
                    animationManager.SpawnSpark(AnimationManager.Spark.Bonk, map.tileToGlobalPos(targetTilePos));
                    map.getHero().takeDamage(1);
                }
                else
                {
                    if (targetTile.isWalkable())
                    {
                        map.moveUnitToTile(this, new Position((int)targetTilePos.x, (int)targetTilePos.y));
                    }
                }

                targetTile = null;
            }

            unitModel.state = (int)State.IDLE;
        
            unitTweener.GetUnitView().GetComponent<Animator>().SetBool("attacking", false);
            
        }
    }
}