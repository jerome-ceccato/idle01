using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class DataLoader
{
    private IDeserializer deserializer;
    public DataLoader(string resources)
    {
        deserializer = new DeserializerBuilder()
            .WithNamingConvention(new CamelCaseNamingConvention())
            .WithAttributeOverride<ResourceEntity>(x => x.SpriteId, new YamlIgnoreAttribute())
            .Build();

        var content = deserializer.Deserialize<List<ResourceEntity>>(resources);
        Debug.Log(content);
    }

}
