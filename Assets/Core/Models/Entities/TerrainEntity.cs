using System;
public class TerrainEntity : Entity
{
    public GrowableEntity Growable { get; private set; }

    public TerrainEntity(string id, string displayName, string flavorText, GrowableEntity growable)
        : base("Terrain/" + id, displayName, flavorText)
    {
        Growable = growable;
    }
}
