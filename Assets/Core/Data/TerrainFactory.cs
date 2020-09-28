using System.Collections.Generic;

public class TerrainFactory
{
    public static GrowableTerrain grassField()
    {
        return new GrowableTerrain(new TerrainEntity("grassField"),
            new GrowingResource(new List<GrowingResource.GrowthStage>()
            {
                new GrowingResource.GrowthStage(new GrowableEntity("plant1"), 20, 10),
                new GrowingResource.GrowthStage(new GrowableEntity("plant2"), 20, 10),
            },
            new GrowingResource.TileResource(Resources.food, 1)));
    }
}
