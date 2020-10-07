using System.Collections.Generic;

public class Terrains
{
    public static TerrainEntity grass = new TerrainEntity("grassField", "Grass", "A field of grass", Growables.wheat);
    public static TerrainEntity dirt = new TerrainEntity("dirt", "Dirt", "A field of dirt", null);
 }
