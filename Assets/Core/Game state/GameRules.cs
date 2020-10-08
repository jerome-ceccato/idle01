using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRules
{
    private readonly GameState gameState;

    public GameRules(GameState gameState)
    {
        this.gameState = gameState;
    }

    // TODO: improve
    public IMultiplier MultiplierForGrowable(GrowableIncarnation growable)
    {
        foreach (UpgradeEntity upgrade in gameState.ownedUpgrades)
        {
            if (upgrade.Effect.Target.Entity == growable.Entity)
            {
                return upgrade.Effect.Multiplier;
            }
        }
        return new MultiplierIdentity();
    }
}
