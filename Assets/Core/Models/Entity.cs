using System;

public abstract class Entity
{
    public readonly string Id;

    protected Entity(string id)
    {
        Id = id;
    }
}
