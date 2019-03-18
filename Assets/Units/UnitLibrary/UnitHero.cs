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
            
            heroPrefab = Resources.Load("UnitPrefabs/HeroResources/Hero") as GameObject;
            createView(heroPrefab);
        }

    }
}