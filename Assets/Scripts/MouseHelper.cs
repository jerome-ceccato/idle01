using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseHelper : MonoBehaviour
{
    public Tilemap tilemap;

    public Vector3 LocalCoordinateForTileWithCurrentMousePosition()
    {
        Vector3 rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixedPosition = new Vector3(rawPosition.x, rawPosition.y, 0);

        Vector3Int cellPosition = tilemap.WorldToCell(fixedPosition);
        return tilemap.CellToLocal(cellPosition);
    }

    public Vector2Int TileCoordinateForCurrentMousePosition()
    {
        Vector3 rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixedPosition = new Vector3(rawPosition.x, rawPosition.y, 0);

        Vector3Int coord = tilemap.WorldToCell(fixedPosition);
        return coord.To2D();
    }

    public TileContainer TileContainerForCurrentMousePosition()
    {
        Vector2Int position = TileCoordinateForCurrentMousePosition();
        return GameManager.Instance.TileContainerAtPosition(position);
    }
}
