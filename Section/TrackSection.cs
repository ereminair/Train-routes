using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Section;

public abstract class TrackSection : ITrackSection
{
    public double Length { get; }

    public double Duration { get; }

    protected TrackSection(double length, double duration)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "Length must be a positive value.");
        }

        if (duration <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be a positive value.");
        }

        Length = length;
        Duration = duration;
    }

    public abstract RouteResults Traverse(Train train);
}
