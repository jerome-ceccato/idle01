public class UpgradeEntity : Entity
{
    public BaseCost BuyCost { get; set; }

    public IUpgradeEffect Effect { get; set; }
    public UnlockRule UnlockRule { get; set; }

    protected override string SpritePrefix => "Upgrade/";
}
