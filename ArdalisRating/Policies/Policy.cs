using System;
using System.Collections.Generic;
using System.Linq;

namespace ArdalisRating.Policies;

public enum PolicyType
{
    Life = 0,
    Land = 1,
    Auto = 2
}

public abstract class Policy
{
    public static Dictionary<string, Type> GetTypes()
    {
        var assemblyName = typeof(Policy).Assembly.GetName().Name;

        return Enum.GetNames<PolicyType>()
            .Select(n => new
            {
                Name = n,
                Type = Type.GetType($"{assemblyName}.{n}{nameof(Policy)}")
            })
            .ToDictionary(k => k.Name, v => v.Type);
    }
}
