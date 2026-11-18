class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you overcame a fear.",
        "Think of a time when you kept going even though you wanted to give up.",
        "Think of a time when you handled a difficult situation calmly.",
        "Think of a time when you defended what you believed was right.",
        "Think of a time when you faced the consequences of your choices.",
        "Think of a time when you adapted to an unexpected change.",
        "Think of a time when you asked for help when you needed it.",
        "Think of a time when you forgave someone who hurt you.",
        "Think of a time when you learned from a mistake.",
        "Think of a time when you stayed hopeful during a difficult season.",
        "Think of a time when you tried something outside your comfort zone.",
        "Think of a time when you encouraged someone who was struggling.",
        "Think of a time when you remained patient under pressure.",
        "Think of a time when you made a difficult but responsible decision.",
        "Think of a time when you stood up for yourself.",
        "Think of a time when you handled disappointment with courage.",
        "Think of a time when you took responsibility for your actions.",
        "Think of a time when you turned a setback into an opportunity.",
        "Think of a time when you showed strength while helping someone else.",
        "Think of a time when you trusted yourself to solve a problem.",
        "Think of a time when you chose kindness despite being upset.",
        "Think of a time when you accomplished something you once thought was impossible.",
        "Think of a time when you stayed true to your values.",
        "Think of a time when you faced uncertainty with faith.",
        "Think of a time when you recovered after making a serious mistake."
    };
    private List<string> _questions = new List<string> {
        "What challenges did you face during this experience?",
        "How did you respond when things became difficult?",
        "Who or what helped you through this experience?",
        "What strengths did you use?",
        "What thoughts were going through your mind at the time?",
        "What emotions did you experience along the way?",
        "What surprised you about this experience?",
        "What part of the experience was the most difficult?",
        "What part of the experience made you most proud?",
        "What choices did you make that helped you succeed?",
        "What would you do differently if you experienced this again?",
        "What advice would you give someone facing a similar situation?",
        "How did this experience change the way you see yourself?",
        "Did this experience change the way you see other people?",
        "What personal qualities did you discover or strengthen?",
        "How did this experience affect your relationships with others?",
        "What did this experience teach you about overcoming challenges?",
        "What helped you remain motivated?",
        "When did you realize that you were making progress?",
        "How might this experience help you handle a future challenge?",
        "What would you want to remember most about this experience?",
        "How did your faith influence you during this experience?",
        "What are you grateful for about this experience?",
        "How could you use what you learned to help someone else?",
        "What does this experience reveal about what matters most to you?"
    };
    
        public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        ShowPrologue();
        StartMusic();
        ShowPrompt();
        ShowQuestions();
        StopMusic();
        ShowEpilogue();
    }
    private void ShowPrompt()
    {
        int random = Random.Shared.Next(0, _prompts.Count);
        
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {_prompts[random]} ---");
        Thread.Sleep(1000);
        Console.WriteLine("When you have something in mind, press 'c' to continue");
        while (true)
        {
            if (Console.ReadLine() == "c")
            {
                break;
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth - 1));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        Console.WriteLine("Now ponder on each of the following questions as they relate to the experience in mind");
        ShowCountdown("You may begin in: ");
        Console.Clear();
    }
    private void ShowQuestions()
    {
        DateTime stopTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < stopTime)
        {
        int random = Random.Shared.Next(0, _prompts.Count);
        ShowSpinner(_questions[random]);
        }
        
    }
}