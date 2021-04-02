using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public sealed class GameManager
{
    private GameState state;
    private GameRules rules;

    private ResolvedMultipliers resolvedMultipliers;

    // Lifecycle

    private GameManager()
    {
        state = new GameState();
        rules = new GameRules(state);
    }

    public void Start()
    {
        DataStore store = DataStore.Shared;

        state.world = InitialData.InitialWorld(store);
        state.resources = InitialData.InitialResources(store);
    }

    public void Tick() 
    {
        resolvedMultipliers = new ResolvedMultipliers(rules);
        // TODO: improve
        foreach (TileContainer tile in state.world.Values)
        {
            if (tile.specialEntity == null)
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

        ProcessUnlocks();
    }

    private void TickBuilding(TileContainer tile)
    {
        if (tile.building.Entity.Effect is BuildingEffectGenerator generator)
        {
            state.TryGenerate(generator, resolvedMultipliers);
        }
        else if (tile.building.Entity.Effect is BuildingEffectHarvester)
        {
            if (tile.growable != null)
            {
                CollectGrowable(tile.growable);
            }
            
        }
    }

    private void ProcessUnlocks()
    {
        foreach (UpgradeEntity upgrade in new List<UpgradeEntity>(state.otherUpgrades))
        {
            if (state.CanUnlock(upgrade.UnlockRule))
            {
                state.Unlock(upgrade);
            }
        }

        foreach (BuildingEntity building in new List<BuildingEntity>(state.otherBuildings))
        {
            if (state.CanUnlock(building.UnlockRule))
            {
                state.Unlock(building);
            }
        }

        foreach (TerrainUpgradeEntity upgrade in new List<TerrainUpgradeEntity>(state.otherTerrainUpgrades))
        {
            if (state.CanUnlock(upgrade.UnlockRule))
            {
                state.Unlock(upgrade);
            }
        }
    }

    public void CollectGrowable(GrowableIncarnation growable)
    {
        if (growable.CanCollect())
        {
            IMultiplier multiplier = rules.ActiveFinalMultiplierForIdentifiable(growable.Entity);
            BigInteger amount = multiplier.Apply(growable.Entity.GrownResource.Amount);
            state.AddResource(growable.Entity.GrownResource.Resource.Entity, amount);
            growable.Reset();
        }
    }

    public void BuyUpgrade(UpgradeEntity upgrade)
    {
        state.TryUnlockUpgrade(upgrade, resolvedMultipliers);
    }

    public bool Build(BuildingEntity building, TileContainer tileContainer)
    {
        return state.TryBuild(building, resolvedMultipliers, tileContainer);
    }

    public bool Build(TerrainUpgradeEntity terrainUpgrade, TileContainer tileContainer)
    {
        return state.TryBuild(terrainUpgrade, resolvedMultipliers, tileContainer);
    }

    public void DestroyBuilding(TileContainer tile)
    {
        tile.building = null;
        if (tile.terrain.Growable != null)
        {
            tile.growable = new GrowableIncarnation(tile.terrain.Growable.Entity);
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

    public List<TerrainUpgradeEntity> AvailableTerrainUpgrades
    {
        get
        {
            return state.unlockedTerrainUpgrades;
        }
    }

    public List<BuildingEntity> AvailableBuildingsForTile(TileContainer tile)
    {
        return AvailableBuildings.FindAll(building => CanBuildOnTile(tile, building));
    }

    public List<TerrainUpgradeEntity> AvailableTerrainUpgradesForTile(TileContainer tile)
    {
        return state.unlockedTerrainUpgrades.FindAll(upgrade => CanUpgradeTerrainOnTile(tile, upgrade));
    }

    private bool CanBuildOnTile(TileContainer tile, BuildingEntity entity)
    {
        if (tile.specialEntity != null)
        {
            return false;
        }

        if (entity.BuildRule.PreviousBuilding != null)
        {
            return entity.BuildRule.PreviousBuilding.Entity == tile.building?.Entity;
        }
        else if (tile.building != null)
        {
            return false;
        }

        return entity.BuildRule.PossibleTerrains == null || entity.BuildRule.PossibleTerrains.Contains(tile.terrain.Id);       
    }

    private bool CanUpgradeTerrainOnTile(TileContainer tile, TerrainUpgradeEntity entity)
    {
        return tile.specialEntity == null && tile.building == null && entity.Target.Entity == tile.terrain;
    }

    public bool CanAfford(UpgradeEntity upgrade)
    {
        return state.CanAfford(upgrade, resolvedMultipliers);
    }

    public bool CanAfford(BuildingEntity building)
    {
        return state.CanAfford(building, resolvedMultipliers);
    }

    public bool CanAfford(TerrainUpgradeEntity terrainUpgrade)
    {
        return state.CanAfford(terrainUpgrade, resolvedMultipliers);
    }

    public bool CanPurchaseTileAtPosition(Vector2Int position)
    {
        return !state.world.ContainsKey(position) && state.HasAdjacentTile(position);
    }

    public HomeSpecialEntity GetHomeEntity()
    {
        return DataStore.Shared.Home;
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
