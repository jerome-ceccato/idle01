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
        List<BuildingEntity> buildings = GameManager.Instance.AvailableBuildings;
        List<TerrainUpgradeEntity> terrainUpgrades = GameManager.Instance.AvailableTerrainUpgrades;

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
                string costAsString = string.Join(", ", building.BuildCost.Resources.Select(r => $"{r.Amount} {r.Resource.Entity.Name}"));
                textField.text = $"{building.Name}: {costAsString}";

                bool canBuy = GameManager.Instance.CanAfford(building);
                button.GetComponent<BuyButton>().SetEnabled(canBuy);

                button.onClick.AddListener(() => UIManager.Instance.State = UIState.BuildingSelected(building));
            }
            else if (allEntities[i] is TerrainUpgradeEntity terrainUpgrade)
            {
                string costAsString = string.Join(", ", terrainUpgrade.BuildCost.Resources.Select(r => $"{r.Amount} {r.Resource.Entity.Name}"));
                textField.text = $"{terrainUpgrade.Name}: {costAsString}";

                bool canBuy = GameManager.Instance.CanAfford(terrainUpgrade);
                button.GetComponent<BuyButton>().SetEnabled(canBuy);

                button.onClick.AddListener(() => UIManager.Instance.State = UIState.TerrainUpgradeSelected(terrainUpgrade));
            }
        }
    }
}
