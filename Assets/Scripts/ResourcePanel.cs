using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Numerics;

public class ResourcePanel : MonoBehaviour
{
    private ListBuilder listBuilder;

    private void Start()
    {
        listBuilder = GetComponent<ListBuilder>();
    }

    void OnGUI()
    {
        GameState state = GameManager.Instance.state;
        List<ResourceEntity> resources = new List<ResourceEntity>(state.resources.Keys);

        listBuilder.UpdateNumberOfEntries(resources.Count);
        for (int i = 0; i < resources.Count; i++)
        {
            GameObject entry = listBuilder.Entries[i];
            ResourceEntity resource = resources[i];
            BigInteger amount = state.resources[resource];
            Text textField = entry.GetComponentInChildren<Text>();

            textField.text = $"{resource.DisplayName}: {amount}";
        }
    }
}
