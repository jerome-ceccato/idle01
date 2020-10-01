using System.Collections.Generic;

public class Growables
{
    public static GrowableGroup Wheat()
    {
        return new GrowableGroup("wheat", new List<GrowingEntity>()
        {
            new GrowingEntity("wheat1", "Wheat", "Wheat is starting to grow here"),
            new GrowingEntity("wheat2", "Wheat", "Some fully grown wheat"),
        });
    }
}
