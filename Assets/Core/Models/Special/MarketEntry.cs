using System.Numerics;

public class MarketEntry
{
    public LazyEntity<ResourceEntity> Resource { get; set; }
    public BigInteger Amount  { get; set; }

    public bool Available { get; set; }
    public bool Active { get; set; }
}
