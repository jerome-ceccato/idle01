// An object representing a multiplier applied to an entity
public class UpgradeEffect
{
    public Entity Target { get; private set; }
    public IMultiplier Multiplier { get; private set; }

    public UpgradeEffect(Entity target, IMultiplier multiplier)
    {
        Target = target;
        Multiplier = multiplier;
    }
}
