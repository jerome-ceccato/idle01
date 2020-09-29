using System.Collections.Generic;

public class GrowableFactory
{
    public static Growable Wheat()
    {
        return new Growable(new List<Growable.GrowthStage>()
            {
                new Growable.GrowthStage(new GrowableEntity("wheat1"), 20, 10),
                new Growable.GrowthStage(new GrowableEntity("wheat2"), 20, 10),
            },
             new Growable.TileResource(Resources.wheat, 1));
    }
}
