using System;

// An immutable identifiable entity
public abstract class Entity : Identifiable
{
    public string DisplayName { get; private set; }
    public string FlavorText { get; private set; }

    protected Entity(string id, string displayName, string flavorText) : base(id)
    {
        DisplayName = displayName;
        FlavorText = flavorText;
    }
}
