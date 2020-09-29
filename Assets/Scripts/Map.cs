using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap terrainTilemap;
    public Tilemap growableTilemap;
    public Tilemap buildingsTilemap;

    private List<Tilemap> allTilemaps;
    private TileResources tileResources;
    
    void Start()
    {
        tileResources = GetComponent<TileResources>();
        allTilemaps = new List<Tilemap>
        {
            terrainTilemap,
            growableTilemap,
            buildingsTilemap
        };

        ReloadLevel(GameManager.Instance.Level);
    }

    private void ReloadLevel(Dictionary<Vector2Int, TileContainer> level)
    {
        // TODO: caching
        allTilemaps.ForEach(t => t.ClearAllTiles());
        foreach (var item in level)
        {
            Vector3Int position = item.Key.To3D();
            TileContainer tile = item.Value;

            LoadTile(position, tile);
        }
        allTilemaps.ForEach(t => t.RefreshAllTiles());
    }

    private void LoadTile(Vector3Int position, TileContainer tile)
    {
        // Terrain
        if (tile.terrain != null)
        {
            terrainTilemap.SetTile(position, tileResources.TileForEntity(tile.terrain.entity));
        }

        // Growable
        if (tile.growable?.CurrentlyGrowingEntity != null)
        {
            growableTilemap.SetTile(position, tileResources.TileForEntity(tile.growable.CurrentlyGrowingEntity));
        }

        // Building
        if (tile.building != null)
        {
            buildingsTilemap.SetTile(position, tileResources.TileForEntity(tile.building.entity));
        }
    }

    void Update()
    {
        ReloadLevel(GameManager.Instance.Level);
    }
}
