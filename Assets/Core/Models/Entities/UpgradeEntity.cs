public class UpgradeEntity : Entity
{
    public BaseCost BuyCost { get; private set; }

    public UpgradeEffect Effect { get; private set; }

    public UnlockRule UnlockRule { get; private set; }

    public UpgradeEntity(string id, string displayName, string flavorText, BaseCost buyCost, UpgradeEffect effect, UnlockRule rule)
        : base("Upgrade/" + id, displayName, flavorText)
    {
        BuyCost = buyCost;
        Effect = effect;
        UnlockRule = rule;
    }
}
