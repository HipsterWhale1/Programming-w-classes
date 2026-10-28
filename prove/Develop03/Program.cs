using System;
using System.IO;
using System.Text.Json;

//####################################
//######## CREATIVE ADDITIONS ########
//####################################
// can add back words as well as erase (next/back)
// load from json (script accepts adding more scriptures to json file)
// can customize difficulty (num of words erased each time)
// keeps punctuation even when word is hidden
// underscores show word length
// automatically resets scripture (start same scripture again, its not all hidden)
//####################################
//####################################
class Program
{
    static List<JsonFile> _rawScriptures = new List<JsonFile>();
    static List<Scripture> _scriptures = new List<Scripture>();
    static int _active = -1;
    static int _maxDifficulty = 20;
    static void Main()
    {
        LoadScriptures();
        ParseScriptures();
        //_scriptures[0].Display();
        while (true)
        {
            Menu();
        }
    }
    static public void LoadScriptures()
    {
        string allScriptures = JsonFile.ReadFile();

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true
        };

        _rawScriptures = JsonSerializer.Deserialize<List<JsonFile>>(allScriptures, options);
        if (_rawScriptures == null)
        {
            return;
        }
    }
    static public void ParseScriptures()
    {
        foreach (JsonFile rawScripture in _rawScriptures)
        {
            // Console.WriteLine($"DEBUG scripture from json: {rawScripture._reference}");
            Scripture scripture = new Scripture();
            scripture.ParseScripture(rawScripture);
            // Console.WriteLine($"DEBUG parsed scripture: {scripture._reference}");
            _scriptures.Add(scripture);

        }
    }
    static public void Menu()
    {
        Console.WriteLine($"Lets practice some scriptures! Which scripture do you want to practice? Choose a number from the scriptures below");
        SelectScripture();

        while (true)
        {
            _scriptures[_active].Display();
            Console.Write("\n");
            Console.WriteLine($"Type 'next' to erase some words. Type 'back' to return some words. Type 'difficulty' to erase more words per level. Type 'quit' to go back to scripture selection");
            string input = Console.ReadLine();
            if (input == "next")
            {
                //_scriptures[_selectedScripture].IncrementDifficulty();
                _scriptures[_active].HideWords();
                if (_scriptures[_active].Complete())
                {
                    CompleteScripture();
                    return;
                }
            }
            else if (input == "back")
            {
                _scriptures[_active].UnhideWords();
            }
            else if (input == "difficulty")
            {
                AdjustDifficulty();
            }
            else if (input == "quit")
            {
                _scriptures[_active].Reset();
                return;
            }
        }
    }
    static public void SelectScripture()
    {
        int count = 1;
        foreach (Scripture scripture in _scriptures)
        {
            Console.Write($"{count}: ");
            scripture.DisplayReference();
            count++;
        }
        string selectionString = Console.ReadLine();
        //Console.WriteLine($"DEBUG Your selected scripture is {selectionString}");
        if (int.TryParse(selectionString, out int selection))
        {
            //Console.WriteLine($"DEBUG input is an int! And _scriptures.Count-1 is {_scriptures.Count-1}");
            if (selection >= 1 && selection <= _scriptures.Count)
            {
                _active = selection-1;
                //Console.WriteLine($"DEBUG _selected scripture is {_selectedScripture}");
                return;
            }
        }
        Console.WriteLine($"Choose a number from the scriptures below");
        SelectScripture();
    }
    static public void AdjustDifficulty()
    {
        int wordsPerLevel = Scripture.GetDifficulty();
        Console.WriteLine($"Type the number of words you want to erase per level (between 1 and {_maxDifficulty}). Right now, words per level is {wordsPerLevel}");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int difficulty) && (difficulty > 0) && (difficulty < _maxDifficulty+1))
        {
            Scripture.Difficulty(difficulty);
            Console.WriteLine($"New words per level is {difficulty}");
            return;
        }
        AdjustDifficulty();
    }
    static public void CompleteScripture()
    {
        _scriptures[_active].Display();
        Console.WriteLine($"Congratulations! You memorized the scripture. There are other scriptures if you would like to memorize those as well.");
        _scriptures[_active].Reset();
    }
}