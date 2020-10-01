using UnityEngine;
using UnityEngine.UI;

public class BuyButton: MonoBehaviour
{
    private Image backgroundImage;
    private Text contentText;

    public Color enabledColor;
    public Color disabledColor;

    void Start()
    {
        backgroundImage = GetComponent<Image>();
        contentText = GetComponentInChildren<Text>();
    }

    public void SetEnabled(bool enabled)
    {
        if (backgroundImage != null)
        {
            backgroundImage.color = enabled ? enabledColor : disabledColor;
        }
        if (contentText != null)
        {
            contentText.text = enabled ? "Buy" : "Can't buy";
        }
    }
}
