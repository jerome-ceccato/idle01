
public class UIState
{
    public enum Value
    {
        Default,
        BuildingSelected,
        TerrainUpgradeSelected,
        DestoryBuildings
    }

    public readonly Value state;

    // Only available in BuildingSelected
    public readonly BuildingEntity buildingEntity;
    // Only available in TerrainUpgradeSelected
    public readonly TerrainUpgradeEntity terrainUpgradeEntity;

    private UIState(Value v, BuildingEntity buildingEntity, TerrainUpgradeEntity terrainUpgradeEntity)
    {
        state = v;
        this.buildingEntity = buildingEntity;
        this.terrainUpgradeEntity = terrainUpgradeEntity;
    }

    public static UIState Default()
    {
        return new UIState(Value.Default, null, null);
    }

    public static UIState BuildingSelected(BuildingEntity buildingEntity)
    {
        return new UIState(Value.BuildingSelected, buildingEntity, null);
    }

    public static UIState TerrainUpgradeSelected(TerrainUpgradeEntity terrainUpgradeEntity)
    {
        return new UIState(Value.TerrainUpgradeSelected, null, terrainUpgradeEntity);
    }

    public static UIState DestoryBuildings()
    {
        return new UIState(Value.DestoryBuildings, null, null);
    }
}
