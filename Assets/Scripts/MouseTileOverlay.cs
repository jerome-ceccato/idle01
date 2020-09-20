using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseTileOverlay : MonoBehaviour
{
    public Tilemap tilemap;
    private SpriteRenderer spriteRenderer;
    private MouseHelper mouseHelper;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mouseHelper = GetComponent<MouseHelper>();
    }

    void Update()
    {
        transform.position = mouseHelper.LocalCoordinateForTileWithCurrentMousePosition();
        spriteRenderer.enabled = mouseHelper.TileCoordinateForCurrentMousePosition() != null;
    }
}
