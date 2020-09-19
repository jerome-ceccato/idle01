using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.Start();
    }

    void FixedUpdate()
    {
        GameManager.Instance.Tick();
    }
}
