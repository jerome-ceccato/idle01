using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelectionOverlay : MonoBehaviour
{
    public Tilemap tilemap;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        switch (UIManager.Instance.State.state)
        {
            case UIState.Value.Default:
                spriteRenderer.enabled = false;
                break;
            case UIState.Value.TileSelected:
                transform.position = tilemap.CellToWorld(UIManager.Instance.State.tilePosition.To3D());
                spriteRenderer.enabled = true;
                break;
        }
    }
}
