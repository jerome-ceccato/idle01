using UnityEngine;

public class BuildingNotificationManager : MonoBehaviour
{
    public GameObject buildingNotification;

    private void OnGUI()
    {
        buildingNotification.SetActive(ShouldShowNotification(UIManager.Instance.State));
    }

    private bool ShouldShowNotification(UIState state)
    {
        return state.state != UIState.Value.Default;
    }
}
