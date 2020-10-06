using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverHandler : MonoBehaviour
{
    private MouseHelper mouseHelper;

    void Start()
    {
        mouseHelper = GetComponent<MouseHelper>();
    }

    void Update()
    {
        if (mouseHelper.IsPointerOverUIElement())
        {
            UIManager.Instance.HoverPosition = null;
        }
        else
        {
            UIManager.Instance.HoverPosition = mouseHelper.TileCoordinateForCurrentMousePosition();
        }
    }
}
