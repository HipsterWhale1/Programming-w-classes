class MusicActivity : Activity
{
    public MusicActivity() : base("Music Activity", "This activity is free to listen to the relaxing music and enjoy the pretty spinner. Enjoy.")
    {
        StartMusic();
        ShowPrologue();    
        ShowSpinner("", _duration);
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