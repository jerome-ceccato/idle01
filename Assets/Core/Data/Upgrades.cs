using System.Collections.Generic;
using System.Numerics;

public class Upgrades
{
    public static List<Upgrade> all = new List<Upgrade>()
    {
        new Upgrade(
            new UpgradeEntity("fertilizer1", "Basic fertilizer", "It smells but it makes wheat grow faster"),
            new BaseCost(Resources.wheat, 5),
            new UpgradeEffect(Growables.growableWheat, Multiplier.AddingBaseValue(1))
        ),
    };
}
