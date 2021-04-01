using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class OverviewContainer : MonoBehaviour
{
    private Text contentText;

    private void Start()
    {
        contentText = GetComponentInChildren<Text>();
    }

    void OnGUI()
    {
        Dictionary<ResourceEntity, BigInteger> ownedResources = GameManager.Instance.OwnedResources;

        string content = string.Join("\n", ownedResources.Select((item) =>
        {
            return $"{item.Key.Name}: {item.Value}";
        }));

        contentText.text = content;
    }
}
