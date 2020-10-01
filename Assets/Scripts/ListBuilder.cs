using UnityEngine;
using System.Collections.Generic;

public class ListBuilder : MonoBehaviour
{
    public GameObject entryPrefab;
    private Rect entryRect;

    private List<GameObject> entries = new List<GameObject>();
    public List<GameObject> Entries
    {
        get
        {
            return entries;
        }
    }

    private void Start()
    {
        entryRect = ((RectTransform)entryPrefab.transform).rect;
    }

    public void UpdateNumberOfEntries(int number)
    {
        for (int i = entries.Count; i < number; i++)
        {
            GameObject entry = Instantiate(entryPrefab, gameObject.transform);

            entry.transform.Translate(0, -(entryRect.height * i), 0);
            entries.Add(entry);
        }

        for (int i = entries.Count - 1; i >= number; i--)
        {
            Destroy(entries[i]);
            entries.RemoveAt(i);
        }
    }
}
