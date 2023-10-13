using System;
using System.Threading;

// Base class for activities
class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
        Duration = 0;
    }

    public void SetDuration()
    {
        Console.Write($"Set the duration (in seconds) for {Name}: ");
        Duration = int.Parse(Console.ReadLine());
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {Name} - {Description}");
        Thread.Sleep(2000); // Pause for 2 seconds

        // Implement your specific activity logic in derived classes
    }

    public void EndActivity()
    {
        Console.WriteLine($"Good job! You've completed {Name} for {Duration} seconds.");
        Thread.Sleep(2000); // Pause for 2 seconds
    }
}

// Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "Relax by focusing on your breath")
    {
    }

    public new void StartActivity()
    {
        base.StartActivity();
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
        EndActivity();
    }
}

// Reflection Activity
class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection", "Reflect on past experiences")
    {
    }

    public new void StartActivity()
    {
        base.StartActivity();
        // Implement your reflection logic here
        EndActivity();
    }
}

// Enumeration Activity
class EnumerationActivity : Activity
{
    public EnumerationActivity() : base("Enumeration", "List things in a specific category")
    {
    }

    public new void StartActivity()
    {
        base.StartActivity();
        // Implement your enumeration logic here
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create activity objects
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        EnumerationActivity enumerationActivity = new EnumerationActivity();

        // Add activities to a menu system
        Activity[] activities = { breathingActivity, reflectionActivity, enumerationActivity };

        Console.WriteLine("Welcome to the Activity Program");
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            for (int i = 0; i < activities.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {activities[i].Name}");
            }

            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice >= 0 && choice < activities.Length)
            {
                activities[choice].SetDuration();
                activities[choice].StartActivity();
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}
