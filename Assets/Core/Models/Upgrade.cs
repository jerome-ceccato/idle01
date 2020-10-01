using System.Numerics;

public class Upgrade
{
    public UpgradeEntity Entity { get; private set; }
    public Cost Cost { get; private set; }
    public Effect Effect { get; private set; }

    public Upgrade(UpgradeEntity entity, Cost cost, Effect effect)
    {
        Entity = entity;
        Cost = cost;
        Effect = effect;
    }
}
