using ArdalisRating.Policies;

namespace ArdalisRating.PolicyRaters;

public abstract class PolicyRater<TPolicy>
    where TPolicy : Policy
{
    protected readonly RatingEngine _engine;
    protected readonly Logger _logger;

    protected TPolicy Policy { get; }

    public PolicyRater(RatingEngine engine, Logger logger, TPolicy policy)
    {
        _engine = engine;
        _logger = logger;
        Policy = policy;
    }

    protected abstract void Rate();
}
