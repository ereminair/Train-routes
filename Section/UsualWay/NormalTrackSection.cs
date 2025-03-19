using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section.UsualWay;

public class NormalTrackSection : TrackSection, ITrackSection
{
    public NormalTrackSection(double length, double duration)
        : base(length, duration) { }

    public override RouteResults Traverse(Train train)
    {
        var mover = new TrainMover();
        RouteResults moveResult = mover.Move(train, Length, Duration);

        if (moveResult is RouteResults.Success success)
        {
            return new RouteResults.Success(success.Time + Duration);
        }

        return moveResult;
    }
}