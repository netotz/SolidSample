using ArdalisRating.Policies;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using System;

namespace ArdalisRating;

public class PolicySerializer
{
    public Policy DeserializeJson(string json)
    {
        var typeName = JObject.Parse(json)["type"]?.ToString();

        var type = Enum.Parse<PolicyType>(typeName);
        return type switch
        {
            PolicyType.Auto => JsonConvert.DeserializeObject<AutoPolicy>(json, new StringEnumConverter()),
            PolicyType.Land => JsonConvert.DeserializeObject<LandPolicy>(json, new StringEnumConverter()),
            PolicyType.Life => JsonConvert.DeserializeObject<LifePolicy>(json, new StringEnumConverter()),
            _ => throw new Exception()
        };
    }
}
