using System.Collections.Generic;

// Final multipliers resolved for the current context
public class ResolvedMultipliers
{
    private Dictionary<IIdentifiable, IMultiplier> multipliers;
    private GameRules rules;

    public ResolvedMultipliers(GameRules rules)
    {
        this.rules = rules;
        multipliers = new Dictionary<IIdentifiable, IMultiplier>();
    }

    public IMultiplier Get(IIdentifiable identifiable)
    {
        if (!multipliers.ContainsKey(identifiable))
        {
            multipliers.Add(identifiable, rules.ActiveFinalMultiplierForIdentifiable(identifiable));
        }
        return multipliers[identifiable];
    }
}
