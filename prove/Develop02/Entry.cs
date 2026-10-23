using System.IO;

public class Entry

{
    //date entry was created
    public string _date = "";
    //prompt actively in use
    public string _prompt = "";
    //list of default potential prompts
    //has test
    public static List<string> _prompts = new List<string>
    {
        "What was the best and worst thing about my day today?", "What was a spiritual experience i had today?", "What was something funny today?", "What did someone do to serve me today?", "What do i want to change or do better?", "What am i grateful for?", "Did i meet someone new?", "What did i learn today?"
    };
    //user input, their journal writing
    public string _response = "";
    //list of printed prompts and user responses (does not include the date!)
    public List<string> _entryContents = new List<string>();
    //used in DisplayPrompt to track if its the first prompt given (just for string grammar)
    public string _firstPrompt = "";
    //used to know if the journaling loop should continue
    public Boolean _continueJournaling = true;  
    public string _filePath; 
    public int _fileNum;

    public Entry()
    {
        GetTodaysDate();
    }
    //has test - called in Entry constructor
    public void GetTodaysDate()
    {
        // DateTime dayTime = DateTime.Today; 
        // _date = dayTime.ToString();
        // _date = _date[..^12]; 
        _date = DateTime.Today.ToString("MM/dd/yyyy"); 
    }
    //has test - called in DisplayPrompt() - gets a random prompt from the list and sets _prompt
    public void GetRandomPrompt()
    {
        int size = _prompts.Count();
        int index = Random.Shared.Next(0, size);
        _prompt = _prompts[index];
    }
    //has test - called in EditEntry()
    public void DisplayPrompt()
    {
        //modifies language slightly if this is not the first prompt (a prompt >> another prompt)
        Console.WriteLine($"Would you like a{_firstPrompt} prompt? yes/no (if not, you can journal freely)");
        _response = Console.ReadLine();
        if (_response == "yes")
        {
            GetRandomPrompt();
            Console.WriteLine($"Prompt: {_prompt} Write your thoughts:");
            //adds the prompt to the entry contents
            _entryContents.Add($"{_prompt}&\n");
            //sets all future display prompts to say 'another'
            _firstPrompt = "nother";
        }
        else
        {
            Console.WriteLine($"No prompt, just write your thoughts:");
        }
        }
    //has test - called in Journal.EditEntry()
    public void WriteEntry()
    {
        //Console.WriteLine($"Todays date is: {_date}");
        //prints anything if already there
        
        //PrintEntryContents();
        _continueJournaling = true;
        while (_continueJournaling == true)
        {
            //Console.WriteLine($"DEBUG Start thw ehile loop");
            DisplayPrompt();
            _response = Console.ReadLine();
            _entryContents.Add($"{_response}&\n");
            ContinueEntry();
        }
    }
    //has test - called in EditEntry()
    public void ContinueEntry()
    {
        string userInput = "";

        Console.WriteLine($"Would you like to continue journaling? yes/no");
        //gets user decicion
        userInput = Console.ReadLine();
        if (userInput == "yes")
        {
            _continueJournaling = true;
        }
        else
        {
            //confirms that user wants to exist (if anything was typed other than 'yes')
            Console.WriteLine("Are you finished with this entry? yes/no");
            //gets user confirmation to exit
            userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                _continueJournaling = false;
            }
            //continues journaling (if anything was typed other than 'yes')
            else 
            {
                _continueJournaling = true;
            }
        }
    }
    //has test
    public void PrintEntryContents()
    {
        foreach(string element in _entryContents)
        {
            string tempElement = element.TrimEnd('&');
            Console.WriteLine(element);
        }
    }
    //has test
    public void SaveEntry()
    {
        //Console.Write("DEBUG: SaveEntry()");
        using (StreamWriter output = new StreamWriter(_filePath))
        {  
            // foreach (Entry entryElement in _entries)
            // {
            output.WriteLine(_date);
            foreach (string element in _entryContents)
            {
                output.WriteLine(element);
            }
            // }
        }
    }
}