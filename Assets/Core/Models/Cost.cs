using System.Collections.Generic;
using System.Numerics;

public class Cost
{
    public List<(ResourceEntity, BigInteger)> Resources { get; private set; }

    public Cost(ResourceEntity resource, BigInteger amount)
    {
        Resources = new List<(ResourceEntity, BigInteger)>
        {
            (resource, amount)
        };
    }

    public Cost(List<(ResourceEntity, BigInteger)> resources)
    {
        Resources = resources;
    }
}
