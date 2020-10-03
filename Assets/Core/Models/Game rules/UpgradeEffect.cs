using System;

public class UpgradeEffect
{
    public Entity Target { get; private set; }
    public Multiplier Multiplier { get; private set; }

    public UpgradeEffect(Entity target, Multiplier multiplier)
    {
        Target = target;
        Multiplier = multiplier;
    }
}
