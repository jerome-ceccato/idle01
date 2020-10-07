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

        unlockedBuildings = new List<BuildingEntity>()
        {
            Buildings.farmer,
            Buildings.farmerOld,
            Buildings.farm,
        };
        otherBuildings = new List<BuildingEntity>();

        ownedUpgrades = new List<UpgradeEntity>();
        unlockedUpgrades = new List<UpgradeEntity>
        {
            Upgrades.basicFertilizer,
        };
        otherUpgrades = new List<UpgradeEntity>();

        unlockedTerrainUpgrades = new List<TerrainUpgradeEntity>
        {
            Upgrades.dirtToGrass,
        };
        otherTerrainUpgrades = new List<TerrainUpgradeEntity>();
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

    private void Buy(BaseCost cost)
    {
        // TODO: Missing multipliers
        foreach (Generator item in cost.Resources)
        {
            resources[item.Resource] -= item.Amount;
        }
    }

    public void UnlockUpgrade(UpgradeEntity upgrade)
    {
        Buy(upgrade.BuyCost);

        unlockedUpgrades.Remove(upgrade);
        ownedUpgrades.Add(upgrade);
    }

    public void Build(BuildingEntity building, TileContainer tileContainer)
    {
        Buy(building.BuildCost);

        tileContainer.building = new BuildingIncarnation(building);
        if (!(building.Effect is BuildingEffectHarvester))
        {
            tileContainer.growable = null;
        }
    }

    public void Build(TerrainUpgradeEntity terrainUpgrade, TileContainer tileContainer)
    {
        Buy(terrainUpgrade.BuildCost);

        tileContainer.terrain = terrainUpgrade.Replacement;
        tileContainer.growable = terrainUpgrade.Replacement.Growable != null ? new GrowableIncarnation(terrainUpgrade.Replacement.Growable) : null;
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
}
