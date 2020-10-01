using System.Collections.Generic;
using Unity.Mathematics;
using System.Linq;

public sealed class GrowableGroup
{
    public class Stage: Identifiable
    {
        public Stage(string id) : base(id) { }
    }

    public GrowableEntity Entity { get; private set; }

    public ResourceEntity GrownResource { get; private set; }
    public List<Stage> Stages { get; private set; }

    // nullable
    public Stage CurrentStage { get; private set; }

    private int currentIndex;
    
    public GrowableGroup(GrowableEntity entity, ResourceEntity grownResource, List<string> stageIdentifiers)
    {
        Entity = entity;
        GrownResource = grownResource;
        Stages = new List<Stage>(stageIdentifiers.Select(id => new Stage("Growable/" + id)));
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
