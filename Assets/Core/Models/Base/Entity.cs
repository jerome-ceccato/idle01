using System;

// An immutable game entity
// These are direct representation of the game's data, and not the player's current game state
public abstract class Entity : IIdentifiable, IDisplayable
{
    public string Id { get; set; }

    public string SpriteId
    {
        get
        {
            return SpritePrefix + Id;
        }
    }

    public string Name { get; set; }
    public string FlavorText { get; set; }

    protected abstract string SpritePrefix { get; }

    public override bool Equals(object obj)
    {
        if (obj is IIdentifiable identifiable)
        {
            return Id.Equals(identifiable.Id);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
