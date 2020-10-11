﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameRules
{
    private readonly GameState gameState;

    public GameRules(GameState gameState)
    {
        this.gameState = gameState;
    }
    private List<IMultiplier> ActiveMultipliersForIdentifiable(IIdentifiable entity)
    {
        // TODO: not just upgrades?
        // TODO: cache/optimize
        IEnumerable<UpgradeEntity> activeUpgrades = gameState.ownedUpgrades.FindAll(upgrade => upgrade.Effect.Target.Id == entity.Id);
        IEnumerable<IMultiplier> multipliers = activeUpgrades.Select(upgrade => upgrade.Effect.Multiplier);

        return new List<IMultiplier>(multipliers);
    }

    public IMultiplier ActiveFinalMultiplierForIdentifiable(IIdentifiable entity)
    {
        List<IMultiplier> multipliers = ActiveMultipliersForIdentifiable(entity);
        if (multipliers.Count == 0)
        {
            return new MultiplierIdentity();
        }
        else if (multipliers.Count == 1)
        {
            return multipliers[0];
        }
        else
        {
            return new CombinedMultiplier(multipliers);
        }
    }
}
