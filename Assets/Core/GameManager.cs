using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class GameManager
{
    public GameState state;
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
                GrowableGroup growable = (x == 1 && y == 1) ? Growables.Wheat() : null;
                BuildingEntity building = null;
                state.world.Add(new Vector2Int(x, y), new TileContainer(terrain, growable, building));
            }
        }
    }

    public void Tick() 
    {
        // tmp

    
            foreach (TileContainer tile in state.world.Values)
            {
            if (tile.growable != null)
            {
                if (Random.Range(0, 10) == 1)
                {
                    tile.growable.Grow();
                }
            }
                
            }
        
    }

    public void CollectGrowable(GrowableGroup growable)
    {
        if (growable.CanCollect())
        {
            Multiplier multiplier = rules.MultiplierForGrowable(growable);
            BigInteger amount = multiplier.Apply(new BigInteger(1));
            state.AddResource(growable.GrownResource, amount);
            growable.Reset();
        }
    }

    public void BuyUpgrade(Upgrade upgrade)
    {
        if (state.CanAfford(upgrade.Cost))
        {
            state.UnlockUpgrade(upgrade);
        }
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
