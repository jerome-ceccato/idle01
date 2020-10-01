using UnityEngine;
using System.Collections;
using System.Numerics;

public class Multiplier
{
    private static int precision = 1024;

    public double baseGrowth = 1;
    public double multiplier = 1;

    public BigInteger Apply(BigInteger input)
    {
        double totalGrowth = baseGrowth * multiplier;
        BigInteger truncatedGrowth = new BigInteger(totalGrowth * precision);
        
        return BigInteger.Divide(BigInteger.Multiply(input, truncatedGrowth), precision);
    }
}