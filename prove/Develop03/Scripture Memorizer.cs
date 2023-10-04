using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Console.Clear();
        scripture.DisplayScripture();

        while (true)
        {
            Console.WriteLine("Press enter to hide a word or type quit to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }
            else
            {
                Console.Clear();
                scripture.HideWord();
                scripture.DisplayScripture();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("Congratulations, you have memorized the scripture!");
                    break;
                }
            }
        }
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = new Reference(reference);
        this.words = text.Split(' ').Select(wordText => new Word(wordText)).ToList();
    }

    public void DisplayScripture()
    {
        Console.WriteLine(reference.ToString());
        foreach (Word word in words)
        {
            if (word.IsHidden)
            {
                Console.Write("_____ ");
            }
            else
            {
                Console.Write(word.Text + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideWord()
    {
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            Random rand = new Random();
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].IsHidden = true;
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class Reference
{
    public string Text { get; private set; }

    public Reference(string reference)
    {
        Text = reference;
    }

    public override string ToString()
    {
        return Text;
    }
}

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}
