using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    private Tilemap tilemap;
    private TileResources tileResources;

    private Text textField;

    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        tileResources = GetComponentInChildren<TileResources>();
        textField = GameObject.Find("Text field").GetComponent<Text>();

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

    private void FixedUpdate()
    {
        textField.text = GameManager.Instance.GetDebugState();
    }
}
