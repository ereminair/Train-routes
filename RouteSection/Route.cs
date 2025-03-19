using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Section;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection;

public class Route : ITrackSection
{
    private readonly List<TrackSection> _trackSections;

    public double MaxEndSpeed { get; }

    public Route(double maxEndSpeed)
    {
        if (maxEndSpeed < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxEndSpeed), "MaxEndSpeed must be a positive value.");
        }

        _trackSections = new List<TrackSection>();
        MaxEndSpeed = maxEndSpeed;
    }

    public void AddSection(TrackSection section)
    {
        _trackSections.Add(section);
    }

    public RouteResults Traverse(Train train)
    {
        double totalTime = 0;

        foreach (TrackSection section in _trackSections)
        {
            RouteResults result = section.Traverse(train);

            if (result is RouteResults.Success success)
            {
                totalTime += success.Time;
            }
            else
            {
                return result;
            }
        }

        if (train.Speed > MaxEndSpeed)
        {
            return new RouteResults.ViolatingSpeedAtTheEndOfTheRoute();
        }

        return new RouteResults.Success(totalTime);
    }
}