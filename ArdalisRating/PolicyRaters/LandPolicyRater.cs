using ArdalisRating.Policies;

namespace ArdalisRating.PolicyRaters;

public class LandPolicyRater : PolicyRater<LandPolicy>
{
    public LandPolicyRater(RatingEngine engine, Logger logger, LandPolicy policy) : base(engine, logger, policy)
    {
    }

    protected override void Rate()
    {
        _logger.Log("Rating LAND policy...");
        _logger.Log("Validating policy.");

        if (Policy.BondAmount == 0 || Policy.Valuation == 0)
        {
            _logger.Log("Land policy must specify Bond Amount and Valuation.");
            return;
        }

        if (Policy.BondAmount < 0.8m * Policy.Valuation)
        {
            _logger.Log("Insufficient bond amount.");
            return;
        }

        _engine.Rating = Policy.BondAmount * 0.05m;
    }
}
