using UnityEngine;

// Mutable state of a frequency
public class Ticker
{
    public Frequency Frequency { get; private set; }
    private int currentTick;
    private int requiredTicks;

    public Ticker(Frequency frequency)
    {
        Frequency = frequency;
        currentTick = 0;
        requiredTicks = frequency.PickValue();
    }

    // Runs the ticker and returns whether or not the object should tick
    public bool MakeTick(int speed)
    {
        currentTick += speed;
        if (currentTick >= requiredTicks)
        {
            currentTick = 0;
            requiredTicks = Frequency.PickValue();
            return true;
        }
        else
        {
            return false;
        }
    }
}
