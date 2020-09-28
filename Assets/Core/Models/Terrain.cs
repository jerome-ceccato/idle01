using System;
public class Terrain : Entity
{
    public Terrain(string id) : base("Terrain/" + id)
    {
    }

    public virtual void Tick() { }
}
