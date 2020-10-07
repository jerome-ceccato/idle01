using System.Collections.Generic;

public interface IBuildingEffect
{

}

public class BuildingEffectGenerator : IBuildingEffect
{
    public List<Generator> Generated { get; private set; }
    public List<Generator> Consumed { get; private set; }

    public BuildingEffectGenerator(List<Generator> generated, List<Generator> consumed)
    {
        Generated = generated;
        Consumed = consumed;
    }

    public BuildingEffectGenerator(Generator generated)
    {
        Generated = new List<Generator>
        {
            generated,
        };
        Consumed = new List<Generator>();
    }
}

public class BuildingEffectHarvester : IBuildingEffect
{

}
