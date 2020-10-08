public sealed class BuildingEntity : Entity
{
    public BaseCost BuildCost { get; set; }
    public UnlockRule UnlockRule { get; set; }
    public BuildRule BuildRule { get; set; }

    public IBuildingEffect Effect { get; set; }
    public Frequency EffectFrequency { get; set; }

    protected override string SpritePrefix => "Building/";
}
