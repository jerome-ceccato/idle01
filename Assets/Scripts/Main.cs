using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        DataStore.Shared.Load(GetComponent<GameDataCatalogue>());
        GameManager.Instance.Start();
    }

    void FixedUpdate()
    {
        GameManager.Instance.Tick();
    }
}
