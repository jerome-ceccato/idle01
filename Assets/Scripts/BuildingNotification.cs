using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuildingNotification : MonoBehaviour
{
    public Text buildingName;
    public Text cost;

    private void OnGUI()
    {
        UIState state = UIManager.Instance.State;
        switch (state.state)
        {
            case UIState.Value.Default:
                buildingName.text = "";
                cost.text = "";
                break;
            case UIState.Value.BuildingSelected:
                buildingName.text = $"Click to build {state.buildingEntity.Name}";
                cost.text = $"Costs {CostAsString(state.buildingEntity.BuildCost)}";
                break;
            case UIState.Value.TerrainUpgradeSelected:
                buildingName.text = $"Click to upgrade to {state.terrainUpgradeEntity.Name}";
                cost.text = $"Costs {CostAsString(state.terrainUpgradeEntity.BuildCost)}";
                break;
            case UIState.Value.DestoryBuildings:
                buildingName.text = "Click to destroy buildings";
                cost.text = "";
                break;
        }
    }

    private string CostAsString(BaseCost buildCost)
    {
        return string.Join(", ", buildCost.Resources.Select(r => $"{r.Amount} {r.Resource.Entity.Name}"));
    }
}
