using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResources: MonoBehaviour
{
    public Tile template;
    private Dictionary<string, Tile> cache = new Dictionary<string, Tile>();
    
    public Tile TileForEntity(Entity e)
    {
        string key = e.Id;

        if (!cache.ContainsKey(key))
        {
            Tile copy = Instantiate<Tile>(template);
            copy.sprite = UnityEngine.Resources.Load<Sprite>(key);
            cache.Add(key, copy);
        }
        return cache[key];
    }
}
