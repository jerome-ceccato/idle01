using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class GameManager
{
    private GameState state;
    private GameRules rules;

    // Lifecycle

    private GameManager()
    {
        state = new GameState();
        rules = new GameRules(state);
    }

    public void Start() 
    {
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                TerrainEntity terrain = (x == y) ? Terrains.grass : Terrains.dirt;
                GrowableIncarnation growable = (x == y) ? Growables.CreateWheat() : null;
                BuildingIncarnation building = null;
                state.world.Add(new Vector2Int(x, y), new TileContainer(terrain, growable, building));
            }
        }
    }

    public void Tick() 
    {
        // TODO: improve
        foreach (TileContainer tile in state.world.Values)
        {
            if (tile.growable != null)
            {
                tile.growable.Grow();
            }
            if (tile.building != null)
            {
                if (tile.building.Ticker.MakeTick(1))
                {
                    TickBuilding(tile);
                }
            }
        }
    }

    private void TickBuilding(TileContainer tile)
    {
        if (tile.building.Entity.Effect is BuildingEffectGenerator generator)
        {
            state.Generate(generator);
        }
        else if (tile.building.Entity.Effect is BuildingEffectHarvester)
        {
            if (tile.growable != null)
            {
                CollectGrowable(tile.growable);
            }
            
        }
    }

    public void CollectGrowable(GrowableIncarnation growable)
    {
        if (growable.CanCollect())
        {
            IMultiplier multiplier = rules.MultiplierForGrowable(growable);
            BigInteger amount = multiplier.Apply(growable.Entity.GrownResource.Amount);
            state.AddResource(growable.Entity.GrownResource.Resource, amount);
            growable.Reset();
        }
    }

    public void BuyUpgrade(UpgradeEntity upgrade)
    {
        if (state.CanAfford(upgrade.BuyCost))
        {
            state.UnlockUpgrade(upgrade);
        }
    }

    public void Build(BuildingEntity building, TileContainer tileContainer)
    {
        if (state.CanAfford(building.BuildCost))
        {
            state.Build(building, tileContainer);
        }
    }

    public TileContainer TileContainerAtPosition(Vector2Int position)
    {
        return state.world.ContainsKey(position) ? state.world[position] : null;
    }

    public Dictionary<Vector2Int, TileContainer> World
    {
        get
        {
            return state.world;
        }
    }

    public Dictionary<ResourceEntity, BigInteger> OwnedResources
    {
        get
        {
            return state.resources;
        }
    }

    public List<UpgradeEntity> OwnedUpgrades
    {
        get
        {
            return state.ownedUpgrades;
        }
    }

    public List<UpgradeEntity> AvailableUpgrades
    {
        get
        {
            return state.unlockedUpgrades;
        }
    }

    public List<BuildingEntity> AvailableBuildings
    {
        get
        {
            return state.unlockedBuildings;
        }
    }

    public List<BuildingEntity> AvailableBuildingsForTile(TileContainer tile)
    {
        return AvailableBuildings.FindAll(building => CanBuildOnTile(tile, building));
    }

    private bool CanBuildOnTile(TileContainer tile, BuildingEntity entity)
    {
        if (entity.BuildRule.PreviousBuilding != null)
        {
            return entity.BuildRule.PreviousBuilding == entity;
        }
        else if (tile.building != null)
        {
            return false;
        }

        return entity.BuildRule.PossibleTerrains == null || entity.BuildRule.PossibleTerrains.Contains(tile.terrain);       
    }

    public bool CanAfford(UpgradeEntity upgrade)
    {
        return state.CanAfford(upgrade.BuyCost);
    }

    public bool CanAfford(BuildingEntity building)
    {
        return state.CanAfford(building.BuildCost);
    }

    // Singleton boilerplate

    private static readonly object padlock = new object();
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
    }
}
