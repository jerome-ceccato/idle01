using System.Collections.Generic;

public class TerrainFactory
{
    public static GrowableTerrain grassField()
    {
        return new GrowableTerrain("grassField",
            new GrowingResource(new List<GrowingResource.GrowthStage>()
            {
                new GrowingResource.GrowthStage("plant1", 100, 80),
                new GrowingResource.GrowthStage("plant2", 40, 10),
                
            },
            new GrowingResource.TileResource(Resources.food, 1)));
    }
}
