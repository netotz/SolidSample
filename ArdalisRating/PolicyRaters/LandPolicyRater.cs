using ArdalisRating.Policies;

namespace ArdalisRating.PolicyRaters;

public class LandPolicyRater : PolicyRater<LandPolicy>
{
    public LandPolicyRater(Logger logger, LandPolicy policy) : base(logger, policy)
    {
    }

    public override decimal Rate()
    {
        _logger.Log("Rating LAND policy...");
        _logger.Log("Validating policy.");

        if (Policy.BondAmount == 0 || Policy.Valuation == 0)
        {
            _logger.Log("Land policy must specify Bond Amount and Valuation.");
            return 0;
        }

        if (Policy.BondAmount < 0.8m * Policy.Valuation)
        {
            _logger.Log("Insufficient bond amount.");
            return 0;
        }

        return Policy.BondAmount * 0.05m;
    }
}
