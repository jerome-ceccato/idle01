using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragToResizeHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject targetObject;
    public float minWidthRatio;
    public float maxWidthRatio;

    private LayoutElement layout;
    private Vector2 dragPosition;
    private float minWidth;
    private float maxWidth;
    private bool shouldResize;

    private void Start()
    {
        layout = targetObject.GetComponent<LayoutElement>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        shouldResize = eventData.button == PointerEventData.InputButton.Left;
        dragPosition = eventData.pressPosition;

        minWidth = Screen.width * minWidthRatio;
        maxWidth = Screen.width * maxWidthRatio;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (shouldResize)
        {
            float targetWidth = layout.preferredWidth + (dragPosition.x - eventData.position.x);
            layout.preferredWidth = Mathf.Max(minWidth, Mathf.Min(maxWidth, targetWidth));
            dragPosition = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        shouldResize = false;
    }
}
