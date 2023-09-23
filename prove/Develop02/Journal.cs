using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{

    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

    }

    public void SaveToFile(string file)
    {

        Console.WriteLine("Saving file .......");

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entries in _entries)
            {
                outputFile.WriteLine($"{entries.Date},{entries.PromptText},{entries.EntryText}");  
            }
        }


    }

    public void LoadFromFile(string file)
    {

    }


}