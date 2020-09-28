using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResources: MonoBehaviour
{
    public Tile template;
    
    public Tile TileForEntity(Entity e)
    {
        // TODO cache
        Tile copy = Instantiate<Tile>(template);
        copy.sprite = UnityEngine.Resources.Load<Sprite>(e.Id);
        return copy;
        //return (Tile)GetType().GetField(e.Id).GetValue(this);
    }
}
