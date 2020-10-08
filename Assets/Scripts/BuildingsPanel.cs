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
            List<TerrainUpgradeEntity> terrainUpgrades = GameManager.Instance.AvailableTerrainUpgradesForTile(selectedTile);

            List<Entity> allEntities = new List<Entity>(buildings);
            allEntities.AddRange(terrainUpgrades);

            listBuilder.UpdateNumberOfEntries(allEntities.Count);
            for (int i = 0; i < allEntities.Count; i++)
            {
                GameObject entry = listBuilder.Entries[i];
                Text textField = entry.GetComponentInChildren<Text>();
                Button button = entry.GetComponentInChildren<Button>();

                button.onClick.RemoveAllListeners();

                if (allEntities[i] is BuildingEntity building)
                {
                    string costAsString = string.Join(", ", building.BuildCost.Resources.Select(r => $"{r.Amount} {r.Resource.Entity.DisplayName}"));
                    textField.text = $"{building.DisplayName}: {costAsString}";

                    bool canBuy = GameManager.Instance.CanAfford(building);
                    button.GetComponent<BuyButton>().SetEnabled(canBuy);

                    button.onClick.AddListener(() => GameManager.Instance.Build(building, selectedTile));
                }
                else if (allEntities[i] is TerrainUpgradeEntity terrainUpgrade)
                {
                    string costAsString = string.Join(", ", terrainUpgrade.BuildCost.Resources.Select(r => $"{r.Amount} {r.Resource.Entity.DisplayName}"));
                    textField.text = $"{terrainUpgrade.DisplayName}: {costAsString}";

                    bool canBuy = GameManager.Instance.CanAfford(terrainUpgrade);
                    button.GetComponent<BuyButton>().SetEnabled(canBuy);

                    button.onClick.AddListener(() => GameManager.Instance.Build(terrainUpgrade, selectedTile));
                }
            }
        }
        else
        {
            listBuilder.UpdateNumberOfEntries(0);
        }
    }
}
