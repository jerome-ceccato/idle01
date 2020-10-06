using UnityEngine;
using System.Collections;

public class UIManager
{
    public UIState State { get; set; }
    public Vector2Int? HoverPosition { get; set; }

    private UIManager() 
    {
        State = UIState.Default();
        HoverPosition = null;
    }  

    // Singleton boilerplate

    private static readonly object padlock = new object();
    private static UIManager instance = null;
    public static UIManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new UIManager();
                }
                return instance;
            }
        }
    }
}
