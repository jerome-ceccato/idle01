using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager
{
    public Dictionary<Vector2Int, Terrain> Level;

    // Lifecycle

    private GameManager()
    {
        Level = new Dictionary<Vector2Int, Terrain>();
    }

    public void Start() 
    {
        LoadLevel();
    }
    private void LoadLevel()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Terrain type = x == y && x == 1 ? Terrain.GrassWithStones : Terrain.Grass;
                Level.Add(new Vector2Int(x, y), type);
            }
        }
    }

    private int ticks = 0;
    public void Tick() 
    {
        ticks++;
    }
    public string GetDebugState()
    {
        return $"ticks: {ticks}";
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
