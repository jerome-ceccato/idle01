using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager
{
    public GameState state;
    public Dictionary<Vector2Int, TileContainer> Level;

    // Lifecycle

    private GameManager()
    {
        Level = new Dictionary<Vector2Int, TileContainer>();
        state = new GameState();
    }

    public void Start() 
    {
        LoadInitialLevel();
    }

    private void LoadInitialLevel()
    {
        for (int x = 0; x < 1; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                Terrain terrain = TerrainFactory.grassField();
                Building building = null;
                TileContainer tileContainer = new TileContainer(terrain, building);
                
                Level.Add(new Vector2Int(x, y), tileContainer);
            }
        }
    }

    public void AddResource(ResourceEntity r, int amount)
    {
        if (!state.resources.ContainsKey(r))
        {
            state.resources.Add(r, 0);
        }
        state.resources[r] += amount;
    }

    public void Tick() 
    {
        foreach (TileContainer container in Level.Values)
        {
            container.Tick();
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
