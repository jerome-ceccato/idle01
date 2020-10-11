using System.Collections;
using System.Collections.Generic;
using System.Numerics;

// An object that can alter a number depending on a set of rules
public interface IMultiplier
{
    BigInteger Apply(BigInteger input);
}

public class MultiplierIdentity : IMultiplier
{
    public BigInteger Apply(BigInteger input)
    {
        return input;
    }
}

public class MultiplierBaseValue : IMultiplier
{
    public BigInteger Value { get; set; }

    public BigInteger Apply(BigInteger input)
    {
        return input + Value;
    }
}
public class CombinedMultiplier: IMultiplier
{
    private static int precision = 1024;

    private BigInteger baseGrowth;
    private double baseMultiplier;
    private double totalMultiplier;
    public CombinedMultiplier(IEnumerable<IMultiplier> multipliers)
    {
        baseGrowth = 0;
        baseMultiplier = 1;
        totalMultiplier = 1;
        
        foreach (IMultiplier multiplier in multipliers)
        {
            if (multiplier is MultiplierBaseValue baseValueMultiplier)
            {
                baseGrowth += baseValueMultiplier.Value;
            }
        }
    }

    public BigInteger Apply(BigInteger input)
    {
        double totalGrowth = baseMultiplier * totalMultiplier;
        BigInteger truncatedGrowth = new BigInteger(totalGrowth * precision);
        
        return BigInteger.Divide(BigInteger.Multiply(BigInteger.Add(input, baseGrowth), truncatedGrowth), precision);
    }
}
