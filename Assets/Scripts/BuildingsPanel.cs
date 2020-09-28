using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BuildingsPanel : MonoBehaviour
{
    public GameObject entryPrefab;
    private Rect entryRect;

    private List<GameObject> existingEntries = new List<GameObject>();

    private void Start()
    {
        entryRect = ((RectTransform)entryPrefab.transform).rect;
    }

    void OnGUI()
    {
    }

    private void createEntries(int number)
    {
        for (int i = existingEntries.Count; i < number; i++)
        {
            GameObject entry = Instantiate(entryPrefab, gameObject.transform);

            entry.transform.Translate(0, -(entryRect.height * i), 0);
            existingEntries.Add(entry);
        }
    }
}
