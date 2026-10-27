using System.Text.Json;
using System.Linq;
using System.Globalization;
class Scripture
{
    public Reference _reference = new Reference();
    List<Word> _words = new List<Word>();
    int _wordsPerLevel = 5;

    public void ParseScripture(JsonFile rawScripture)
    {
        _reference.SetReference(rawScripture._book, rawScripture._reference);

        List<string> listText = rawScripture._verse.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        foreach (string text in listText)
        {
            Word word = new Word();
            word.SetText(text);
            _words.Add(word);
            //Console.Write($"DEBUG {word._displayText}");
        }
    }
    public void Display()
    {
        _reference.Display();
        foreach(Word word in _words)
        {
            //add line where if number, newline (for each verse)
            word.Display();
        }
    }
    public void DisplayReference()
    {
        _reference.Display();
    }
    // public void IncrementDifficulty()
    // {
    //     if(_difficulty < 5)
    //     {
    //         _difficulty++;
    //     }
    //     // set _wordsPerLevel;

    // }
    public void HideWords()
    {
        Console.WriteLine($"DEBUG hidewords was called");
        List<Word> displayedWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word._isHidden)
            {
                displayedWords.Add(word);
            }
        }
        for(int i = 0; i < _wordsPerLevel; i++)
        {
            int wordsTotal = displayedWords.Count();
            int selection = Random.Shared.Next(0, wordsTotal);
            _words[selection].Hide();
            displayedWords.RemoveAt(selection);
            //DEBUG BELOW
            int countUnhidden = 0;
            foreach (Word word in _words)
            {
                if (!word._isHidden)
                {
                    countUnhidden++;
                }

            }
            Console.WriteLine($"CountUnhidden is: {countUnhidden} and wordsTotal is {wordsTotal}");
            if (countUnhidden != wordsTotal)
            {
                Console.WriteLine($"DEBUG ERROR they are not equal");
            }
        }
    }
    public void UnhideWords()
    {
        Console.WriteLine($"DEBUG unhidewords was called");
        List<Word> hiddenWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word._isHidden)
            {
                hiddenWords.Add(word);
            }
        }
        for(int i = 0; i < _wordsPerLevel; i++)
        {
            int unhide = Random.Shared.Next(0, hiddenWords.Count());
            _words[unhide].Unhide();
            hiddenWords.RemoveAt(unhide);
        }
    }

}