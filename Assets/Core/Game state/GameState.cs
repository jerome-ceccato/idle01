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

        unlockedBuildings = new List<BuildingEntity>()
        {
            Buildings.farmer,
        };
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

    public bool CanAfford(Generator generator)
    {
        return resources.ContainsKey(generator.Resource) && resources[generator.Resource] >= generator.Amount;
    }

    public bool CanAfford(BaseCost cost)
    {
        // TODO: Missing multipliers
        foreach (Generator item in cost.Resources)
        {
            if (!CanAfford(item))
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

    public void Build(BuildingEntity building, TileContainer tileContainer)
    {
        // TODO: Missing multipliers
        foreach (Generator item in building.BuildCost.Resources)
        {
            resources[item.Resource] -= item.Amount;
        }

        tileContainer.building = new BuildingIncarnation(building);
    }

    public bool Generate(BuildingEffectGenerator building)
    {
        // TODO: Missing multipliers
        foreach (Generator costs in building.Consumed)
        {
            if (!CanAfford(costs))
            {
                return false;
            }
        }

        foreach (Generator costs in building.Consumed)
        {
            AddResource(costs.Resource, -costs.Amount);
        }
        foreach (Generator generated in building.Generated)
        {
            AddResource(generated.Resource, generated.Amount);
        }
        return true;
    }
}
