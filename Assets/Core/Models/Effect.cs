using System;

public class Effect
{
    public Entity Target { get; private set; }
    public Multiplier Multiplier { get; private set; }

    public Effect(Entity target, Multiplier multiplier)
    {
        Target = target;
        Multiplier = multiplier;
    }
}
