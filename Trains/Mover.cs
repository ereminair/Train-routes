using Itmo.ObjectOrientedProgramming.Lab1.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Mover
{
    public RouteResults Move(Train train, double distance)
    {
        double remainingDistance = distance;
        double totalTime = 0;

        while (remainingDistance > 0)
        {
            double resultingSpeed = train.Speed + (train.Acceleration * train.Precision);
            double traveledDistance = resultingSpeed * train.Precision;

            if (traveledDistance > remainingDistance)
            {
                traveledDistance = remainingDistance;
            }

            remainingDistance -= traveledDistance;
            train.UpdateSpeed(resultingSpeed);
            totalTime += train.Precision;
        }

        return new RouteResults.Success(totalTime);
    }
}