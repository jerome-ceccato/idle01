using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildingEntry : MonoBehaviour
{
    public Image iconImage;
    public Text nameLabel;
    public Text costLabel;

    public Button buyButton;

    public void Configure(BuildingEntity building)
    {
        Configure(
            building.Name,
            building.BuildCost,
            GameManager.Instance.CanAfford(building),
            GameManager.Instance.AvailableTilesForBuilding(building),
            () => UIManager.Instance.State = UIState.BuildingSelected(building)
        );
    }

    public void Configure(TerrainUpgradeEntity terrainUpgrade)
    {
        Configure(
            terrainUpgrade.Name,
            terrainUpgrade.BuildCost,
            GameManager.Instance.CanAfford(terrainUpgrade),
            GameManager.Instance.AvailableTilesForTerrainUpgrade(terrainUpgrade),
            () => UIManager.Instance.State = UIState.TerrainUpgradeSelected(terrainUpgrade)
        );
    }

    private void Configure(
        string name, 
        BaseCost cost, 
        bool canBuy,
        int availableTiles,
        UnityAction clickAction
        )
    {
        nameLabel.text = name;
        costLabel.text = CostAsString(cost);

        buyButton.GetComponent<BuyButton>().SetEnabled(canBuy && availableTiles > 0);

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(clickAction);
    }

    private string CostAsString(BaseCost buildCost)
    {
        return string.Join(", ", buildCost.Resources.Select(r => $"{r.Amount} {r.Resource.Entity.Name}"));
    }
}
