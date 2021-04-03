using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{
    public Button destroyBuildingButton;
    
    void Start()
    {
        destroyBuildingButton.onClick.AddListener(() => UIManager.Instance.State = UIState.DestoryBuildings());   
    }
}
