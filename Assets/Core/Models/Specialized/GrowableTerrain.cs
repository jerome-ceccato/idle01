using UnityEngine;

public class GrowableTerrain : Terrain
{
    private GrowingResource growingResource; 

    public GrowableTerrain(string id, GrowingResource resource) : base(id)
    {
        growingResource = resource;
    }

    public override void Tick()
    {
        growingResource.Tick();
    }

    public void AquireResource()
    {
        growingResource.AquireResource();
    }

    public Entity DisplayEntity
    {
        get
        {
            return growingResource.DisplayEntity;
        }
    }
}