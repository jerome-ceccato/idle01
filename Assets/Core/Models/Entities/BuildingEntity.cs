using System;
public class BuildingEntity : Entity
{
    public BuildingEntity(string id, string displayName, string flavorText) 
        : base("Building/" + id, displayName, flavorText)
    {

    }
}
