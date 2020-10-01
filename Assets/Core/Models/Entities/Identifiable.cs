using System;

// An immutable identifiable resource
public abstract class Identifiable
{
    public string Id { get; private set; }
   
    protected Identifiable(string id)
    {
        Id = id;
    }

    public override bool Equals(object obj)
    {
        var item = obj as Identifiable;

        if (item == null)
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
