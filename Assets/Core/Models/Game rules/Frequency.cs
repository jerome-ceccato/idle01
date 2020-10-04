using System;

// An object representing a number of ticks to perform an action
public class Frequency : Identifiable
{
    public string Id { get; private set; }
    public int Ticks { get; private set; }

    public Frequency(string id, int ticks)
    {
        Id = id;
        Ticks = ticks;
    }
}
