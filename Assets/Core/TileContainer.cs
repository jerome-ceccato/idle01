using System;

public sealed class TileContainer
{
    public TerrainEntity terrain;
    // nullable
    public GrowableGroup growable;
    // nullable
    public BuildingEntity building;

    public TileContainer(TerrainEntity terrain, GrowableGroup growable, BuildingEntity building)
    {
        this.terrain = terrain;
        this.growable = growable;
        this.building = building;
    }
}
