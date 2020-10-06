using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWheelZooming : MonoBehaviour
{
    public Camera target;
   
    void Update()
    {
        float wheelOffset = Input.GetAxis("Mouse ScrollWheel");
        if (wheelOffset != 0.0)
        {
            const float lowerBound = 0.1f;
            const float higherBound = 10.0f;

            float newValue = target.orthographicSize - (target.orthographicSize * wheelOffset);
            target.orthographicSize = Mathf.Min(higherBound, Mathf.Max(lowerBound, newValue));
        }
    }
}
