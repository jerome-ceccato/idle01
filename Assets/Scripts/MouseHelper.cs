using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

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

    public bool DidClickOnGame()
    {
        return Input.GetMouseButtonDown(0) && !IsPointerOverUIElement();
    }

    public bool DidRightClickOverGame()
    {
        return Input.GetMouseButtonDown(1) && !IsPointerOverUIElement();
    }

    public bool DidClickOnUI()
    {
        return Input.GetMouseButtonDown(0) && IsPointerOverUIElement();
    }

    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }

    private static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                return true;
        }
        return false;
    }

    private static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }
}
