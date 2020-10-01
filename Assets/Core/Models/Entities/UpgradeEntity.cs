using System;
public class UpgradeEntity : Entity
{
    public UpgradeEntity(string id, string displayName, string flavorText)
        : base("Upgrade/" + id, displayName, flavorText)
    {

    }
}
