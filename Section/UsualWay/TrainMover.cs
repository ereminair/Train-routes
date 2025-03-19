using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section.UsualWay;

public class TrainMover
{
    public RouteResults Move(Train train, double distance, double timeLimit)
    {
        if (train.Speed <= 0)
        {
            return new RouteResults.SpeedIsNullOnNormalWay();
        }

        double potentialDistance = train.Speed * timeLimit;

        if (potentialDistance > distance)
        {
            potentialDistance = distance;
        }

        double travelTime = potentialDistance / train.Speed;

        return new RouteResults.Success(travelTime);
    }
}
