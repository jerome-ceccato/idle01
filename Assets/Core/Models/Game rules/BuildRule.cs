﻿using System.Collections.Generic;

// Requirements to place a building
public class BuildRule
{
    public List<LazyEntity<TerrainEntity>> PossibleTerrains { get; set; }
    public LazyEntity<BuildingEntity> PreviousBuilding { get; set; }
}
