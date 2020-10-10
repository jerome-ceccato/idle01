using System;

public sealed class TileContainer
{
    // nullable
    public ISpecialEntity specialEntity;

    public TerrainEntity terrain;
    // nullable
    public GrowableIncarnation growable;
    // nullable
    public BuildingIncarnation building;

    public TileContainer(TerrainEntity terrain, GrowableIncarnation growable, BuildingIncarnation building)
    {
        this.specialEntity = null;
        this.terrain = terrain;
        this.growable = growable;
        this.building = building;
    }

    public TileContainer(TerrainEntity terrain, ISpecialEntity special)
    {
        this.specialEntity = special;
        this.terrain = terrain;
        this.growable = null;
        this.building = null;
    }
}
