using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

public class ResourcePanel : MonoBehaviour
{
    private Text contentText;

    private void Start()
    {
        contentText = GetComponentInChildren<Text>();
    }

    void OnGUI()
    {
        Dictionary<ResourceEntity, BigInteger> ownedResources = GameManager.Instance.OwnedResources;

        string content = string.Join(", ", ownedResources.Select((item) =>
        {
            return $"{item.Key.DisplayName}: {item.Value}";
        }));

        contentText.text = content;
    }
}
