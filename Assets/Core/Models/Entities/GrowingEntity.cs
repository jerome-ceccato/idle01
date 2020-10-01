using System;
using System.Collections.Generic;

public sealed class GrowingEntity : Entity
{
    public GrowingEntity(string id, string displayName, string flavorText)
        : base("Growable/" + id, displayName, flavorText)
    {

    }
}
