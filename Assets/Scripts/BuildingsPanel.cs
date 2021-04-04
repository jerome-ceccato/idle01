using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class BuildingsPanel : MonoBehaviour
{
    private ListBuilder listBuilder;

    private void Start()
    {
        listBuilder = GetComponent<ListBuilder>();
    }

    void OnGUI()
    {
        List<BuildingEntity> buildings = GameManager.Instance.AvailableBuildings;
        List<TerrainUpgradeEntity> terrainUpgrades = GameManager.Instance.AvailableTerrainUpgrades;

        List<Entity> allEntities = new List<Entity>(buildings);
        allEntities.AddRange(terrainUpgrades);

        listBuilder.UpdateNumberOfEntries(allEntities.Count);
        for (int i = 0; i < allEntities.Count; i++)
        {
            GameObject entry = listBuilder.Entries[i];
            BuildingEntry buildingEntry = entry.GetComponent<BuildingEntry>();

            if (allEntities[i] is BuildingEntity building)
            {
                buildingEntry.Configure(building);
            }
            else if (allEntities[i] is TerrainUpgradeEntity terrainUpgrade)
            {
                buildingEntry.Configure(terrainUpgrade);
            }
        }
    }
}
