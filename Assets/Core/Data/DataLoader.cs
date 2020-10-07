using System.Collections.Generic;
using YamlDotNet.Serialization;
public class DataLoader
{
    private Deserializer deserializer;
    public DataLoader()
    {
        deserializer = new Deserializer();
        deserializer.Deserialize()
    }

}
