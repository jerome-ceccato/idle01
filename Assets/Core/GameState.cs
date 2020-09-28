using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class GameState
{
    public Dictionary<ResourceEntity, BigInteger> resources;

    public GameState()
    {
        resources = new Dictionary<ResourceEntity, BigInteger>();
    }
}
