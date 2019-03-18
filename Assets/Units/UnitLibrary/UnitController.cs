using System;
using DefaultNamespace;
using Model;
using UnityEngine;

namespace Units.UnitLibrary
{
    public class UnitController : MonoBehaviour
    {
        protected UnitModel unitModel;
        protected UnitTweener unitTweener;

        protected Map map;
        protected AnimationManager animationManager;
        
        protected System.Random rand = new System.Random();

        public void Start()
        {
            animationManager = GameObject.Find("AnimationManager").GetComponent<AnimationManager>();
            unitTweener = GetComponent<UnitTweener>();
        }
        
        public void setModel(UnitModel unitModel)
        {
            Debug.Log("SET MODEL");
            this.unitModel = unitModel;
            transform.localPosition = map.tileToLocalPos(unitModel.pos.x, unitModel.pos.y);
        }

        public void setMap(Map map)
        {
            Debug.Log("SET MAP");
            this.map = map;
        }
        
        public void setPosition(Position pos)
        {
            unitModel.pos = pos;
            unitTweener.addTweenMove(map.tileToLocalPos(pos.x, pos.y));
            
        }
        
        public Position getPosition()
        {
            return unitModel.pos;
        }
    
        public virtual void takeTurn()
        {

            Debug.Log("Unit " + unitModel.name + " takes turn");

        }

        public virtual void takeDamage(int dmg)
        {
            unitModel.hp -= dmg;
            unitTweener.addTweenShake();
            
        }

        protected void createView(GameObject prefab)
        {
            unitTweener.setUnitPrefab(prefab);
        }

        
    }
}