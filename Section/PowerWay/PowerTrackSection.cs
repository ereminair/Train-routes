using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section.PowerWay;

public class PowerTrackSection : TrackSection, ITrackSection
{
    public double Force { get; }

    public PowerTrackSection(double length, double force, double duration)
        : base(length, duration)
    {
        Force = force;
    }

    public override RouteResults Traverse(Train train)
    {
        RouteResults forceResult = new ForceApplier().ApplyForce(train, Force);
        if (Force > train.MaxForce)
        {
            return new RouteResults.ExceedingAllowedForce();
        }

        var mover = new Mover();
        RouteResults moveResult = mover.Move(train, Length);

        if (moveResult is RouteResults.SpeedIsNullOnNormalWay)
        {
            return new RouteResults.SpeedIsNullOnNormalWay();
        }

        double totalTravelTime;

        if (forceResult is RouteResults.Success forceSuccess)
        {
            totalTravelTime = forceSuccess.Time + Duration;
        }
        else
        {
            totalTravelTime = Duration;
        }

        return new RouteResults.Success(totalTravelTime);
    }
}