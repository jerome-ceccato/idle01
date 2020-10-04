using System.Collections.Generic;

public class Buildings
{
    public static BuildingEntity farmer = new BuildingEntity("farmer", "Farmer", "Just a farmer trying to earn their bread",
        new BaseCost(new Generator("farmer_wheat", Resources.wheat, 10)),
        new List<Generator> { new Generator("farmer_generator", Resources.wheat, 1) },
        new List<Generator>(),
        new UnlockRule(),
        new BuildRule(new List<TerrainEntity> { Terrains.dirt }, null),
        new Frequency("farmer_frequency", 10));

    public static BuildingIncarnation CreateFarmer()
    {
        return new BuildingIncarnation(farmer);
    }
}
