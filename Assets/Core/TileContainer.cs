using System;

public sealed class TileContainer
{
    public Terrain terrain;
    // nullable
    public Growable growable;
    // nullable
    public Building building;

    public TileContainer(Terrain terrain, Growable growable, Building building)
    {
        this.terrain = terrain;
        this.growable = growable;
        this.building = building;
    }

    public void Tick()
    {
        terrain.Tick();
        growable?.Tick();
        building?.Tick();
    }
}

