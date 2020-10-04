using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class GameState
{
    public Dictionary<ResourceEntity, BigInteger> resources;
    public Dictionary<Vector2Int, TileContainer> world;

    public List<BuildingEntity> unlockedBuildings;
    public List<BuildingEntity> otherBuildings;

    public List<UpgradeEntity> ownedUpgrades;
    public List<UpgradeEntity> unlockedUpgrades;
    public List<UpgradeEntity> otherUpgrades;

    public GameState()
    {
        resources = new Dictionary<ResourceEntity, BigInteger>();
        world = new Dictionary<Vector2Int, TileContainer>();

        unlockedBuildings = new List<BuildingEntity>();
        otherBuildings = new List<BuildingEntity>();

        ownedUpgrades = new List<UpgradeEntity>();
        unlockedUpgrades = new List<UpgradeEntity>
        {
            Upgrades.basicFertilizer,
        };
        otherUpgrades = new List<UpgradeEntity>();
    }

    public void AddResource(ResourceEntity resource, BigInteger amount)
    {
        BigInteger owned = resources.ContainsKey(resource) ? resources[resource] : new BigInteger(0);
        resources[resource] = BigInteger.Add(owned, amount);
    }

    public bool CanAfford(BaseCost cost)
    {
        // TODO: Missing multipliers
        foreach (Generator item in cost.Resources)
        {
            if (!resources.ContainsKey(item.Resource) || resources[item.Resource] < item.Amount)
            {
                return false;
            }
        }
        return true;
    }

    public void UnlockUpgrade(UpgradeEntity upgrade)
    {
        // TODO: Missing multipliers
        foreach (Generator item in upgrade.BuyCost.Resources)
        {
            resources[item.Resource] -= item.Amount;
        }

        unlockedUpgrades.Remove(upgrade);
        ownedUpgrades.Add(upgrade);
    }
}
