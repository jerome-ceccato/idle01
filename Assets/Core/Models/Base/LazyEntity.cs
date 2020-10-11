// Represents an entity which will be resolved at runtime
public class LazyEntity<T> : AnyIdentifiable where T : Entity
{
    private T cache = null;
   
    public T Entity
    {
        get
        {
            if (cache == null)
            {
                cache = DataStore.Shared.Get<T>(Id);
            }
            return cache;
        }
    }

    public static implicit operator LazyEntity<T>(string rhs)
    {
        return new LazyEntity<T> { Id = rhs };
    }
}
