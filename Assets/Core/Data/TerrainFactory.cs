using System.Collections.Generic;

public class TerrainFactory
{
    public static GrowableTerrain grassField()
    {
        return new GrowableTerrain("grassField",
            new GrowingResource(new List<GrowingResource.GrowthStage>()
            {
                new GrowingResource.GrowthStage("plant1", 20, 10),
                new GrowingResource.GrowthStage("plant2", 20, 10),
            },
            new GrowingResource.TileResource(Resources.food, 1)));
    }
}
