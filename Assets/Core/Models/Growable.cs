using System.Collections.Generic;
using UnityEngine;

public class Growable
{
    public sealed class TileResource
    {
        public ResourceEntity resource;
        public int amount;

        public TileResource(ResourceEntity resource, int amount)
        {
            this.resource = resource;
            this.amount = amount;
        }
    }

    public sealed class GrowthStage
    {
        public readonly GrowableEntity entity;
        // The number of ticks it takes to grow
        public int growthTicks;
        // A random variance to apply
        public int growthVariance;

        public GrowthStage(GrowableEntity entity, int ticks, int variance) 
        {
            this.entity = entity;
            growthTicks = ticks;
            growthVariance = variance;
        }
    }

    private List<GrowthStage> stages;
    private int currentStage;
    private int remainingTicks;
    private TileResource resource;
    private bool done;

    public Growable(List<GrowthStage> stages, TileResource resource)
    {
        this.stages = stages;
        this.resource = resource;

        currentStage = -1;
        remainingTicks = 0;
        done = false;
    }

    public GrowableEntity CurrentlyGrowingEntity
    {
        get
        {
            return currentStage > 0 ? stages[currentStage - 1].entity : null;
        }
    }

    public void Tick()
    {
        if (!done)
        {
            if (remainingTicks <= 0)
            {
                currentStage++;
                if (currentStage >= stages.Count)
                {
                    done = true;
                }
                else
                {
                    GrowthStage stage = stages[currentStage];
                    remainingTicks = stage.growthTicks + Random.Range(-stage.growthVariance, stage.growthVariance);
                }
            }
            else
            {
                remainingTicks--;
            }
        }
    }

    public void CollectResource()
    {
        if (done)
        {
            done = false;
            currentStage = -1;
            remainingTicks = 0;

            GameManager.Instance.AddResource(resource.resource, resource.amount);
        }
    }
}
