using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap terrainTilemap;
    public Tilemap growableTilemap;
    public Tilemap buildingsTilemap;
    
    private TileResources tileResources;
    
    void Start()
    {
        tileResources = GetComponent<TileResources>();

        LoadLevel(GameManager.Instance.Level);
    }

    private void LoadLevel(Dictionary<Vector2Int, TileContainer> level)
    {
        foreach (var item in level)
        {
            Vector3Int position = item.Key.To3D();
            TileContainer tile = item.Value;

            terrainTilemap.SetTile(position, tileResources.TileForEntity(tile.terrain.entity));
        }
    
        terrainTilemap.RefreshAllTiles();
        UpdateBuildings(level);
    }

    private void UpdateBuildings(Dictionary<Vector2Int, TileContainer> level)
    {
        growableTilemap.ClearAllTiles();
        buildingsTilemap.ClearAllTiles();
        foreach (var item in level)
        {
            Vector3Int position = item.Key.To3D();
            TileContainer tile = item.Value;

            if (tile.terrain is GrowableTerrain)
            {
                GrowableTerrain terrain = (GrowableTerrain)tile.terrain;
                if (terrain.CurrentlyGrowingEntity?.Id != null)
                {
                    growableTilemap.SetTile(position, tileResources.TileForEntity(terrain.CurrentlyGrowingEntity));
                }

            }

            if (tile.building != null)
            {
                buildingsTilemap.SetTile(position, tileResources.TileForEntity(tile.building.entity));
            }
        }
        growableTilemap.RefreshAllTiles();
        buildingsTilemap.RefreshAllTiles();
    }

    void Update()
    {
        UpdateBuildings(GameManager.Instance.Level);
    }
}
