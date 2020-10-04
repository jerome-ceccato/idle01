using UnityEngine;

// An object representing a number of ticks to perform an action
public class Frequency : IIdentifiable
{
    public string Id { get; private set; }
    public int Ticks { get; private set; }
    public int RandomTicks { get; private set; }

    public Frequency(string id, int ticks, int randomTicks)
    {
        Id = id;
        Ticks = ticks;
        RandomTicks = randomTicks;
    }

    public int PickValue()
    {
        return Ticks + Random.Range(-RandomTicks, RandomTicks);
    }
}
