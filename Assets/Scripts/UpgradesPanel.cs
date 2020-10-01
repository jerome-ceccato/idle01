using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class UpgradesPanel : MonoBehaviour
{
    private ListBuilder listBuilder;

    private void Start()
    {
        listBuilder = GetComponent<ListBuilder>();
    }

    void OnGUI()
    {
        GameState state = GameManager.Instance.state;

        listBuilder.UpdateNumberOfEntries(state.unlockedUpgrades.Count);
        for (int i = 0; i < state.unlockedUpgrades.Count; i++)
        {
            GameObject entry = listBuilder.Entries[i];
            Upgrade upgrade = state.unlockedUpgrades[i];
            Text textField = entry.GetComponentInChildren<Text>();
            Button button = entry.GetComponentInChildren<Button>();

            string costAsString = string.Join(", ", upgrade.Cost.Resources.Select(r => $"{r.Item2} {r.Item1.DisplayName}"));
            textField.text = $"{upgrade.Entity.DisplayName}: {costAsString}";

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => GameManager.Instance.BuyUpgrade(upgrade));
        }
    }
}
