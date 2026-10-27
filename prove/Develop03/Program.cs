using System;
using System.IO;
using System.Text.Json;

class Program
{
    static List<JsonFile> _rawScriptures = new List<JsonFile>();
    static List<Scripture> _scriptures = new List<Scripture>();
    static int _selectedScripture = -1;
    static void Main()
    {
        LoadScriptures();
        ParseScriptures();
        while (true)
        {
            Menu();
        }
    }
    static public void LoadScriptures()
    {
        string allScriptures = File.ReadAllText(JsonFile._filePath);

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
            Console.WriteLine($"DEBUG scripture from json: {rawScripture._reference}");
            Scripture scripture = new Scripture();
            scripture.ParseScripture(rawScripture);
            Console.WriteLine($"DEBUG parsed scripture: {scripture._reference}");
            _scriptures.Add(scripture);

        }
    }
    static public void Menu()
    {
        Console.WriteLine($"Lets practice some scriptures! Which scripture do you want to practice? Choose a number from the scriptures below");
        SelectScripture();

        while (true)
        {
            _scriptures[_selectedScripture].Display();
            Console.WriteLine($"Type 'next' to increase the difficulty. Type 'back' to decrease the difficulty. Type 'quit' to go back to scripture selection");
            string input = Console.ReadLine();
            if (input == "next")
            {
                //_scriptures[_selectedScripture].IncrementDifficulty();
                _scriptures[_selectedScripture].HideWords();
            }
            else if (input == "back")
            {
                _scriptures[_selectedScripture].UnhideWords();
            }
            else if (input == "quit")
            {
                return;
            }
        }
    }
    static public void SelectScripture()
    {
        int count = 0;
        foreach (Scripture scripture in _scriptures)
        {
            Console.Write($"{count}: ");
            scripture._reference.Display();
            count++;
        }
        string selectionString = Console.ReadLine();
        if (int.TryParse(selectionString, out int selection))
        {
            if (selection <= 0 && selection >= (_scriptures.Count-1))
            {
                _selectedScripture = selection;
                return;
            }
        }
        Console.WriteLine($"Choose a number from the scriptures below");
        SelectScripture();
    }
}