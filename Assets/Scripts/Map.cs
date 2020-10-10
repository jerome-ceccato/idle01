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

        ReloadWorld(GameManager.Instance.World);
    }

    private void ReloadWorld(Dictionary<Vector2Int, TileContainer> level)
    {
        // TODO: caching
        allTilemaps.ForEach(t => t.ClearAllTiles());

        if (UIManager.Instance.HoverPosition != null)
        {
            Vector2Int position = (Vector2Int)UIManager.Instance.HoverPosition;
            if (GameManager.Instance.CanPurchaseTileAtPosition(position))
            {
                terrainTilemap.SetTile(position.To3D(), tileResources.tileOutline);
            }
        }

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
            terrainTilemap.SetTile(position, tileResources.TileForDisplayable(tile.terrain));
        }

        // Growable
        if (tile.growable?.CurrentStage != null)
        {
            growableTilemap.SetTile(position, tileResources.TileForDisplayable(tile.growable.CurrentStage));
        }

        // Building
        if (tile.specialEntity != null)
        {
            buildingsTilemap.SetTile(position, tileResources.TileForDisplayable(tile.specialEntity));
        }
        else if (tile.building != null)
        {
            buildingsTilemap.SetTile(position, tileResources.TileForDisplayable(tile.building.Entity));
        }
    }

    void Update()
    {
        ReloadWorld(GameManager.Instance.World);
    }
}
