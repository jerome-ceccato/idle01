using UnityEngine;
using System.Collections.Generic;

public class MouseClickHandler : MonoBehaviour
{
    private MouseHelper mouseHelper;
    
    void Start()
    {
        mouseHelper = GetComponent<MouseHelper>();
    }

    void Update()
    {
        if (mouseHelper.DidClickOnGame())
        {
            Vector2Int tileCoordinates = mouseHelper.TileCoordinateForCurrentMousePosition();
            TileContainer tileContainer = GameManager.Instance.TileContainerAtPosition(tileCoordinates);
            if (tileContainer != null)
            {
                switch (UIManager.Instance.State.state)
                {
                    case UIState.Value.BuildingSelected:
                        GameManager.Instance.Build(UIManager.Instance.State.buildingEntity, tileContainer);
                        break;
                    case UIState.Value.TerrainUpgradeSelected:
                        GameManager.Instance.Build(UIManager.Instance.State.terrainUpgradeEntity, tileContainer);
                        break;
                    case UIState.Value.Default:
                        if (tileContainer.growable != null)
                        {
                            GameManager.Instance.CollectGrowable(tileContainer.growable);
                        }
                        break;

                }
            }
            else
            {
                UIManager.Instance.State = UIState.Default();
            }    
        }
    }
}
