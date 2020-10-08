// Represents an entity which will be resolved at runtime
public class LazyEntity<T> where T : Entity
{
    private T cache;
    private string id;

    public LazyEntity(string id)
    {
        this.id = id;
        cache = null;
    }

    public T Entity
    {
        get
        {
            if (cache == null)
            {
                cache = DataStore.Shared.Get<T>(id);
            }
            return cache;
        }
    }

    public static implicit operator LazyEntity<T>(string rhs)
    {
        return new LazyEntity<T>(rhs);
    }
}
