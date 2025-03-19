using Itmo.ObjectOrientedProgramming.Lab1.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class ForceApplier
{
    public RouteResults ApplyForce(Train train, double force)
    {
        if (force > train.MaxForce)
        {
            return new RouteResults.ExceedingAllowedForce();
        }

        train.UpdateAcceleration(force / train.Mass);

        return new RouteResults.Success(train.Acceleration);
    }
}