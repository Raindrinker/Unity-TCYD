using DefaultNamespace;
using UnityEngine;

namespace Units.UnitLibrary
{
    public class UnitEnemy : UnitController
    {
        protected UnitHealthbar unitHealthbar;

        public override void setModel(UnitModel unitModel)
        {
            base.setModel(unitModel);
            
            Debug.Log(transform.Find("UnitHealthbar").GetComponent<UnitHealthbar>());
            unitHealthbar = transform.Find("UnitHealthbar").GetComponent<UnitHealthbar>();
            unitHealthbar.setModel(unitModel);
        }

        public override void takeDamage(int dmg)
        {
            base.takeDamage(dmg);
            
            unitHealthbar.Redraw();
        }
    }
}