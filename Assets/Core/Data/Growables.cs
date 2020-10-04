using System.Collections.Generic;

public class Growables
{
    public static GrowableEntity wheat = new GrowableEntity("wheat", "Wheat", "Wheat is growing here",
        new Generator("growable_wheat", Resources.wheat, 1),
        new List<GrowableEntity.Stage>
        {
            new GrowableEntity.Stage("wheat1", new Frequency("wheat1_freq", 25, 20)),
            new GrowableEntity.Stage("wheat2", new Frequency("wheat2_freq", 25, 20)),
        });

    public static GrowableIncarnation CreateWheat()
    {
        return new GrowableIncarnation(wheat);
    }
}
