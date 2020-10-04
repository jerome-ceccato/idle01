using System;

public class BuildingIncarnation
{
    public BuildingEntity Entity { get; private set; }

    public BuildingIncarnation(BuildingEntity entity)
    {
        Entity = entity;
    }
}
