using System.Collections.Generic;
using UnityEngine;

public class InitialData
{
    public static Dictionary<Vector2Int, TileContainer> InitialWorld(DataStore store)
    {
        Dictionary<Vector2Int, TileContainer> world = new Dictionary<Vector2Int, TileContainer>();
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Vector2Int position = new Vector2Int(x, y);

                if (position == new Vector2Int(1, 1))
                {
                    world.Add(position, new TileContainer(store.Get<TerrainEntity>("grassTile"), store.Home));
                }
                else
                {
                    List<Vector2Int> grassPosition = new List<Vector2Int>
                    {
                        new Vector2Int(0, 0),
                        new Vector2Int(1, 0),
                        new Vector2Int(2, 0),
                    };
                    TerrainEntity terrain = store.Get<TerrainEntity>(grassPosition.Contains(position) ? "grassTile" : "dirtTile");
                    BuildingIncarnation building = null;
                    GrowableIncarnation growable = terrain.Growable != null && building == null ? new GrowableIncarnation(terrain.Growable.Entity) : null;

                    world.Add(position, new TileContainer(terrain, growable, building));
                }
            }
        }

        return world;
    }
}
