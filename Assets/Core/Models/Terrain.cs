using System;
public class Terrain : Entity
{
    public Terrain(string id) : base(id)
    {
    }

    public virtual void Tick() { }
}
