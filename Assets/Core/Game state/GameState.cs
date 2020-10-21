using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using UnityEngine;

public sealed class GameState
{
    public Dictionary<ResourceEntity, BigInteger> resources;
    public Dictionary<Vector2Int, TileContainer> world;

    public List<BuildingEntity> unlockedBuildings;
    public List<BuildingEntity> otherBuildings;

    public List<TerrainUpgradeEntity> unlockedTerrainUpgrades;
    public List<TerrainUpgradeEntity> otherTerrainUpgrades;

    public List<UpgradeEntity> ownedUpgrades;
    public List<UpgradeEntity> unlockedUpgrades;
    public List<UpgradeEntity> otherUpgrades;


    private List<Vector2Int> adjacentTileOffsets = new List<Vector2Int> {
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(-1, 0),
    };

    public GameState()
    {
        resources = new Dictionary<ResourceEntity, BigInteger>();
        world = new Dictionary<Vector2Int, TileContainer>();

        unlockedBuildings = new List<BuildingEntity>();
        otherBuildings = new List<BuildingEntity>(DataStore.Shared.Buildings);

        ownedUpgrades = new List<UpgradeEntity>();
        unlockedUpgrades = new List<UpgradeEntity>();
        otherUpgrades = new List<UpgradeEntity>(DataStore.Shared.Upgrades);

        unlockedTerrainUpgrades = new List<TerrainUpgradeEntity>();
        otherTerrainUpgrades = new List<TerrainUpgradeEntity>(DataStore.Shared.TerrainUpgrades);
    }

    public void AddResource(ResourceEntity resource, BigInteger amount)
    {
        BigInteger owned = resources.ContainsKey(resource) ? resources[resource] : new BigInteger(0);
        resources[resource] = BigInteger.Add(owned, amount);
    }

    private bool HasResource(ResourceEntity resource, BigInteger minimumAmount)
    {
        return resources.ContainsKey(resource) && resources[resource] >= minimumAmount;
    }

    public bool CanAfford(ResolvedGenerator generator)
    {
        return resources.ContainsKey(generator.Resource) && resources[generator.Resource] >= generator.Amount;
    }

    public bool CanAfford(BuildingEntity building, ResolvedMultipliers multipliers)
    {
        return CanAfford(ResolvedGenerator.List(building.BuildCost.Resources, multipliers));
    }

    public bool CanAfford(TerrainUpgradeEntity terrainUpgrade, ResolvedMultipliers multipliers)
    {
        return CanAfford(ResolvedGenerator.List(terrainUpgrade.BuildCost.Resources, multipliers));
    }

    public bool CanAfford(UpgradeEntity upgrade, ResolvedMultipliers multipliers)
    {
        return CanAfford(ResolvedGenerator.List(upgrade.BuyCost.Resources, multipliers));
    }

    public bool CanAfford(List<ResolvedGenerator> cost)
    {
        foreach (ResolvedGenerator item in cost)
        {
            if (!CanAfford(item))
            {
                return false;
            }
        }
        return true;
    }

    public bool CanTrade(MarketEntry marketEntry)
    {
        return resources.ContainsKey(marketEntry.Resource.Entity) && resources[marketEntry.Resource.Entity] > 0;
    }

    private void Buy(List<ResolvedGenerator> cost)
    {
        foreach (ResolvedGenerator item in cost)
        {
            resources[item.Resource] -= item.Amount;
        }
    }

    public bool TryUnlockUpgrade(UpgradeEntity upgrade, ResolvedMultipliers multipliers)
    {
        List<ResolvedGenerator> cost = ResolvedGenerator.List(upgrade.BuyCost.Resources, multipliers);

        if (!CanAfford(cost))
        {
            return false;
        }
        Buy(cost);

        unlockedUpgrades.Remove(upgrade);
        ownedUpgrades.Add(upgrade);
        return true;
    }

    public bool TryBuild(BuildingEntity building, ResolvedMultipliers multipliers, TileContainer tileContainer)
    {
        List<ResolvedGenerator> cost = ResolvedGenerator.List(building.BuildCost.Resources, multipliers);

        if (!CanAfford(cost))
        {
            return false;
        }
        Buy(cost);

        tileContainer.building = new BuildingIncarnation(building);
        if (!(building.Effect is BuildingEffectHarvester))
        {
            tileContainer.growable = null;
        }
        return true;
    }

    public bool TryBuild(TerrainUpgradeEntity terrainUpgrade, ResolvedMultipliers multipliers, TileContainer tileContainer)
    {
        List<ResolvedGenerator> cost = ResolvedGenerator.List(terrainUpgrade.BuildCost.Resources, multipliers);

        if (!CanAfford(cost))
        {
            return false;
        }
        Buy(cost);

        tileContainer.terrain = terrainUpgrade.Replacement.Entity;
        tileContainer.growable = terrainUpgrade.Replacement.Entity.Growable != null ? new GrowableIncarnation(terrainUpgrade.Replacement.Entity.Growable.Entity) : null;
        return true;
    }

    public bool TryGenerate(BuildingEffectGenerator building, ResolvedMultipliers multipliers)
    {
        List<ResolvedGenerator> consumed = ResolvedGenerator.List(building.Consumed, multipliers);
        List<ResolvedGenerator> generated = ResolvedGenerator.List(building.Generated, multipliers);

        foreach (ResolvedGenerator cost in consumed)
        {
            if (!CanAfford(cost))
            {
                return false;
            }
        }

        foreach (ResolvedGenerator cost in consumed)
        {
            AddResource(cost.Resource, -cost.Amount);
        }
        foreach (ResolvedGenerator cost in generated)
        {
            AddResource(cost.Resource, cost.Amount);
        }
        return true;
    }

    public bool TryTrade(MarketEntry marketEntry)
    {
        if (!CanTrade(marketEntry))
        {
            return false;
        }

        resources[marketEntry.Resource.Entity] -= 1;
        AddResource(DataStore.Shared.Get<ResourceEntity>("money"), marketEntry.Amount);
        return true;
    }

    public void Unlock(UpgradeEntity upgrade)
    {
        otherUpgrades.Remove(upgrade);
        unlockedUpgrades.Add(upgrade);
    }

    public void Unlock(BuildingEntity building)
    {
        otherBuildings.Remove(building);
        unlockedBuildings.Add(building);
    }

    public void Unlock(TerrainUpgradeEntity upgrade)
    {
        otherTerrainUpgrades.Remove(upgrade);
        unlockedTerrainUpgrades.Add(upgrade);
    }

    public bool HasAdjacentTile(Vector2Int tilePosition)
    {
        foreach (Vector2Int offset in adjacentTileOffsets)
        {
            if (world.ContainsKey(tilePosition + offset))
            {
                return true;
            }
        }
        return false;
    }

    public bool CanUnlock(UnlockRule rule)
    {
        if (rule == null)
        {
            return true;
        }

        if (rule.RequiredResources != null)
        {
            foreach (MinimumResourceRequirement requirement in rule.RequiredResources)
            {
                if (!HasResource(requirement.Resource.Entity, requirement.Amount))
                {
                    return false;
                }
            }
        }
        if (rule.RequiredUpgrades != null)
        {
            foreach (LazyEntity<UpgradeEntity> entity in rule.RequiredUpgrades)
            {
                if (!ownedUpgrades.Contains(entity.Entity))
                {
                    return false;
                }
            }
        }
        if (rule.RequiredBuildings != null)
        {
            foreach (LazyEntity<BuildingEntity> entity in rule.RequiredBuildings)
            {
                if (!world.Values.Any(tile => tile.building?.Entity == entity.Entity))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
