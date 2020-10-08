using System.Collections.Generic;

public interface IBuildingEffect
{

}

public class BuildingEffectGenerator : IBuildingEffect
{
    public List<Generator> Generated { get; set; }
    public List<Generator> Consumed { get; set; }
}

public class BuildingEffectHarvester : IBuildingEffect
{

}
