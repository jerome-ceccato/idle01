using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    public float speed = 4.0f;
    private bool dragging;
    private Vector3 previousMousePosition;

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 translation = Camera.main.ScreenToViewportPoint(previousMousePosition - currentPosition) * speed;
            transform.Translate(translation);

            previousMousePosition = currentPosition;
        }
    }
}
