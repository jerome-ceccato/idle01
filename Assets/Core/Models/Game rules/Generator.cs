using System.Numerics;

// An identifiable object representing a resource with an amount
public class Generator : IIdentifiable
{
    public string Id { get; set; }

    public LazyEntity<ResourceEntity> Resource { get; set; }

    public BigInteger Amount { get; set; }
}
