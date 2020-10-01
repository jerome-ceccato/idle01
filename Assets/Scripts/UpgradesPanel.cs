using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class UpgradesPanel : MonoBehaviour
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
        GameState state = GameManager.Instance.state;

        createEntries(state.unlockedUpgrades.Count);
        for (int i = 0; i < state.unlockedUpgrades.Count; i++)
        {
            GameObject entry = existingEntries[i];
            Upgrade upgrade = state.unlockedUpgrades[i];
            Text textField = entry.GetComponentInChildren<Text>();
            Button button = entry.GetComponentInChildren<Button>();

            string costAsString = string.Join(", ", upgrade.Cost.Resources.Select(r => $"{r.Item2} {r.Item1.DisplayName}"));
            textField.text = $"{upgrade.Entity.DisplayName}: {costAsString}";

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => GameManager.Instance.BuyUpgrade(upgrade));
        }
    }

    private void createEntries(int number)
    {
        for (int i = existingEntries.Count; i < number; i++)
        {
            GameObject entry = Instantiate(entryPrefab, gameObject.transform);

            entry.transform.Translate(0, -(entryRect.height * i), 0);
            existingEntries.Add(entry);
        }

        for (int i = existingEntries.Count - 1; i >= number; i--)
        {
            Destroy(existingEntries[i]);
            existingEntries.RemoveAt(i);
        }
    }
}
