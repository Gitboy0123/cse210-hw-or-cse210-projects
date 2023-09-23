public class PromptGenerator
{

    public List<string> prompts;

    public string GetRandomPrompt()
    {

        prompts = new List<string>();

        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("List the 3 things you are grateful for today and why?");
        prompts.Add("What went well today?");
        prompts.Add("Who do you wish you had talked to today? What would you say?");
        prompts.Add("What is one thing you want to remember from today?");
        prompts.Add("What negative emotions am I holding onto? How can I let them go?");

        Random randomGenerator = new Random();
        int index = randomGenerator.Next(prompts.Count);

       

        return prompts[index];
    }

}