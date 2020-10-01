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
            TileContainer tileContainer = mouseHelper.TileContainerForCurrentMousePosition();
            if (tileContainer?.growable != null)
            {
                GameManager.Instance.CollectGrowable(tileContainer.growable);
            }
        }
    }
}
