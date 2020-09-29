using System.Collections.Generic;

public class TerrainFactory
{
    public static Terrain GrassField()
    {
        return new Terrain(new TerrainEntity("grassField"));
    }
}
