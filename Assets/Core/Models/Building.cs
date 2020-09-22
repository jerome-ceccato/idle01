using System;
public class Building : Entity
{
    public Building(string id) : base(id)
    {
        
    }

    public virtual void Tick() { }
}
