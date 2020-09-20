using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap terrainTilemap;
    public Tilemap buildingsTilemap;
    
    private TileResources tileResources;
    private Text textField;
    private MouseHelper mouseHelper;

    void Start()
    {
        tileResources = GetComponent<TileResources>();
        textField = GameObject.Find("Text field").GetComponent<Text>();
        mouseHelper = GetComponent<MouseHelper>();

        LoadLevel(GameManager.Instance.Level);
    }

    private void LoadLevel(Dictionary<Vector2Int, Terrain> level)
    {
        foreach (var item in level)
        {
            terrainTilemap.SetTile(item.Key.To3D(), tileResources.TileForTerrain(item.Value));
        }
    
        terrainTilemap.RefreshAllTiles();

        buildingsTilemap.SetTile(new Vector3Int(2, 0, 0), tileResources.wheat);
        buildingsTilemap.RefreshAllTiles();
    }

    void Update()
    {
        string content = "";
        Vector2Int? hoveredTile = mouseHelper.TileCoordinateForCurrentMousePosition();

        content += hoveredTile != null ? $"Hover: {hoveredTile}\n" : "No hover\n";
        content += GameManager.Instance.GetDebugState();
        textField.text = content;
    }
}
