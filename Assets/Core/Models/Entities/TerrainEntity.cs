using System;
public class TerrainEntity : Entity
{
    public TerrainEntity(string id, string displayName, string flavorText)
        : base("Terrain/" + id, displayName, flavorText)
    {

    }
}
