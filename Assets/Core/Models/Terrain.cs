using System;
public class Terrain : Entity
{
    // nullable
    public TileResource tileResource;

    public Terrain(string id) : base(id)
    {
        tileResource = null;
    }

    public virtual void Tick() { }
    public virtual void AquireResource() { }
}
