using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class GameState
{
    public Dictionary<ResourceEntity, BigInteger> resources;
    public Dictionary<Vector2Int, TileContainer> world;

    public List<Upgrade> ownedUpgrades;
    public List<Upgrade> unlockedUpgrades;
    public List<Upgrade> otherUpgrades;

    public GameState()
    {
        resources = new Dictionary<ResourceEntity, BigInteger>();
        world = new Dictionary<Vector2Int, TileContainer>();

        ownedUpgrades = new List<Upgrade>();
        unlockedUpgrades = new List<Upgrade>(Upgrades.all);
        otherUpgrades = new List<Upgrade>();
    }

    public void AddResource(ResourceEntity resource, BigInteger amount)
    {
        BigInteger owned = resources.ContainsKey(resource) ? resources[resource] : new BigInteger(0);
        resources[resource] = BigInteger.Add(owned, amount);
    }

    public bool CanAfford(BaseCost cost)
    {
        foreach (var item in cost.Resources)
        {
            if (!resources.ContainsKey(item.Item1) || resources[item.Item1] < item.Item2)
            {
                return false;
            }
        }
        return true;
    }

    public void UnlockUpgrade(Upgrade upgrade)
    {
        foreach (var item in upgrade.Cost.Resources)
        {
            resources[item.Item1] -= item.Item2;
        }

        unlockedUpgrades.Remove(upgrade);
        ownedUpgrades.Add(upgrade);
    }
}
