using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResourcePanel : MonoBehaviour
{
    public GameObject resourceEntryPrefab;
    private Rect entryRect;

    private List<GameObject> existingEntries;

    private void Start()
    {
        entryRect = ((RectTransform)resourceEntryPrefab.transform).rect;
        existingEntries = new List<GameObject>();
    }

    void OnGUI()
    {
        GameState state = GameManager.Instance.state;
        List<Resource> resources = new List<Resource>(state.resources.Keys);

        createEntries(resources.Count);
        for (int i = 0; i < resources.Count; i++)
        {
            GameObject entry = existingEntries[i];
            Resource resource = resources[i];
            int amount = state.resources[resource];
            Text textField = entry.GetComponentInChildren<Text>();

            textField.text = $"{resource.Id}: {amount}";
        }
    }

    private void createEntries(int number)
    {
        for (int i = existingEntries.Count; i < number; i++)
        {
            GameObject entry = Instantiate(resourceEntryPrefab, gameObject.transform);

            entry.transform.Translate(0, -(entryRect.height * i), 0);
            existingEntries.Add(entry);
        }
    }
}
