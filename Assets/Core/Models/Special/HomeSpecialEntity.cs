using System.Collections.Generic;

public class HomeSpecialEntity : ISpecialEntity
{
    public string Id => "home";
    public string SpriteId => "Special/home";

    public List<MarketEntry> MarketEntries { get; set; }

    public HomeSpecialEntity()
    {
        // TODO: yaml file
        MarketEntries = new List<MarketEntry>
        {
            new MarketEntry
            {
                Resource = new LazyEntity<ResourceEntity> { Id = "wheat" },
                Amount = 1,
                Available = true,
            },
            new MarketEntry
            {
                Resource = new LazyEntity<ResourceEntity> { Id = "flour" },
                Amount = 6,
                Available = true,
            },
        };
    }

    public List<MarketEntry> AvailableMarketEntries()
    {
        return MarketEntries.FindAll(m => m.Available);
    }

    public List<MarketEntry> ActiveMarketEntries()
    {
        return MarketEntries.FindAll(m => m.Available && m.Active);
    }
}
