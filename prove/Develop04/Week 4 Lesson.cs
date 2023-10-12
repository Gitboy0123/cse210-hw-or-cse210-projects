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
        Console.WriteLine("Starting {0} activity...", Name);
        Console.WriteLine("Enter the duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    public virtual void Run()
    {
        Console.WriteLine("Running {0} activity...", Name);
    }

    public virtual void End()
    {
        Console.WriteLine("Ending {0} activity...", Name);
        Console.WriteLine("Good job! You completed the {0} activity in {1} seconds.", Name, Duration);
        Thread.Sleep(3000);
    }

    protected void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

public class BreathingActivity : Activity
{
    public override void Run()
    {
        Console.WriteLine(Description);
        base.Run();

        Console.WriteLine("Start breathing...");
        Thread.Sleep(3000);

        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Breathe in...");
            DisplaySpinner(2);
            Console.WriteLine("Breathe out...");
            DisplaySpinner(2);
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
        Console.WriteLine(Description);
        base.Run();
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");

        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Reflect on the prompt...");
            DisplaySpinner(2);
            Console.WriteLine("What did you learn?");
            DisplaySpinner(2);
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
        Console.WriteLine(Description);
        base.Run();
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");

        Console.WriteLine("Start listing items...");
        Thread.Sleep(3000);

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
        new BreathingActivity
        {
            Name = "Breathing Activity",
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        },
        new ReflectionActivity
        {
            Name = "Reflection Activity",
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
        },
        new EnumerationActivity
        {
            Name = "Enumeration Activity",
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        },
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
