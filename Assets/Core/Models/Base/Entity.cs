using System;

// An immutable identifiable entity
public abstract class Entity : Identifiable, Displayable
{
    public string Id { get; private set; }

    public string SpriteId
    {
        get
        {
            return Id;
        }
    }
    public string DisplayName { get; private set; }
    public string FlavorText { get; private set; }

    protected Entity(string id, string displayName, string flavorText = null)
    {
        Id = id;
        DisplayName = displayName;
        FlavorText = flavorText;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Identifiable item))
        {
            return false;
        }

        return this.Id.Equals(item.Id);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}
