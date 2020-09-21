using System;

public sealed class TileResource: Entity
{
    public Resource resource;
    public int amount;

    public TileResource(string id, Resource resource, int amount) : base(id)
    {
        this.resource = resource;
        this.amount = amount;
    }
}
