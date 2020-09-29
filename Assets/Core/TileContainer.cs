using System;

public sealed class TileContainer
{
    public Terrain terrain;
    // nullable
    public Building building;

    // nullable
    public GrowableEntity GrowableEntity
    {
        get
        {
            return GrowableTerrain?.CurrentlyGrowingEntity;
        }
    }

    private GrowableTerrain GrowableTerrain
    {
        get
        {
            if (terrain is GrowableTerrain)
            {
                return ((GrowableTerrain)terrain);
            }
            else
            {
                return null;
            }
        }
    }

    public TileContainer(Terrain terrain, Building building)
    {
        this.terrain = terrain;
        this.building = building;
    }

    public void Tick()
    {
        if (terrain is GrowableTerrain)
        {
            ((GrowableTerrain)terrain).Tick();
        }
    }
}

