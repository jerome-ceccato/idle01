using System.Numerics;

// An identifiable object representing a resource with an amount
public class Generator : Identifiable
{
    public string Id { get; private set; }

    public ResourceEntity Resource { get; private set; }

    public BigInteger Amount { get; private set; }

    public Generator(string id, ResourceEntity resource, BigInteger amount)
    {
        Id = id;
        Resource = resource;
        Amount = amount;
    }
}
