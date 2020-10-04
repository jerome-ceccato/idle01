using System.Numerics;

// An object that can alter a number depending on a set of rules
public interface Multiplier
{
    BigInteger Apply(BigInteger input);
}

public class MultiplierIdentity : Multiplier
{
    public BigInteger Apply(BigInteger input)
    {
        return input;
    }
}

public class MultiplierBaseValue : Multiplier
{
    private BigInteger value;

    public MultiplierBaseValue(BigInteger value)
    {
        this.value = value;
    }

    public BigInteger Apply(BigInteger input)
    {
        return input + value;
    }
}

/*
public class Multiplier2
{
    private static int precision = 1024;

    private BigInteger baseGrowth;
    private double baseMultiplier;
    private double totalMultiplier;

    private Multiplier(BigInteger baseGrowth, double baseMultiplier, double totalMultiplier)
    {
        this.baseGrowth = baseGrowth;
        this.baseMultiplier = baseMultiplier;
        this.totalMultiplier = totalMultiplier;
    }

    public static Multiplier Identity()
    {
        return new Multiplier(new BigInteger(0), 1, 1);
    }

    public static Multiplier AddingBaseValue(BigInteger value)
    {
        return new Multiplier(value, 1, 1);
    }

    public BigInteger Apply(BigInteger input)
    {
        double totalGrowth = baseMultiplier * totalMultiplier;
        BigInteger truncatedGrowth = new BigInteger(totalGrowth * precision);
        
        return BigInteger.Divide(BigInteger.Multiply(BigInteger.Add(input, baseGrowth), truncatedGrowth), precision);
    }
}
*/
