using System.Runtime.Remoting.Messaging;
using UnityEngine;

    
public class Unit : MonoBehaviour
{
    private Tile tile;
    
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
}


