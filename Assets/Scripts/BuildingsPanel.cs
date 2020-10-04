using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class BuildingsPanel : MonoBehaviour
{
    private ListBuilder listBuilder;

    private void Start()
    {
        listBuilder = GetComponent<ListBuilder>();
    }

    void OnGUI()
    {
        if (UIManager.Instance.State.state == UIState.Value.TileSelected)
        {
            TileContainer selectedTile = UIManager.Instance.State.tileContainer;
            List<BuildingEntity> buildings = GameManager.Instance.AvailableBuildingsForTile(selectedTile);

            listBuilder.UpdateNumberOfEntries(buildings.Count);
            for (int i = 0; i < buildings.Count; i++)
            {
                GameObject entry = listBuilder.Entries[i];
                BuildingEntity building = buildings[i];
                Text textField = entry.GetComponentInChildren<Text>();
                Button button = entry.GetComponentInChildren<Button>();

                string costAsString = string.Join(", ", building.BuildCost.Resources.Select(r => $"{r.Amount} {r.Resource.DisplayName}"));
                textField.text = $"{building.DisplayName}: {costAsString}";

                bool canBuy = GameManager.Instance.CanAfford(building);
                button.GetComponent<BuyButton>().SetEnabled(canBuy);

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => GameManager.Instance.Build(building, selectedTile));
            }
        }
        else
        {
            listBuilder.UpdateNumberOfEntries(0);
        }
    }
}
