using UnityEngine;
using UnityEngine.UI;

public class CurrentTilePanel : MonoBehaviour
{
    public Text currentTileInformation;
    public Text terrainInformation;
    public Text growableInformation;
    public Text buildingNameInformation;
    public Text buildingDescriptionInformation;

    void OnGUI()
    {
        UIState state = UIManager.Instance.State;
        switch (state.state)
        {
            case UIState.Value.Default:
                currentTileInformation.text = "No tile selected";
                terrainInformation.enabled = false;
                growableInformation.enabled = false;
                buildingNameInformation.enabled = false;
                buildingDescriptionInformation.enabled = false;
                break;

            case UIState.Value.TileSelected:
                currentTileInformation.text = $"Selected at {state.tilePosition}";

                terrainInformation.text = $"{state.tileContainer.terrain.Name}: {state.tileContainer.terrain.FlavorText}";
                terrainInformation.enabled = true;

                if (state.tileContainer.growable != null && state.tileContainer.growable.CanCollect())
                {
                    growableInformation.text = $"Contains {state.tileContainer.growable.Entity.Name}";
                    growableInformation.enabled = true;
                }
                else
                {
                    growableInformation.enabled = false;
                }

                if (state.tileContainer.building != null)
                {
                    buildingNameInformation.text = $"Built: {state.tileContainer.building.Entity.Name}";
                    buildingDescriptionInformation.text = state.tileContainer.building.Entity.FlavorText;
                    buildingNameInformation.enabled = true;
                    buildingDescriptionInformation.enabled = true;
                }
                else
                {
                    buildingNameInformation.enabled = false;
                    buildingDescriptionInformation.enabled = false;
                }
                break;
        }
    }
}
