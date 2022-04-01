using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating;

public class PolicySerializer
{
    public Policy DeserializeJson(string json)
    {
        return JsonConvert.DeserializeObject<Policy>(json, new StringEnumConverter());
    }
}
