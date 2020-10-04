using System;

// Incarnation of a building: a building in the world, with its own mutable data
public class BuildingIncarnation
{
    public BuildingEntity Entity { get; private set; }
    public Ticker Ticker { get; private set; }

    public BuildingIncarnation(BuildingEntity entity)
    {
        Entity = entity;
        Ticker = new Ticker(entity.GeneratorFrequency);
    }
}
