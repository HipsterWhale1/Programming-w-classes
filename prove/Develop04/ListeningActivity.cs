class ListeningActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "What are some experiences you are grateful for?",
        "What talents or abilities do you have?",
        "What are some challenges you have overcome?",
        "Who has encouraged or supported you recently?",
        "What are some things that bring you peace?",
        "When have you felt especially close to God?",
        "What prayers have been answered in your life?",
        "What are some beautiful things you have noticed recently?",
        "What are some accomplishments you are proud of?",
        "What lessons have you learned from difficult experiences?",
        "Who has taught you something meaningful?",
        "What are some ways you have grown this year?",
        "What activities help you feel happy or energized?",
        "What scriptures or teachings have strengthened you?",
        "What are some kind things others have done for you?",
        "What opportunities do you have to serve others?",
        "What parts of your life give you hope?",
        "What qualities do you admire in other people?",
        "What memories make you smile?",
        "What are some things you are looking forward to?"
    };
    public ListeningActivity() : base("Listening Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can on a specific topic.")
    {
        ShowPrologue();
        StartMusic();
        ShowPrompt();
        CountItems();
        StopMusic();
        ShowEpilogue();
    }
    private void ShowPrompt()
    {
        int random = Random.Shared.Next(0, _prompts.Count);
        
        Console.WriteLine("List asmany responses you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[random]} ---");
        ShowCountdown("You may begin in... ");
        Console.WriteLine("When you have something in mind, press 'c' to continue");
        while (true)
        {
            if (Console.ReadLine() == "c")
            {
                break;
            }
            ClearLine();
        }
        Console.WriteLine("Now ponder on each of the following questions as they relate to the experience in mind");
        ShowCountdown("You may begin in: ", 4);
    }
    private void CountItems()
    {
        int count = 0;
        DateTime stopTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < stopTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
    }
}