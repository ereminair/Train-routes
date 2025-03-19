using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section.Station;

public class StationTrackSection : TrackSection, ITrackSection
{
    public double SpeedLimit { get; }

    public StationTrackSection(double length, double speedLimit, double loadingTime)
        : base(length, loadingTime)
    {
        SpeedLimit = speedLimit;
    }

    public override RouteResults Traverse(Train train)
    {
        if (train.Speed > SpeedLimit)
        {
            return new RouteResults.ViolatingSpeedLimitOnStation();
        }

        double totalTime = (Length / train.Speed) + Duration;
        return new RouteResults.Success(totalTime);
    }
}