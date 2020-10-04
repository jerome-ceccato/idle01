using System.Collections.Generic;
public class BuildingEntity : Entity
{
    public BaseCost BuildCost { get; private set; }
    public UnlockRule UnlockRule { get; private set; }
    public BuildRule BuildRule { get; private set; }

    public List<Generator> Generated { get; private set; }
    public List<Generator> Consumed { get; private set; }
    public Frequency GeneratorFrequency { get; private set; }

    public BuildingEntity(string id, string displayName, string flavorText, BaseCost cost, List<Generator> generated, List<Generator> consumed, UnlockRule unlockRule, BuildRule buildRule, Frequency frequency) 
        : base("Building/" + id, displayName, flavorText)
    {
        BuildCost = cost;
        Generated = generated;
        Consumed = consumed;
        UnlockRule = unlockRule;
        BuildRule = buildRule;
        GeneratorFrequency = frequency;
    }
}
