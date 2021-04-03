using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResources: MonoBehaviour
{
    public Tile tileOutline;

    public Tile template;
    private Dictionary<string, Tile> cache = new Dictionary<string, Tile>();
    
    public Tile TileForDisplayable(IDisplayable e)
    {
        string key = e.SpriteId;

        if (!cache.ContainsKey(key))
        {
            Tile copy = Instantiate(template);
            copy.sprite = Resources.Load<Sprite>(key);
            cache.Add(key, copy);
        }
        return cache[key];
    }

    public Tile ColoredTileForDisplayable(IDisplayable e, Color color)
    {
        string spriteKey = e.SpriteId;
        string key = $"{spriteKey}-{color}";

        if (!cache.ContainsKey(key))
        {
            Tile copy = Instantiate(template);
            copy.sprite = Resources.Load<Sprite>(spriteKey);
            copy.color = color;
            cache.Add(key, copy);
        }
        return cache[key];
    }
}
