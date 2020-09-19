using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    private Tilemap tilemap;
    private TileResources tileResources;

    private int gold = 0;
    private UnityEngine.UI.Text goldText;

    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        tileResources = GetComponentInChildren<TileResources>();
        goldText = GameObject.FindGameObjectWithTag("UI").GetComponent<UnityEngine.UI.Text>();

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
        gold++;
        goldText.text = $"Gold: {gold}";
    }
}
