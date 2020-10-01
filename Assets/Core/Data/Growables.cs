using System.Collections.Generic;

public class Growables
{
    public static GrowableEntity growableWheat = new GrowableEntity("wheat", "Wheat", "Wheat is starting to grow here");

    public static GrowableGroup Wheat()
    {
        return new GrowableGroup(
            growableWheat,
            Resources.wheat,
            new List<string>()
            {
                "wheat1",
                "wheat2",
            }
        );
    }
}
