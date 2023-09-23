using System;
using System.Collections.Generic;

public class JournalPrompt
{
    public static string[] _prompt =
    {
        "What negative emotions am I holding onto? How can I let them go?",
        "What is your happy place? Describe it in detail",
        "What steps did you take today towards a goal you're working on?",
        "What are three things you're grateful for today?",
        "If I had one thing I could do over today, what would it be?",
        "What do you feel is your purpose in life, and has that answer changed in the last five years?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "List the 3 things you are grateful for today and why.",
        "What is one thing you want to remember from today?",
        "What went well today?",
        "What's a simple pleasure in your life that you are thankful for?",
        "How can you make tomorrow 'even' better than today?",
        "Who do you wish you had talked to today? What would you say?",
        "Did you read a book today? If so what?",
    };
    public List<string> _journalPrompt = new List<string>(_prompt);
    public JournalPrompt()
    {

    }
    public void Display()
    {
        var random = new Random();
        int index = random.Next(_journalPrompt.Count);
        string journalPrompt = _journalPrompt[index];
        Console.WriteLine($"\n{journalPrompt}");
    }
    public string GetPrompt()
    {
        var random = new Random();
        int index = random.Next(_journalPrompt.Count);
        string journalPrompt = _journalPrompt[index];
        return journalPrompt;
    }
}