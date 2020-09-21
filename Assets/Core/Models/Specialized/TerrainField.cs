using UnityEngine;

public class TerrainField : Terrain
{
    private int growthChance;
    private TileResource growingResource;

    public TerrainField(string id, int growthChance, TileResource resource) : base(id)
    {
        this.growthChance = growthChance;
        growingResource = resource;
    }

    public override void Tick()
    {
        if (tileResource == null)
        {
            if (Random.Range(0, growthChance) == 0)
            {
                tileResource = growingResource;
            }
        }
    }
}
