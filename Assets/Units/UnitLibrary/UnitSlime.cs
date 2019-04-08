using System;
using Model;
using UnityEngine;

namespace Units.UnitLibrary
{
    public class UnitSlime : UnitEnemy
    {
        
        enum State {IDLE, ATTACKING};

        private Position intendedMove;

        private GameObject slimePrefab;

        private void Start()
        {
            base.Start();
            
            slimePrefab = Resources.Load("UnitPrefabs/Slime/Slime") as GameObject;
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
            Position myPos = getPos();
            Tile targetTile = null;
        
            if (myPos.x == heroPos.x)
            {
                targetTile = map.getTile(myPos.x, (int)(myPos.y + Mathf.Sign(heroPos.y - myPos.y)));
            }
        
            if (myPos.y == heroPos.y)
            {
                targetTile = map.getTile((int)(myPos.x + Mathf.Sign(heroPos.x - myPos.x)), myPos.y);
            }

            if (targetTile != null)
            {
                unitModel.state = (int)State.ATTACKING;
                intendedMove = targetTile.getPos() - myPos;
                unitTweener.GetUnitView().GetComponent<Animator>().SetBool("attacking", true);
                targetTile.TreathenWithDirection(intendedMove);
            }
        }

        private void doAttack()
        {
            Tile targetTile = map.getTile(getPos() + intendedMove);
            
            if (targetTile != null)
            {

                Position heroPos = map.getHeroPos();
                Position targetTilePos = targetTile.getPos();

                if (heroPos.Equals(targetTilePos))
                {
                    EffectSpark spark = animationManager.SpawnSpark(AnimationManager.Spark.Bonk, map.tileToGlobalPos(targetTilePos));
                    spark.setSoundEffect("whack");
                    map.getHero().takeDamage(1);
                }
                else
                {
                    if (targetTile.isWalkable())
                    {
                        map.moveUnitToTile(this, new Position((int)targetTilePos.x, (int)targetTilePos.y));
                    }
                }
            }

            unitModel.state = (int)State.IDLE;
        
            unitTweener.GetUnitView().GetComponent<Animator>().SetBool("attacking", false);
            
        }
    }
}