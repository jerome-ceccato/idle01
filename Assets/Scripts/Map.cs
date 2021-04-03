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

            LoadTile(item.Key, position, tile);
        }
        allTilemaps.ForEach(t => t.RefreshAllTiles());
    }

    private void LoadTile(Vector2Int mapPosition, Vector3Int position, TileContainer tile)
    {
        Tile ghostBuilding = GhostBuildingTile(mapPosition, tile);
        Tile ghostTerrain = GhostTerrainTile(mapPosition, tile);

        // Terrain
        if (ghostTerrain != null)
        {
            terrainTilemap.SetTile(position, ghostTerrain);
        }
        else if (tile.terrain != null)
        {
            terrainTilemap.SetTile(position, tileResources.TileForDisplayable(tile.terrain));
        }

        // Growable
        if (tile.growable?.CurrentStage != null && ghostBuilding == null)
        {
            growableTilemap.SetTile(position, tileResources.TileForDisplayable(tile.growable.CurrentStage));
        }

        // Building
        if (ghostBuilding != null)
        {
            buildingsTilemap.SetTile(position, ghostBuilding);
        }
        else if (tile.specialEntity != null)
        {
            buildingsTilemap.SetTile(position, tileResources.TileForDisplayable(tile.specialEntity));
        }
        else if (tile.building != null)
        {
            buildingsTilemap.SetTile(position, tileResources.TileForDisplayable(tile.building.Entity));
        }
    }

    private Tile GhostBuildingTile(Vector2Int mapPosition, TileContainer tile)
    {
        UIState state = UIManager.Instance.State;
        if (state.state == UIState.Value.BuildingSelected)
        {
            if (GameManager.Instance.CanBuildOnTile(tile, state.buildingEntity))
            {
                if (UIManager.Instance.HoverPosition == mapPosition)
                {
                    Color ghostBuildingColor = new Color(1, 1, 1, 0.5f);
                    return tileResources.ColoredTileForDisplayable(state.buildingEntity, ghostBuildingColor);
                }
            }
        }
        return null;
    }

    private Tile GhostTerrainTile(Vector2Int mapPosition, TileContainer tile)
    {
        UIState state = UIManager.Instance.State;
        if (state.state == UIState.Value.TerrainUpgradeSelected)
        {
            if (GameManager.Instance.CanUpgradeTerrainOnTile(tile, state.terrainUpgradeEntity))
            {
                if (UIManager.Instance.HoverPosition == mapPosition)
                {
                    float tint = 0.8f;
                    Color ghostTerrainColor = new Color(tint, tint, tint);
                    return tileResources.ColoredTileForDisplayable(state.terrainUpgradeEntity.Replacement.Entity, ghostTerrainColor);
                }
            }
        }
        return null;
    }

    void Update()
    {
        ReloadWorld(GameManager.Instance.World);
    }
}
