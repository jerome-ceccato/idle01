using System.Collections.Generic;

public interface BuildingEffect
{

}

public class BuildingEffectGenerator
{
    public List<Generator> Generated { get; private set; }
    public List<Generator> Consumed { get; private set; }

    public BuildingEffectGenerator(List<Generator> generated, List<Generator> consumed)
    {
        Generated = generated;
        Consumed = consumed;
    }
}

public class BuildingEffectHarvester : BuildingEffect
{

}
