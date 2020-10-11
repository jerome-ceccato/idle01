using System.Collections.Generic;
using System.Numerics;
using System.Linq;

// Requirements to unlock an entity
public class UnlockRule
{
    public List<MinimumResourceRequirement> RequiredResources { get; set; }
    public List<LazyEntity<UpgradeEntity>> RequiredUpgrades { get; set; }
    public List<LazyEntity<BuildingEntity>> RequiredBuildings { get; set; }
}

public class MinimumResourceRequirement
{
    public LazyEntity<ResourceEntity> Resource { get; set; }

    public BigInteger Amount { get; set; }
}