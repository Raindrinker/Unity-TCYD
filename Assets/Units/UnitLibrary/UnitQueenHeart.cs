using System;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Units.UnitLibrary
{
    public class UnitQueenHeart : UnitEnemy
    {
        
        enum State {IDLE, ATTACKING};

        private Tile targetTile;

        private GameObject crystalPrefab;

        private void Start()
        {
            base.Start();
            
            crystalPrefab = Resources.Load("UnitPrefabs/QueenHeart/QueenHeart") as GameObject;
            createView(crystalPrefab);
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
            var targetTileDistToPlayer = 1000;

            for (var i = -1; i <= 1; i ++)
            {
                for (var j = -1; j <= 1; j ++)
                {
                    var x = 1;
                    while (x < 5)
                    {
                        var t = map.getTile(getPos().x + i*x, getPos().y + j*x);
                        if (t != null)
                        {
                            if (t.isWalkable())
                            {

                                var distToPlayer = Position.Distance(heroPos, t.getPos());
                                if (distToPlayer < targetTileDistToPlayer)
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

                            if (t.getPos().Equals(heroPos))
                            {
                                targetTileOptions.Clear();
                                targetTile = t;
                                targetTileDistToPlayer = 0;
                            }
                        }
                        else
                        {
                            break;
                        }

                        x++;
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

            if (rand.Next(2) < 1)
            {
                unitModel.state = (int)State.IDLE;
            }
            else
            {
                prepareAttack();
            }
            
            
        }
    }
}