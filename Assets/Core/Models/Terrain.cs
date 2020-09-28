using System;
public class Terrain
{
    public readonly TerrainEntity entity;
    public Terrain(TerrainEntity entity)
    {
        this.entity = entity;
    }

    public virtual void Tick() { }
}
