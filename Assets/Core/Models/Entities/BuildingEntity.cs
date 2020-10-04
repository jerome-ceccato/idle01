using System.Collections.Generic;
public class BuildingEntity : Entity
{
    public BaseCost BuildCost { get; private set; }
    public UnlockRule UnlockRule { get; private set; }
    public BuildRule BuildRule { get; private set; }

    public BuildingEffect Effect { get; private set; }
    public Frequency EffectFrequency { get; private set; }

    public BuildingEntity(string id, string displayName, string flavorText, BaseCost cost, BuildingEffect effect, UnlockRule unlockRule, BuildRule buildRule, Frequency frequency) 
        : base("Building/" + id, displayName, flavorText)
    {
        BuildCost = cost;
        Effect = effect;
        UnlockRule = unlockRule;
        BuildRule = buildRule;
        EffectFrequency = frequency;
    }
}
