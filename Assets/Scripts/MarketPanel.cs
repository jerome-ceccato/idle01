using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketPanel : MonoBehaviour
{
    private ListBuilder listBuilder;

    private void Start()
    {
        listBuilder = GetComponent<ListBuilder>();
    }

    void OnGUI()
    {
        HomeSpecialEntity home = GameManager.Instance.GetHomeEntity();
        List<MarketEntry> marketEntries = home.AvailableMarketEntries();

        listBuilder.UpdateNumberOfEntries(marketEntries.Count);
        for (int i = 0; i < marketEntries.Count; i++)
        {
            GameObject entry = listBuilder.Entries[i];
            MarketEntry marketEntry = marketEntries[i];

            Text textField = entry.GetComponentInChildren<Text>();
            Toggle toggle = entry.GetComponentInChildren<Toggle>();

            textField.text = $"Sell {marketEntry.Resource.Entity.Name}";
            toggle.isOn = marketEntry.Active;

            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener(value => marketEntry.Active = value);
        }
    }
}
