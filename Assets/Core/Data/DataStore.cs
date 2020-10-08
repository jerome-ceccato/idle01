public class DataStore
{
    private DataStore()
    {
    }

    public T Get<T>(string id) where T : Entity
    {
        return null;
    }

    // Singleton boilerplate

    private static readonly object padlock = new object();
    private static DataStore instance = null;
    public static DataStore Shared
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new DataStore();
                }
                return instance;
            }
        }
    }
}
