using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Numerics;

public class ResourcePanel : MonoBehaviour
{
    public GameObject entryPrefab;

    private List<GameObject> existingEntries = new List<GameObject>();

    void OnGUI()
    {
        GameState state = GameManager.Instance.state;
        List<ResourceEntity> resources = new List<ResourceEntity>(state.resources.Keys);

        createEntries(resources.Count);
        for (int i = 0; i < resources.Count; i++)
        {
            GameObject entry = existingEntries[i];
            ResourceEntity resource = resources[i];
            BigInteger amount = state.resources[resource];
            Text textField = entry.GetComponentInChildren<Text>();

            textField.text = $"{resource.Id}: {amount}";
        }
    }

    private void createEntries(int number)
    {
        for (int i = existingEntries.Count; i < number; i++)
        {
            GameObject entry = Instantiate(entryPrefab, gameObject.transform);
            existingEntries.Add(entry);
        }
    }
}
