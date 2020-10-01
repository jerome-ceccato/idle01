using System;

// An immutable identifiable resource
public abstract class Entity
{
    public string Id { get; private set; }
    public string DisplayName { get; private set; }
    public string FlavorText { get; private set; }

    protected Entity(string id, string displayName, string flavorText)
    {
        Id = id;
        DisplayName = displayName;
        FlavorText = flavorText;
    }
}
