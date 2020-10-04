using System;

// Mutable state of a frequency
public class Ticker
{
    public Frequency Frequency { get; private set; }
    private int currentTick;

    public Ticker(Frequency frequency)
    {
        Frequency = frequency;
        currentTick = 0;
    }

    // Runs the ticker and returns whether or not the object should tick
    public bool MakeTick(int speed)
    {
        currentTick += speed;
        if (currentTick >= Frequency.Ticks)
        {
            currentTick = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
