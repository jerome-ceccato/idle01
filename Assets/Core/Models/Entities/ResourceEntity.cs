using System;

public sealed class ResourceEntity : Entity
{
    public ResourceEntity(string id, string displayName, string flavorText)
        : base("Resource/" + id, displayName, flavorText)
    {
        
    }
}
