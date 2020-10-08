public class TerrainUpgradeEntity : Entity
{
    public BaseCost BuildCost { get; set; }
    public UnlockRule UnlockRule { get; set; }

    public LazyEntity<TerrainEntity> Target { get; set; }
    public LazyEntity<TerrainEntity> Replacement { get; set; }

    protected override string SpritePrefix => "Upgrade/";
}
