using System.Collections.Generic;

public class Buildings
{
    public static BuildingEntity farmer = new BuildingEntity("farmer", "Farmer", "Just a farmer trying to earn their bread. They collect wheat, sometimes",
        new BaseCost(new Generator("farmer_wheat", Resources.wheat, 10)),
        new BuildingEffectHarvester(),
        new UnlockRule(),
        new BuildRule(new List<TerrainEntity> { Terrains.grass }, null),
        new Frequency("farmer_frequency", 48));

    public static BuildingIncarnation CreateFarmer()
    {
        return new BuildingIncarnation(farmer);
    }
}
