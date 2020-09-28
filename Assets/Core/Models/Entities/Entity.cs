using System;

// An immutable identifiable resource
public abstract class Entity
{
    public string Id { get; private set; }

    protected Entity(string id)
    {
        Id = id;
    }
}
