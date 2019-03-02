using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    public GameObject slashPrefab;
    
    public void Start()
    {
        base.Start();

        health = 3;
    }
}
