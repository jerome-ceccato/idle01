using System.Collections.Generic;

// The resources needed to buy an entity
public class BaseCost
{
    public List<Generator> Resources { get; private set; }

    public BaseCost(List<Generator> resources)
    {
        Resources = resources;
    }

    public BaseCost(Generator generator)
    {
        Resources = new List<Generator> { generator };
    }
}
