public class TerrainEntity : Entity
{
    public LazyEntity<GrowableEntity> Growable { get; set; }

    protected override string SpritePrefix => "Terrain/";
}
