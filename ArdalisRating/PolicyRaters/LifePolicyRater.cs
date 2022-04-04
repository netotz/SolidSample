using ArdalisRating.Policies;

using System;

namespace ArdalisRating.PolicyRaters;

public class LifePolicyRater : PolicyRater<LifePolicy>
{
    public LifePolicyRater(Logger logger, LifePolicy policy) : base(logger, policy)
    {
    }

    public override decimal Rate()
    {
        _logger.Log("Rating LIFE policy...");
        _logger.Log("Validating policy.");

        if (Policy.DateOfBirth == DateTime.MinValue)
        {
            _logger.Log("Life policy must include Date of Birth.");
            return 0;
        }

        if (Policy.DateOfBirth < DateTime.Today.AddYears(-100))
        {
            _logger.Log("Centenarians are not eligible for coverage.");
            return 0;
        }

        if (Policy.Amount == 0)
        {
            _logger.Log("Life policy must include an Amount.");
            return 0;
        }

        int age = DateTime.Today.Year - Policy.DateOfBirth.Year;
        if (Policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < Policy.DateOfBirth.Day ||
                DateTime.Today.Month < Policy.DateOfBirth.Month)
        {
            age--;
        }

        var baseRate = Policy.Amount * age / 200;
        return Policy.IsSmoker ? baseRate * 2 : baseRate;
    }
}
