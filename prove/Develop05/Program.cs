using System;
using System.Collections.Generic;

public class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool IsComplete { get; set; }

    public virtual void RecordEvent()
    {
        if (!IsComplete)
        {
           
            IsComplete = true;
        }
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
        IsComplete = false;
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCompletions { get; set; }
    public int CurrentCompletions { get; set; }

    public ChecklistGoal(string name, int value, int targetCompletions)
    {
        Name = name;
        Value = value;
        TargetCompletions = targetCompletions;
        CurrentCompletions = 0;
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            CurrentCompletions++;
            if (CurrentCompletions == TargetCompletions)
            {
                IsComplete = true;
                Value += 500;
            }
            else
            {
                Value += 50;
            }
        }
    }
}

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int userScore = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordGoalCompletion(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            goal.RecordEvent();
            userScore += goal.Value;
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}. [{(goal.IsComplete ? "X" : " ")}] {goal.Name} ({goal.Value} points)");
            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"   Completed {checklistGoal.CurrentCompletions}/{checklistGoal.TargetCompletions} times");
            }
        }
    }

    public int GetUserScore()
    {
        return userScore;
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

       
        manager.AddGoal(new SimpleGoal("Run a marathon", 1000));
        manager.AddGoal(new EternalGoal("Read scriptures", 100));
        manager.AddGoal(new ChecklistGoal("Attend the temple", 50, 10));

       
        manager.RecordGoalCompletion(0);
        manager.RecordGoalCompletion(1);
        manager.RecordGoalCompletion(2);
        manager.RecordGoalCompletion(2);

       
        manager.DisplayGoals();
        Console.WriteLine($"User's Score: {manager.GetUserScore()}");
    }
}
