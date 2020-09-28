using System;
public class Building
{
    public readonly BuildingEntity entity;
    public Building(BuildingEntity entity)
    {
        this.entity = entity;
    }

    public virtual void Tick() { }
}
