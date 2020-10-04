using System.Collections.Generic;
using System.Linq;

// Incarnation of a growable: a growable in the world, with its own mutable data
public class GrowableIncarnation
{
    public GrowableEntity Entity { get; private set; }

    private int currentStageIndex;
    private List<int> resolvedTicks;
    private int currentTick;

    public GrowableIncarnation(GrowableEntity entity)
    {
        Entity = entity;
        Reset();
    }

    public GrowableEntity.Stage CurrentStage
    {
        get
        {
            if (currentStageIndex >= 0 && currentStageIndex < Entity.Stages.Count)
            {
                return Entity.Stages[currentStageIndex];
            }
            else
            {
                return null;
            }
        }
    }

    public bool CanCollect()
    {
        return currentStageIndex == (Entity.Stages.Count - 1);
    }

    public void Grow(int growthTicks = 1)
    {
        if (currentStageIndex < (Entity.Stages.Count - 1))
        {
            currentTick += growthTicks;
            currentStageIndex = StageIndexForTick(currentTick);
        }
    }

    public void Reset()
    {
        currentStageIndex = -1;
        currentTick = 0;
        resolvedTicks = new List<int>(Entity.Stages.Select(s => s.GrowthFrequency.PickValue()));
    }

    private int StageIndexForTick(int ticks)
    {
        int index = 0;
        for (; index < resolvedTicks.Count; index++)
        {
            if (ticks < resolvedTicks[index])
            {
                return index - 1;
            }
            else
            {
                ticks -= resolvedTicks[index];
            }
        }
        return index - 1;
    }
}
