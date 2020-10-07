public class TerrainUpgradeEntity : Entity
{
    public BaseCost BuildCost { get; private set; }
    public UnlockRule UnlockRule { get; private set; }
    public TerrainEntity Target { get; private set; }
    public TerrainEntity Replacement { get; private set; }
    
    public TerrainUpgradeEntity(string id, string displayName, string flavorText, BaseCost cost, UnlockRule unlockRule, TerrainEntity target, TerrainEntity replacement)
         : base("Upgrade/" + id, displayName, flavorText)
    {
        BuildCost = cost;
        UnlockRule = unlockRule;
        Target = target;
        Replacement = replacement;
    }
}
