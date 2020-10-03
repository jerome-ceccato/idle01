using System.Collections.Generic;

public class BuildRule
{
    public List<TerrainEntity> PossibleTerrains { get; private set; }
    public BuildingEntity PreviousBuilding { get; private set; }

    public BuildRule(List<TerrainEntity> possibleTerrains, BuildingEntity previousBuilding)
    {
        PossibleTerrains = possibleTerrains;
        PreviousBuilding = previousBuilding;
    }
}
