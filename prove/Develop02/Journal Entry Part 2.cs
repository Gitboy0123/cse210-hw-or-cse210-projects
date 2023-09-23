using System;
using System.Collections.Generic;
using System.IO;
public class Journal
{
    public List<Entry> _events = new List<Entry>();
    public string _file = "";
    public void Write()
    {
        Entry newEntry = new Entry();
        PromptGenerator prompt = new PromptGenerator();
        DateTime today = DateTime.Today;
        newEntry._date = today.ToString("MM/dd/yyyy");
        prompt.OptionPrompts();
        string userInput = "n";
        do
        {
            string newPrompt = prompt.RandomPrompt();
            newEntry._prompt = newPrompt;
            Console.WriteLine("");
            Console.Write($"{newPrompt}\nWould you like a new prompt?\n \n(if yes type 'y'for a new prompt)\n>");
            userInput = Console.ReadLine();
        }
        while (userInput == "y");
        newEntry._response = userInput;
        _events.Add(newEntry);
    }
    public void Display()
    {
        foreach (Entry entry in _events)
        {
            entry.DisplayEntry();
        };
    }
    public void SaveToFile()
    {
        Console.WriteLine("What is the filename you wish to save this as? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {

            foreach (Entry entry in _events)
            {
                outputFile.WriteLine($"{entry._date},{entry._prompt},{entry._response}");
            };
    }
    }
    public void LoadFromFile()
    {
        Console.WriteLine("What is the filename you wish to load? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        Entry prevEntry = new Entry();
        _events.Clear();
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            prevEntry._date = parts[0];
            prevEntry._prompt = parts[1];
            prevEntry._response = parts[2];
            _events.Add(prevEntry);
        }
    }
}