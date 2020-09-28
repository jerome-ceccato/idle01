using UnityEngine;

public class GrowableTerrain : Terrain
{
    private GrowingResource growingResource; 

    public GrowableTerrain(TerrainEntity entity, GrowingResource resource) : base(entity)
    {
        growingResource = resource;
    }

    public override void Tick()
    {
        growingResource.Tick();
    }

    public void CollectResource()
    {
        growingResource.CollectResource();
    }

    public GrowableEntity CurrentlyGrowingEntity
    {
        get
        {
            return growingResource.CurrentlyGrowingEntity;
        }
    }
}