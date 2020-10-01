using System;
using System.Collections.Generic;

public sealed class GrowableEntity : Entity
{
    public GrowableEntity(string id, string displayName, string flavorText)
        : base("Growable/" + id, displayName, flavorText)
    {

    }
}
