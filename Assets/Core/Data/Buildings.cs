using System.Collections.Generic;

public class Buildings
{
    public static BuildingEntity farmer = new BuildingEntity("farmer", "Farmer", "Just a farmer trying to earn his bread. He collects wheat, sometimes",
        new BaseCost(new Generator("farmer_wheat", Resources.wheat, 10)),
        new BuildingEffectHarvester(),
        new UnlockRule(),
        new BuildRule(new List<TerrainEntity> { Terrains.grass }, null),
        new Frequency("farmer_frequency", 100, 20));

    public static BuildingEntity farmerOld = new BuildingEntity("farmer_old", "Old farmer", "An old farmer that knows how it's done. Faster than the youth",
        new BaseCost(new Generator("farmer2_wheat", Resources.wheat, 20)),
        new BuildingEffectHarvester(),
        new UnlockRule(),
        new BuildRule(null, farmer),
        new Frequency("farmer_frequency", 20, 10));

    public static BuildingEntity farm = new BuildingEntity("farm", "Small farm", "A small wheat farm",
        new BaseCost(new Generator("farm_wheat", Resources.wheat, 100)),
        new BuildingEffectGenerator(new Generator("farm_wheat_gen", Resources.wheat, 1)),
        new UnlockRule(),
        new BuildRule(null, farmerOld),
        new Frequency("farm_frequency", 10, 0));

    public static BuildingIncarnation CreateFarmer()
    {
        return new BuildingIncarnation(farmer);
    }
}
