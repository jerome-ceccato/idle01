using System.Collections.Generic;
using Unity.Mathematics;

public sealed class GrowableGroup
{
    public string Id { get; private set; }
    public List<GrowingEntity> Stages { get; private set; }

    // nullable
    public GrowingEntity CurrentStage { get; private set; }

    private int currentIndex;
    
    public GrowableGroup(string id, List<GrowingEntity> stages)
    {
        Id = "growable_" + id;
        Stages = stages;
        currentIndex = -1;
        CurrentStage = null;
    }

    public bool CanCollect()
    {
        return currentIndex == (Stages.Count - 1);
    }

    public void Grow()
    {
        if (currentIndex < (Stages.Count - 1))
        {
            currentIndex++;
            CurrentStage = Stages[currentIndex];
        }
    }

    public void Reset()
    {
        currentIndex = -1;
        CurrentStage = null;
    }
}
