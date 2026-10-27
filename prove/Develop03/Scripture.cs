using System.Text.Json;
using System.Linq;
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
        }
    }
    public void Display()
    {
        _reference.Display();
        foreach(Word word in _words)
        {
            word.Display();
        }
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
            int hide = Random.Shared.Next(0, displayedWords.Count());
            _words[hide].Hide();
            displayedWords.RemoveAt(hide);
        }
    }
    public void UnhideWords()
    {
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