using System;
using DefaultNamespace;
using Model;
using Units.UnitLibrary;
using UnityEngine;

namespace Cards
{
    public class CardSlash : CardInfo
    {
        
        public CardSlash()
        {
            cardName = "Slash";
            imageName = "slash";

            useOnTile = true;
        }
        
        public override bool isTileValid(Map map, UnitController hero, Tile t)
        {
            Position heroPos = hero.getPos();
            Position tilePos = t.getPos();
            
            return Position.Distance(heroPos, tilePos) == 1;
        }
        
        protected override void effect(GameObject card, DeckManager deckManager, Map map, UnitController hero, Tile t)
        {
            AnimationManager animationManager = GameObject.Find("AnimationManager").GetComponent<AnimationManager>();
            animationManager.SpawnSpark(AnimationManager.Spark.Slash, map.tileToGlobalPos(t.getPos()));
            GameObject.Find("AudioManager").GetComponent<AudioManager>().playClip("slash");
            
            if (t.getUnit() != null)
            {
                Debug.Log("DAMAGE");
                t.getUnit().takeDamage(1);
                
                
            }

            card.GetComponent<Card>().discard();
            
            map.takeUnitsTurn();
        }
    }
}