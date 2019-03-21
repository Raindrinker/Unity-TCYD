using System;
using Boo.Lang;
using Model;
using UnityEngine;

namespace Units.UnitLibrary
{
    public class UnitCardiacMonarch : UnitEnemy
    {
        
        enum State {IDLE, ATTACKING};

        private Tile targetTile;

        private GameObject slimePrefab;

        private void Start()
        {
            base.Start();
            
            slimePrefab = Resources.Load("UnitPrefabs/CardiacMonarch/CardiacMonarch") as GameObject;
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
            
            targetTile = null;

            var targetTileOptions = new List<Tile>();
            var targetTileDistToPlayer = Position.Distance(heroPos, myPos);

            for (var i = -1; i <= 1; i ++)
            {
                for (var j = -1; j <= 1; j ++)
                {
                    var t = map.getTile(myPos.x + i, myPos.y + j);
                    if (t != null)
                    {
                        if (t.isWalkable())
                        {
                            Debug.Log("WALKABLE");
                            var distToPlayer = Position.Distance(heroPos, t.getPos());
                            if (distToPlayer > targetTileDistToPlayer)
                            {
                                targetTileOptions.Clear();
                                targetTileOptions.Add(t);
                                targetTileDistToPlayer = distToPlayer;
                            }
                            if (distToPlayer == targetTileDistToPlayer)
                            {
                                targetTileOptions.Add(t);
                            }
                        }
                    }
                }
            }

            if (targetTileOptions.Count > 0)
            {
                int choice = rand.Next(targetTileOptions.Count);
                targetTile = targetTileOptions[choice];
            }

            if (targetTile != null)
            {
                unitModel.state = (int)State.ATTACKING;
                targetTile.Treathen();
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
            
        }
    }
}