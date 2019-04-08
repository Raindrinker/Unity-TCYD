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
        
        protected System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);

        public void Start()
        {
            animationManager = GameObject.Find("AnimationManager").GetComponent<AnimationManager>();
            unitTweener = GetComponent<UnitTweener>();
            
        }
        
        public virtual void setModel(UnitModel unitModel)
        {
            Debug.Log("SET MODEL");
            this.unitModel = unitModel;
            transform.localPosition = map.tileToLocalPos(unitModel.pos.x, unitModel.pos.y);
           
        }

        public UnitModel getModel()
        {
            return unitModel;
        }

        public void setMap(Map map)
        {
            Debug.Log("SET MAP");
            this.map = map;
        }
        
        public void setPosition(Position pos)
        {
            
            unitTweener.addTweenMove(map.tileToGlobalPos(unitModel.pos), map.tileToGlobalPos(pos));
            unitModel.pos = pos;
            
        }
        
        public Position getPos()
        {
            return unitModel.pos;
        }
    
        public virtual void takeTurn()
        {
            if (!unitModel.alive)
            {
                return;
            }
            
            Debug.Log("Unit " + unitModel.name + " takes turn");

        }

        public virtual void takeDamage(int dmg)
        {
            unitModel.hp -= dmg;
            unitTweener.addTweenShake();
            if (unitModel.hp <= 0)
            {
                Debug.Log("DESTROY");
                unitModel.alive = false;
                map.getTile(getPos()).setUnit(null);
                
                unitTweener.addTweenDeath();
                
                map.checkLevelEnd();
            }
            
        }

        protected void createView(GameObject prefab)
        {
            unitTweener.setUnitPrefab(prefab);
        }

        
    }
}