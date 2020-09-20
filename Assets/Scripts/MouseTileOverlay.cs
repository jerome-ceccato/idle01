using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseTileOverlay : MonoBehaviour
{
    private Tilemap tilemap;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        tilemap = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private Vector3Int TileCoordinateForCurrentMousePosition()
    {
        Vector3 rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixedPosition = new Vector3(rawPosition.x, rawPosition.y, 0);

        return tilemap.WorldToCell(fixedPosition);
    }

    void Update()
    {
        Vector3Int tileCoordinate = TileCoordinateForCurrentMousePosition();

        Vector3 localCoordinate = tilemap.CellToLocal(tileCoordinate);
        transform.position = localCoordinate;

        spriteRenderer.enabled = GameManager.Instance.Level.ContainsKey(tileCoordinate.To2D());
    }
}
