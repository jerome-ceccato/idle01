using System;
using System.Collections.Generic;

public sealed class GrowableEntity : Entity
{
    public class Stage : Displayable
    {
        public string SpriteId { get; private set; }

        public int Ticks { get; private set; }

        public Stage(string id, int ticks)
        {
            SpriteId = "Growable/" + id;
            Ticks = ticks;
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
