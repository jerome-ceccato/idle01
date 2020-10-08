using UnityEngine;

// An object representing a number of ticks to perform an action
public class Frequency : IIdentifiable
{
    public string Id { get; set; }
    public int Ticks { get; set; }
    public int Variance { get; set; }

    public int PickValue()
    {
        return Ticks + Random.Range(-Variance, Variance);
    }
}
