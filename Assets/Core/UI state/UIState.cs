using UnityEngine;
using System.Collections;

public class UIState
{
    public enum Value
    {
        Default,
        TileSelected
    }

    public readonly Value state;
    // Only available in TileSelected
    public readonly TileContainer tileContainer;
    public readonly Vector2Int tilePosition;

    private UIState(Value v, TileContainer container, Vector2Int position)
    {
        state = v;
        tileContainer = container;
        tilePosition = position;
    }

    public static UIState Default()
    {
        return new UIState(Value.Default, null, new Vector2Int());
    }

    public static UIState TileSelected(TileContainer container, Vector2Int tilePosition)
    {
        return new UIState(Value.TileSelected, container, tilePosition);
    }
}
