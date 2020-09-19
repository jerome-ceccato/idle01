using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    private Tilemap tilemap;
    private TileResources tileResources;

    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        tileResources = GetComponentInChildren<TileResources>();

        LoadLevel(GameManager.Instance.Level);
    }

    private void LoadLevel(Dictionary<Vector2Int, Terrain> level)
    {
        foreach (var item in level)
        {
            tilemap.SetTile(item.Key.To3D(), tileResources.TileForTerrain(item.Value));
        }
    
        tilemap.RefreshAllTiles();
    }
}
