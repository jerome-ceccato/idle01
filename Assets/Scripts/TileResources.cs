using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResources: MonoBehaviour
{
    // terrain
    public Tile grassField;

    // buildings
    public Tile wheat;


    public Tile TileForEntity(Entity e)
    {
        return (Tile)GetType().GetField(e.Id).GetValue(this);
    }
}
