using System;

namespace Journal
{

    public string _date;
    public string _promptText;
    public string _entryText;
    public void Dipslay()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}"); 
    }


}