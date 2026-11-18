using System.Media;

class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    private const int _spinnerDuration = 5; //in seconds
    private int _spinnerSpeed = 200; //in milliseconds (lower is faster)
    SoundPlayer _music = new SoundPlayer("calmMusic.wav");

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _music.Load();
    }
    protected void ShowPrologue()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description+"\n");
        Console.WriteLine($"How long (in seconds) do you want the activity to last?");
        _duration = Program.Input2Int();
        Console.Clear(); 
        ShowSpinner("Get Ready...\n");
    }
    
    protected void ShowSpinner(string text = "", int time = _spinnerDuration)
    {
        DateTime stopTime = DateTime.Now.AddSeconds(time);

        List<string> symbols = ["` ", " '", " -", " .", ", ", "- "];
        int i = 0;
        Console.WriteLine(text);
        while (DateTime.Now < stopTime)
        {
            Console.Write($"\b{symbols[i]}");
            i = (i + 1) % symbols.Count;
            Thread.Sleep(_spinnerSpeed);
            Console.Write("\b \b");
        }
        Console.Write("\b");
    }
    protected void ShowCountdown(string text, int time = _spinnerDuration)
    {
        Console.Write(text);
        int i = time;
        while (i > 0)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i--;
        }
        Console.Write("\n");
    }
    protected void ShowEpilogue()
    {
        ShowSpinner("Well Done!\n");
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}!");
    }
    protected void ClearLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.BufferWidth - 1));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
    protected void StartMusic()
    {
        _music.Load();
        _music.PlayLooping();
    }

    protected void StopMusic()
    {
        _music.Stop();
    }
}

