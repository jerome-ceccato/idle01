// An object representing a multiplier applied to an entity
public class UpgradeEffect
{
    public AnyIdentifiable Target { get; set; }
    public IMultiplier Multiplier { get; set; }
}
