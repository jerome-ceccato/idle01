using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    private Tilemap tilemap;
    private TileFactory tileFactory;

    void Start()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        tileFactory = GetComponentInChildren<TileFactory>();

        LoadLevel(new Vector2Int(3, 3));
    }

    private void LoadLevel(Vector2Int size)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Tile tile = Random.Range(0, 2) == 0 ? tileFactory.grass : tileFactory.grassWithStones;
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }

        tilemap.RefreshAllTiles();
    }
}
