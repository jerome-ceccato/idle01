using System.Collections.Generic;
using UnityEngine;

public class DataStore
{
    private Dictionary<string, Entity> allEntities;

    public List<ResourceEntity> Resources { get; private set; }
    public List<TerrainEntity> Terrains { get; private set; }
    public List<BuildingEntity> Buildings { get; private set; }
    public List<UpgradeEntity> Upgrades { get; private set; }
    public List<GrowableEntity> Growables { get; private set; }
    public List<TerrainUpgradeEntity> TerrainUpgrades { get; private set; }

    private DataStore() { }

    public void Load(GameDataCatalogue catalogue)
    {
        DataLoader loader = new DataLoader();
        allEntities = new Dictionary<string, Entity>();

        Resources = LoadEntityType<ResourceEntity>(loader, catalogue.resources);
        Terrains = LoadEntityType<TerrainEntity>(loader, catalogue.terrains);
        Buildings = LoadEntityType<BuildingEntity>(loader, catalogue.buildings);
        Upgrades = LoadEntityType<UpgradeEntity>(loader, catalogue.upgrades);
        Growables = LoadEntityType<GrowableEntity>(loader, catalogue.growables);
        TerrainUpgrades = LoadEntityType<TerrainUpgradeEntity>(loader, catalogue.terrainUpgrades);
    }

    private List<T> LoadEntityType<T>(DataLoader loader, TextAsset asset) where T : Entity
    {
        List<T> content = loader.Load<T>(asset);
        foreach (T item in content)
        {
            allEntities.Add(item.Id, item);
        }
        return content;
    }

    public T Get<T>(string id) where T : Entity
    {
        return (T)allEntities[id];
    }

    // Singleton boilerplate

    private static readonly object padlock = new object();
    private static DataStore instance = null;
    public static DataStore Shared
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new DataStore();
                }
                return instance;
            }
        }
    }
}
