using ArdalisRating.Policies;

namespace ArdalisRating.PolicyRaters;

public class AutoPolicyRater : PolicyRater<AutoPolicy>
{
    public AutoPolicyRater(RatingEngine engine, Logger logger, AutoPolicy policy)
        : base(engine, logger, policy)
    {
    }

    protected override void Rate()
    {
        _logger.Log("Rating AUTO policy...");
        _logger.Log("Validating policy.");

        if (string.IsNullOrEmpty(Policy.Make))
        {
            _logger.Log("Auto policy must specify Make");
            return;
        }

        if (Policy.Make == "BMW")
        {
            _engine.Rating = Policy.Deductible < 500 ? 1000m : 900m;
        }
    }
}
