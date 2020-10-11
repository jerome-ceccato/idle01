public class AnyIdentifiable : IIdentifiable
{
    public string Id { get; set; }

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

    public static implicit operator AnyIdentifiable(string rhs)
    {
        return new AnyIdentifiable() { Id = rhs };
    }
}
