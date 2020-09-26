using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameState
{
    public Dictionary<Resource, int> resources;

    public GameState()
    {
        resources = new Dictionary<Resource, int>();
    }
}
