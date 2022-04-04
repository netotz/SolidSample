using ArdalisRating.Policies;

namespace ArdalisRating.PolicyRaters;

public abstract class PolicyRater<TPolicy>
    where TPolicy : Policy
{
    protected readonly Logger _logger;

    protected TPolicy Policy { get; }

    public PolicyRater(Logger logger, TPolicy policy)
    {
        _logger = logger;
        Policy = policy;
    }

    public abstract decimal Rate();
}
