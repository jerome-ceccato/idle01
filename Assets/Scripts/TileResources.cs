using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResources: MonoBehaviour
{
    // terrain
    public Tile grass;
    public Tile grassWithStones;

    // buildings
    public Tile wheat;


    public Tile TileForTerrain(Terrain t)
    {
        switch (t)
        {
            case Terrain.Grass:
                return grass;
            case Terrain.GrassWithStones:
                return grassWithStones;
            default:
                return null;
        }
    }
}
