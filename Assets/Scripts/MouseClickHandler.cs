using UnityEngine;
using System.Collections;

public class MouseClickHandler : MonoBehaviour
{
    private MouseHelper mouseHelper;

    void Start()
    {
        mouseHelper = GetComponent<MouseHelper>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2Int tileCoordinates = mouseHelper.TileCoordinateForCurrentMousePosition();
            TileContainer tileContainer = GameManager.Instance.TileContainerAtPosition(tileCoordinates);
            if (tileContainer != null)
            {
                bool isAlreadySelected = UIManager.Instance.State.state == UIState.Value.TileSelected && UIManager.Instance.State.tilePosition == tileCoordinates;
                if (isAlreadySelected)
                {
                    if (tileContainer.growable != null)
                    {
                        GameManager.Instance.CollectGrowable(tileContainer.growable);
                    }
                    else
                    {
                        UIManager.Instance.State = UIState.Default();
                    }
                }
                else
                {
                    UIManager.Instance.State = UIState.TileSelected(tileContainer, tileCoordinates);
                }
            }
        }
    }
}
