﻿using UnityEngine;
using System.Collections;

public class GrowableIncarnation
{
    public GrowableEntity Entity { get; private set; }

    private int currentStageIndex;
    private int currentTick;

    public GrowableIncarnation(GrowableEntity entity)
    {
        Entity = entity;
        currentStageIndex = -1;
        currentTick = 0;
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
            // TODO: calculate index
        }
    }

    public void Reset()
    {
        currentStageIndex = -1;
        currentTick = 0;
    }
}
