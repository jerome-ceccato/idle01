using System;

public class TerrainFactory
{
    public static Terrain grassField()
    {
        return new TerrainField("grassField", 100, new TileResource("wheat"));
    }
}
