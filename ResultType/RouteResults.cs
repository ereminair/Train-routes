namespace Itmo.ObjectOrientedProgramming.Lab1.ResultType;

public abstract record RouteResults
{
    private RouteResults() { }

    public sealed record Success(double Time) : RouteResults;

    public sealed record ViolatingSpeedLimitOnStation() : RouteResults;

    public sealed record SpeedIsNullOnNormalWay() : RouteResults;

    public sealed record ViolatingSpeedAtTheEndOfTheRoute() : RouteResults;

    public sealed record ExceedingAllowedForce() : RouteResults;
}