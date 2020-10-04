using System.Collections.Generic;
using System.Numerics;

public class Upgrades
{
    public static UpgradeEntity basicFertilizer = new UpgradeEntity("fertilizer1", "Basic fertilizer", "It smells but it makes wheat grow faster",
        new BaseCost(new List<Generator>()
        {
            new Generator("fertilizer1_cost_wheat", Resources.wheat, 5)
        }),
        new UpgradeEffect(Growables.wheat, new MultiplierBaseValue(1)),
        new UnlockRule());
}
