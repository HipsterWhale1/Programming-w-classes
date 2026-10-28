using System.Text.Json;
using System.Linq;
using System.Globalization;
class Scripture
{
    Reference _reference = new Reference();
    List<Word> _words = new List<Word>();
    static int _wordsPerLevel = 15;

    public void ParseScripture(JsonFile rawScripture)
    {
        _reference.SetReference(rawScripture.GetBook(), rawScripture.GetReference());

        List<string> listText = rawScripture.GetVerse().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
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
        Console.WriteLine($"\n");
        _reference.Display();
        foreach(Word word in _words)
        {
            //add line where if number, newline (for each verse)
            word.Display();
        }
        Console.WriteLine($"\n");
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
        // Console.WriteLine($"DEBUG hidewords was called");
        List<Word> displayedWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                displayedWords.Add(word);
            }
        }
        for (int i = 0; i < _wordsPerLevel && displayedWords.Count > 0; i++)
        {
            int wordsTotal = displayedWords.Count;
            int selection = Random.Shared.Next(0, wordsTotal);
            displayedWords[selection].Hide();
            displayedWords.RemoveAt(selection);
            // //DEBUG BELOW
            // int countUnhidden = 0;
            // int countHidden = 0;
            // foreach (Word word in _words)
            // {
            //     if (!word._isHidden)
            //     {
            //         countUnhidden++;
            //     }
            //     if (word._isHidden)
            //     {
            //         countHidden++;
            //     }
            // }
            // Console.WriteLine($"DEBUG _wordsCount() is {_words.Count()} and wordsTotal is {wordsTotal-1} and CountUnhidden is: {countUnhidden} and CountHidden is {countHidden}. These two added is {countUnhidden + countHidden} = {_words.Count()}");
            // if (countUnhidden != wordsTotal-1)
            // {
            //     Console.WriteLine($"DEBUG ERROR they are not equal");
            // }
        }
        return;
    }
    public void UnhideWords()
    {
        //Console.WriteLine($"DEBUG unhidewords was called");
        List<Word> hiddenWords = new List<Word>();
        if (_words.Count() == 0)
        {
            
        }
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                hiddenWords.Add(word);
            }
        }
        for (int i = 0; i < _wordsPerLevel && hiddenWords.Count > 0; i++)
        {
            int wordsTotal = hiddenWords.Count();
            int selection = Random.Shared.Next(0, wordsTotal);
            hiddenWords[selection].Unhide();
            hiddenWords.RemoveAt(selection);
        }
    }
    public bool Complete()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
    public static void Difficulty(int numWords)
    {
        Scripture._wordsPerLevel = numWords;
    }
    public void Reset()
    {
        foreach (Word word in _words)
        {
            word.Unhide();
        }
    }
    public static int GetDifficulty()
    {
        return _wordsPerLevel;
    }
}
