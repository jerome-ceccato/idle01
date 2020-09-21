using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager
{
    public Dictionary<Vector2Int, TileContainer> Level;

    // Lifecycle

    private GameManager()
    {
        Level = new Dictionary<Vector2Int, TileContainer>();
        state = new Dictionary<Resource, int>();
    }

    public void Start() 
    {
        LoadInitialLevel();
    }

    private void LoadInitialLevel()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Terrain terrain = TerrainFactory.grassField();
                Building building = null;
                TileContainer tileContainer = new TileContainer(terrain, building);
                
                Level.Add(new Vector2Int(x, y), tileContainer);
            }
        }
    }

    // Move to state class
    private Dictionary<Resource, int> state;
    public void AddResource(Resource r, int amount)
    {
        if (!state.ContainsKey(r))
        {
            state.Add(r, 0);
        }
        state[r] += amount;
    }

    private int ticks = 0;
    public void Tick() 
    {
        ticks++;
        foreach (TileContainer container in Level.Values)
        {
            container.Tick();
        }
    }

    public string GetDebugState()
    {
        string content = $"ticks: {ticks}\n";
        foreach (var item in state)
        {
            content += $"{item.Key.Id}: {item.Value}\n";
        }
        return content;
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
