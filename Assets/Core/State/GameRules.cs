using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRules
{
    public ResourceEntity ResourceForGrowable(GrowableGroup growable)
    {
        Dictionary<string, ResourceEntity> resources = new Dictionary<string, ResourceEntity>()
        {
            { "growable_wheat", Resources.wheat },
        };

        return resources[growable.Id];
    }

    public Multiplier MultiplierForGrowable(GrowableGroup growable)
    {
        return new Multiplier();
    }
}
