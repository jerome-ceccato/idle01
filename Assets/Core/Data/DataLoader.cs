﻿using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class DataLoader
{
    private IDeserializer deserializer;

    public DataLoader()
    {
        deserializer = new DeserializerBuilder()
            .WithNamingConvention(new CamelCaseNamingConvention())
            .WithAttributeOverride<ResourceEntity>(x => x.SpriteId, new YamlIgnoreAttribute())
            .WithTagMapping("!MultiplierBaseValue", typeof(MultiplierBaseValue))
            .WithTagMapping("!BuildingEffectHarvester", typeof(BuildingEffectHarvester))
            .WithTagMapping("!BuildingEffectGenerator", typeof(BuildingEffectGenerator))
            .WithTagMapping("!UnlockRule", typeof(UnlockRule))
            .WithTagMapping("!UpgradeEffectMultiplier", typeof(UpgradeEffectMultiplier))
            .WithTagMapping("!UpgradeEffectNone", typeof(UpgradeEffectNone))
            .Build();
    }

    public List<T> Load<T>(TextAsset asset) where T : Entity
    {
        return deserializer.Deserialize<List<T>>(asset.text);
    }
}
