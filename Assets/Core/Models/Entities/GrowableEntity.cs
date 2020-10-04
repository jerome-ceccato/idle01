using System.Collections.Generic;

public sealed class GrowableEntity : Entity
{
    public class Stage : IDisplayable
    {
        public string SpriteId { get; private set; }
        public Frequency GrowthFrequency { get; private set; }

        public Stage(string id, Frequency growthFrequency)
        {
            SpriteId = "Growable/" + id;
            GrowthFrequency = growthFrequency;
        }
    }
        
    public List<Stage> Stages { get; private set; }
    
    public Generator GrownResource { get; private set; }

    public GrowableEntity(string id, string displayName, string flavorText, Generator grownResource, List<Stage> stages)
        : base("Growable/" + id, displayName, flavorText)
    {
        Stages = stages;
        GrownResource = grownResource;
    }
}
