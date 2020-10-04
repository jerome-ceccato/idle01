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
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                TerrainEntity terrain = (x == 1 && y == 1) ? Terrains.grass : Terrains.dirt;
                GrowableIncarnation growable = (x == 1 && y == 1) ? Growables.CreateWheat() : null;
                BuildingIncarnation building = (x == 1 && y == 1) ? Buildings.CreateFarmer() : null;
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
                    state.Generate(tile.building.Entity);
                }
            }
        }
    }

    public void CollectGrowable(GrowableIncarnation growable)
    {
        if (growable.CanCollect())
        {
            Multiplier multiplier = rules.MultiplierForGrowable(growable);
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

    public bool CanAfford(UpgradeEntity upgrade)
    {
        return state.CanAfford(upgrade.BuyCost);
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
