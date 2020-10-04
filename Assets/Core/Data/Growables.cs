using System.Collections.Generic;

public class Growables
{
    public static GrowableEntity wheat = new GrowableEntity("wheat", "Wheat", "Wheat is growing here",
        new Generator("growable_what", Resources.wheat, 1),
        new List<GrowableEntity.Stage>
        {
            new GrowableEntity.Stage("wheat1", 20),
            new GrowableEntity.Stage("wheat2", 20),
        });

    public static GrowableIncarnation CreateWheat()
    {
        return new GrowableIncarnation(wheat);
    }
}
