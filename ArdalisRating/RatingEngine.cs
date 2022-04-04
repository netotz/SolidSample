using ArdalisRating.Policies;
using ArdalisRating.PolicyRaters;

using System;

namespace ArdalisRating;

/// <summary>
/// The RatingEngine reads the policy application details from a file and produces a numeric 
/// rating value based on the details.
/// </summary>
public class RatingEngine
{
    public decimal Rating { get; set; } = 0;
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

        Rating = policy switch
        {
            AutoPolicy => new AutoPolicyRater(Logger, policy as AutoPolicy).Rate(),
            LandPolicy => new LandPolicyRater(Logger, policy as LandPolicy).Rate(),
            LifePolicy => new LifePolicyRater(Logger, policy as LifePolicy).Rate(),
            _ => throw new ArgumentException()
        };

        Logger.Log("Rating completed.");
    }
}
