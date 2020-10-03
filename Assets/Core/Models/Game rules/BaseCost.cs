using System.Collections.Generic;

public class BaseCost
{
    public List<Generator> Resources { get; private set; }

    public BaseCost(List<Generator> resources)
    {
        Resources = resources;
    }
}
