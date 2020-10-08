using UnityEngine;

public class Main : MonoBehaviour
{
    public TextAsset resourcesFile;

    void Start()
    {
        _ = new DataLoader(resourcesFile.text);
        GameManager.Instance.Start();
    }

    void FixedUpdate()
    {
        GameManager.Instance.Tick();
    }
}
