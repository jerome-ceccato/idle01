using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap terrainTilemap;
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

            terrainTilemap.SetTile(position, tileResources.TileForEntity(tile.terrain));
        }
    
        terrainTilemap.RefreshAllTiles();
        UpdateBuildings(level);
    }

    private void UpdateBuildings(Dictionary<Vector2Int, TileContainer> level)
    {
        buildingsTilemap.ClearAllTiles();
        foreach (var item in level)
        {
            Vector3Int position = item.Key.To3D();
            TileContainer tile = item.Value;

            if (tile.building != null)
            {
                buildingsTilemap.SetTile(position, tileResources.TileForEntity(tile.building));
            }
            else if (tile.terrain is GrowableTerrain)
            {
                GrowableTerrain terrain = (GrowableTerrain)tile.terrain;
                if (terrain.DisplayEntity?.Id != null)
                {
                    buildingsTilemap.SetTile(position, tileResources.TileForEntity(terrain.DisplayEntity));
                }
                
            }
        }
        buildingsTilemap.RefreshAllTiles();
    }

    void Update()
    {
        UpdateBuildings(GameManager.Instance.Level);
    }
}
