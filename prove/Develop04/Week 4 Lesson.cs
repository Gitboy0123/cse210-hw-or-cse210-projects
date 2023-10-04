using System;
using System.Threading;
using System.Collections.Generic;

public class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public virtual void Start()
    {
        Console.WriteLine("Starting {0} activity...", BreathingActivity);
        Console.WriteLine("Enter the duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
    }

    public virtual void Run()
    {
        Console.WriteLine("Running {0} activity...", Reflection Activity);
    }

    public virtual void End()
    {
        Console.WriteLine("Ending {0} activity...", EnumerationActivity);
    }
}

public class BreathingActivity : Activity
{
    public override void Run()
    {
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
    }
}

public class ReflectionActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    };

    public override void Run()
    {
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");

        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Reflect on the prompt...");
            Thread.Sleep(1000);
            Console.WriteLine("What did you learn?");
            Thread.Sleep(1000);
        }
    }
}

public class EnumerationActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };

    public override void Run()
    {
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");

        Console.WriteLine("Start listing items...");
        Thread.Sleep(1000);

        List<string> items = new List<string>();
        for (int i = 0; i < Duration; i++)
        {
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine("You listed {0} items:", items.Count);
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        Activity activity = menu.GetSelectedActivity();

        activity.Start();
        activity.Run();
        activity.End();
    }
}

public class Menu
{
    private Activity[] activities = new Activity[]
    {
        new BreathingActivity(),
        new ReflectionActivity(),
        new EnumerationActivity(),
    };

    public void ShowMenu()
    {
        Console.WriteLine("Select an activity:");
        for (int i = 0; i < activities.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].Name}");
        }
    }

    public Activity GetSelectedActivity()
    {
        ShowMenu();

        int choice = int.Parse(Console.ReadLine());
        return activities[choice - 1];
    }
}
