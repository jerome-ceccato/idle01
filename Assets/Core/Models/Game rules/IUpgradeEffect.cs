// An object representing a multiplier applied to an entity

public interface IUpgradeEffect
{

}

public class UpgradeEffectMultiplier: IUpgradeEffect
{
    public AnyIdentifiable Target { get; set; }
    public IMultiplier Multiplier { get; set; }
}

public class UpgradeEffectNone : IBuildingEffect
{

}
