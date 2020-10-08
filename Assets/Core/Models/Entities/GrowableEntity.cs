using System.Collections.Generic;

public sealed class GrowableEntity : Entity
{
    public sealed class Stage : IDisplayable
    {
        public string Id { get; set; }
        public Frequency GrowthFrequency { get; set; }

        public string SpriteId => "Growable/";
    }
        
    public List<Stage> Stages { get; set; }
    
    public Generator GrownResource { get; set; }

    protected override string SpritePrefix => "Growable/";
}
