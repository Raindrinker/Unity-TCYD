using System;
using DefaultNamespace;
using Model;
using Units.UnitLibrary;
using UnityEngine;

namespace Cards
{
    public class CardClub : CardInfo
    {
        
        public CardClub()
        {
            cardName = "Club";
            imageName = "Club";

            useOnTile = true;
        }
        
        public override bool isTileValid(Map map, UnitController hero, Tile t)
        {
            Position heroPos = hero.getPos();
            Position tilePos = t.getPos();

            var dist = Position.Distance(heroPos, tilePos);

            if (dist == 1)
            {
                return true;
            }

            return false;
        }
        
        protected override void effect(GameObject card, DeckManager deckManager, Map map, UnitController hero, Tile t)
        {
            AnimationManager animationManager = GameObject.Find("AnimationManager").GetComponent<AnimationManager>();
            
            Position heroPos = hero.getPos();
            Position tilePos = t.getPos();
            
            Position dir = new Position(tilePos.x - heroPos.x, tilePos.y - heroPos.y);
            
            if (t != null)
            {
                EffectSpark spark = animationManager.SpawnSpark(AnimationManager.Spark.Bonk, map.tileToGlobalPos(tilePos));
                UnitController targetUnit = t.getUnit();
                if (targetUnit != null)
                {
                    Debug.Log("DAMAGE");
                    map.moveUnitToTile(targetUnit, targetUnit.getPos() + dir);
                    targetUnit.takeDamage(1);
                    
                    spark.setSoundEffect("whack");

                }
                else
                {
                    spark.setSoundEffect("whiff");
                }
            }

            card.GetComponent<Card>().discard();
            
            map.takeUnitsTurn();
        }
    }
}