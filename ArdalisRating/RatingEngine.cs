using System;

namespace ArdalisRating;

/// <summary>
/// The RatingEngine reads the policy application details from a file and produces a numeric 
/// rating value based on the details.
/// </summary>
public class RatingEngine
{
    public decimal Rating { get; set; }
    private Logger Logger { get; } = new Logger();
    private PolicyLoader PolicyLoader { get; } = new PolicyLoader();
    private PolicySerializer PolicySerializer { get; } = new PolicySerializer();

    public void Rate()
    {
        Logger.Log("Starting rate.");

        Logger.Log("Loading policy.");

        // load policy - open file policy.json
        string policyJson = PolicyLoader.LoadFrom("policy.json");

        var policy = PolicySerializer.DeserializeJson(policyJson);

        

        Logger.Log("Rating completed.");
    }
}
