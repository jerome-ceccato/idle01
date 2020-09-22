using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResources: MonoBehaviour
{
    // terrain
    public Tile grassField;

    // growables
    public Tile plant1;
    public Tile plant2;
    
    public Tile TileForEntity(Entity e)
    {
        return (Tile)GetType().GetField(e.Id).GetValue(this);
    }
}
