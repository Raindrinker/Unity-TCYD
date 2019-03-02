using System;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Random = System.Random;

public class Unit : MonoBehaviour
{
    protected Map map;
    protected Tile tile;
    
    protected Random rand = new Random(Guid.NewGuid().GetHashCode());

    protected int health = 1;

    public void Start()
    {
        map = GameObject.Find("Map").GetComponent<Map>();
    }
    
    public Tile getTile()
    {
        return tile;
    }

    public void setTile(Tile tile)
    {
        this.tile = tile;
        this.transform.position = tile.transform.position;
    }

    public void destroy()
    {
        tile.setUnit(null);
        Destroy(gameObject);
    }

    public virtual void takeTurn()
    {
        
    }

    public virtual void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            destroy();
        }
    }
}


