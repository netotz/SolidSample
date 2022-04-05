using ArdalisRating.Policies;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;

namespace ArdalisRating;

public class PolicySerializer
{
    public Policy DeserializeJson(string json)
    {
        var typeName = JObject.Parse(json)["type"]?.ToString();
        var types = Policy.GetTypes();

        return types.TryGetValue(typeName, out var policyType)
            ? JsonConvert.DeserializeObject(json, policyType) as Policy
            : throw new ArgumentException("Unkown policy type.");
    }
}
