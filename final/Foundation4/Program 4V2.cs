using System;
using System.Collections.Generic;

public class Activity
{
    private string date;
    private int length;

    public Activity(string date, int length)
    {
        this.date = date;
        this.length = length;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return "";
    }

    public string GetDate()
    {
        return date;
    }

    public int GetLength()
    {
        return length;
    }
}

public class Running : Activity
{
    private double distance;

    public Running(string date, int length, double distance) : base(date, length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / (GetLength() / 60.0));
    }

    public override double GetPace()
    {
        return (GetLength() / distance) * 60.0;
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Running ({GetLength()} min) - Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} seconds per mile";
    }
}

public class Cycling : Activity
{
    private double speed;

    public Cycling(string date, int length, double speed) : base(date, length)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * (GetLength() / 60.0));
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return (60.0 / GetSpeed()) * 60.0;
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Cycling ({GetLength()} min) - Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} seconds per mile";
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(string date, int length, int laps) : base(date, length)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return (laps * 50.0) / (1000.0 * 60.0);
    }

    public override double GetSpeed()
    {
        return (GetDistance() / (GetLength() / 60.0));
    }

    public override double GetPace()
    {
        return (GetLength() / GetDistance()) * 60.0;
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Swimming ({GetLength()} min) - Distance {GetDistance()} km, Speed {GetSpeed()} kph, Pace: {GetPace()} seconds per km";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running("2023-11-03", 1800, 3.0);
        Cycling cycling = new Cycling("2023-11-03", 1800, 6.0);
        Swimming swimming = new Swimming("2023-11-03", 1800, 30);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}