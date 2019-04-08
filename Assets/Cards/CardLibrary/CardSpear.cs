using System;
using DefaultNamespace;
using Model;
using Units.UnitLibrary;
using UnityEngine;

namespace Cards
{
    public class CardSpear : CardInfo
    {
        
        public CardSpear()
        {
            cardName = "Spear";
            imageName = "spear";

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
            
            if (dist == 2 && (heroPos.x == tilePos.x || heroPos.y == tilePos.y))
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
            
            Position off = new Position(tilePos.x - heroPos.x, tilePos.y - heroPos.y);
            if (Position.Distance(heroPos, tilePos) > 1)
            {
                off.x /= 2;
                off.y /= 2;
            }

            Position tile1pos = heroPos + off;
            Position tile2pos = heroPos + off * 2;

            Tile t1 = map.getTile(tile1pos);
            Tile t2 = map.getTile(tile2pos);

            EffectSpark spark = null;
            if (t1 != null)
            {
                spark = animationManager.SpawnSpark(AnimationManager.Spark.Slash, map.tileToGlobalPos(tile1pos));
            }
            if (t2 != null)
            {
                animationManager.SpawnSpark(AnimationManager.Spark.Slash, map.tileToGlobalPos(tile2pos));
            }
            spark.setSoundEffect("whiff");

            if (t1 != null)
            {
                if (t1.getUnit() != null)
                {
                    Debug.Log("DAMAGE");
                    t1.getUnit().takeDamage(1);
                    spark.setSoundEffect("slash");
                }
            }
            
            if (t2 != null)
            {
                if (t2.getUnit() != null)
                {
                    Debug.Log("DAMAGE");
                    t2.getUnit().takeDamage(1);
                    spark.setSoundEffect("slash");
                }
            }

            card.GetComponent<Card>().discard();
            
            map.takeUnitsTurn();
        }
    }
}