using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragToResizeHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject targetObject;
    public GameObject bottomObject;
    public float minWidthRatio;
    public float maxWidthRatio;

    private LayoutElement layout;
    private RectTransform bottomTransform;
    private Vector2 dragPosition;
    private float minWidth;
    private float maxWidth;
    private bool shouldResize;

    private void Start()
    {
        layout = targetObject.GetComponent<LayoutElement>();
        bottomTransform = bottomObject.GetComponent<RectTransform>();
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
            float finalWidth = Mathf.Max(minWidth, Mathf.Min(maxWidth, targetWidth));
            layout.preferredWidth = finalWidth;
            bottomTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, finalWidth, Screen.width - finalWidth);
            dragPosition = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        shouldResize = false;
    }
}
