class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through your breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        ShowPrologue();
        StartMusic();
        Breathe();
        StopMusic();
        ShowEpilogue();
    }
    private void Breathe()
    {
        DateTime stopTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < stopTime)
        {
            ShowCountdown("Breathe in...");
            ShowCountdown("Hold your breath...", 6);
            ShowCountdown("Breathe out...", 6);
            ShowCountdown("Hold your breath...", 2);
        }
        Console.Write("\n");
    }

    
}