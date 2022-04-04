using ArdalisRating.Policies;

namespace ArdalisRating.PolicyRaters;

public class AutoPolicyRater : PolicyRater<AutoPolicy>
{
    public AutoPolicyRater(Logger logger, AutoPolicy policy)
        : base(logger, policy)
    {
    }

    public override decimal Rate()
    {
        _logger.Log("Rating AUTO policy...");
        _logger.Log("Validating policy.");

        if (Policy.Make == "BMW")
        {
            return Policy.Deductible < 500 ? 1000m : 900m;
        }

        if (string.IsNullOrEmpty(Policy.Make))
        {
            _logger.Log("Auto policy must specify Make");
        }

        return 0;
    }
}
