using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    private int convertionRate = 280;
    private bool dragging;
    private Vector3 previousMousePosition;

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragging = true;
            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector3 currentPosition = Input.mousePosition;
            transform.Translate((previousMousePosition - currentPosition) / convertionRate);
            previousMousePosition = currentPosition;
        }
    }
}
