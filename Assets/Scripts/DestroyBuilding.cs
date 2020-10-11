using UnityEngine;
using UnityEngine.UI;

public class DestroyBuilding : MonoBehaviour
{
    private Text contentText;
    private Button button;
    private CanvasGroup canvasGroup;

    void Start()
    {
        contentText = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        canvasGroup = GetComponent<CanvasGroup>();
        button.onClick.AddListener(() => OnClick());
    }

    void OnGUI()
    {
        if (UIManager.Instance.State.state == UIState.Value.TileSelected)
        {
            TileContainer selectedTile = UIManager.Instance.State.tileContainer;
            if (selectedTile.building != null)
            {
                canvasGroup.alpha = 1;
                contentText.text = $"Destroy {selectedTile.building.Entity.Name}";
            }
            else
            {
                canvasGroup.alpha = 0;
            }
        }
        else
        {
            canvasGroup.alpha = 0;
        }
    }

    private void OnClick()
    {
        if (UIManager.Instance.State.state == UIState.Value.TileSelected)
        {
            GameManager.Instance.DestroyBuilding(UIManager.Instance.State.tileContainer);
        }
    }
}