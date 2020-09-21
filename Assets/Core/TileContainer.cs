using System;

public sealed class TileContainer
{
    public Terrain terrain;
    // nullable
    public Building building;

    public TileContainer(Terrain terrain, Building building)
    {
        this.terrain = terrain;
        this.building = building;
    }

    public void Tick()
    {
        terrain.Tick();
    }
}
