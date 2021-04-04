using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuildingEntry : MonoBehaviour
{
    public Image iconImage;
    public Text nameLabel;
    public Text costLabel;

    public Button buyButton;

    public void Configure(BuildingEntity building)
    {
        nameLabel.text = building.Name;
        costLabel.text = CostAsString(building.BuildCost);

        bool canBuy = GameManager.Instance.CanAfford(building);
        buyButton.GetComponent<BuyButton>().SetEnabled(canBuy);

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(() => UIManager.Instance.State = UIState.BuildingSelected(building));
    }

    public void Configure(TerrainUpgradeEntity terrainUpgrade)
    {
        nameLabel.text = terrainUpgrade.Name;
        costLabel.text = CostAsString(terrainUpgrade.BuildCost);

        bool canBuy = GameManager.Instance.CanAfford(terrainUpgrade);
        buyButton.GetComponent<BuyButton>().SetEnabled(canBuy);

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(() => UIManager.Instance.State = UIState.TerrainUpgradeSelected(terrainUpgrade));
    }

    private string CostAsString(BaseCost buildCost)
    {
        return string.Join(", ", buildCost.Resources.Select(r => $"{r.Amount} {r.Resource.Entity.Name}"));
    }
}
