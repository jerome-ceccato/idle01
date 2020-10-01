using UnityEngine;

public static class TypeExtensions
{
    public static Vector3Int To3D(this Vector2Int v)
    {
        return new Vector3Int(v.x, v.y, 0);
    }

    public static Vector2Int To2D(this Vector3Int v)
    {
        return new Vector2Int(v.x, v.y);
    }
}
