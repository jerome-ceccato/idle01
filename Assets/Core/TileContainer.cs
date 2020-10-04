using System;

public sealed class TileContainer
{
    public TerrainEntity terrain;
    // nullable
    public GrowableIncarnation growable;
    // nullable
    public BuildingIncarnation building;

    public TileContainer(TerrainEntity terrain, GrowableIncarnation growable, BuildingIncarnation building)
    {
        this.terrain = terrain;
        this.growable = growable;
        this.building = building;
    }
}
