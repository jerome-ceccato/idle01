using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class ResolvedGenerator
{
    public ResourceEntity Resource { get; private set; }
    public BigInteger Amount { get; private set; }

    public ResolvedGenerator(Generator generator, ResolvedMultipliers multipliers)
    {
        Resource = generator.Resource.Entity;
        Amount = multipliers.Get(generator).Apply(generator.Amount);
    }

    public static List<ResolvedGenerator> List(List<Generator> generators, ResolvedMultipliers multipliers)
    {
        return new List<ResolvedGenerator>(generators.Select(generator => new ResolvedGenerator(generator, multipliers)));
    }
}
