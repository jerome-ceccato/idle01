using UnityEngine;

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
                        if (GameManager.Instance.Build(UIManager.Instance.State.buildingEntity, tileContainer))
                        {
                            UIManager.Instance.State = UIState.Default();
                        }
                        break;
                    case UIState.Value.TerrainUpgradeSelected:
                        if (GameManager.Instance.Build(UIManager.Instance.State.terrainUpgradeEntity, tileContainer))
                        {
                            UIManager.Instance.State = UIState.Default();
                        }
                        break;
                    case UIState.Value.DestoryBuildings:
                        if (GameManager.Instance.DestroyBuilding(tileContainer))
                        {
                            UIManager.Instance.State = UIState.Default();
                        }
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
        else if (mouseHelper.DidRightClickOverGame())
        {
            UIManager.Instance.State = UIState.Default();
        }
    }
}
