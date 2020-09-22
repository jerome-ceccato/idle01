using System;

public abstract class Entity
{
    public string Id { get; private set; }

    protected Entity(string id)
    {
        Id = id;
    }
}
