using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTilePanel : MonoBehaviour
{
    public Text currentTileInformation;
    public Text terrainInformation;
    public Text growableInformation;

    void OnGUI()
    {
        UIState state = UIManager.Instance.State;
        switch (state.state)
        {
            case UIState.Value.Default:
                currentTileInformation.text = "No tile selected";
                terrainInformation.enabled = false;
                growableInformation.enabled = false;
                break;
            case UIState.Value.TileSelected:
                currentTileInformation.text = $"Selected at {state.tilePosition}";

                terrainInformation.text = $"{state.tileContainer.terrain.DisplayName}: {state.tileContainer.terrain.FlavorText}";
                terrainInformation.enabled = true;

                if (state.tileContainer.growable?.CurrentStage != null)
                {
                    growableInformation.text = $"Contains {state.tileContainer.growable.Entity.DisplayName}";
                    growableInformation.enabled = true;
                }
                else
                {
                    growableInformation.enabled = false;
                }
                break;
        }
    }
}
