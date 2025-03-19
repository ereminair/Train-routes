namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train
{
    public double Mass { get; }

    public double Speed { get; private set; }

    public double Acceleration { get; private set; }

    public double MaxForce { get; }

    public double Precision { get; }

    public Train(double mass, double maxForce, double precision)
    {
        if (mass <= 0)
            throw new ArgumentOutOfRangeException(nameof(mass), "Mass must be a positive value.");

        Mass = mass;
        MaxForce = maxForce;
        Speed = 0;
        Acceleration = 0;
        Precision = precision;
    }

    public void UpdateSpeed(double newSpeed)
    {
        Speed = newSpeed;
    }

    public void UpdateAcceleration(double newAcceleration)
    {
        Acceleration = newAcceleration;
    }
}