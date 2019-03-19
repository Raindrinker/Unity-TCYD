using Model;
using UnityEngine;

namespace Units.UnitLibrary
{
    public class UnitHero : UnitController
    {
        private GameObject heroPrefab;

        private void Start()
        {
            base.Start();
            
            heroPrefab = Resources.Load("UnitPrefabs/Hero/Hero") as GameObject;
            createView(heroPrefab);
        }

    }
}