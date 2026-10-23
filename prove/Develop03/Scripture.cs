using System.Text.Json;
class Scripture
{
    JsonFile _text = new JsonFile();
    Reference _reference = new Reference();
    List<Word> _words = new List<Word>();
    List<Word> _displayedWords = new List<Word>();
    int _wordsPerLevel;
    int _difficulty = 0;

    public void SetScripture(int number)
    {
        //load textfile
        //set ref
        //set words
    }
        public void LoadScripture()
    {
        string allScriptures = File.ReadAllText(_text._filePath);
        List<JsonFile> entries = JsonSerializer.Deserialize<List<JsonFile>>(allScriptures);
    
    }
    public void Display()
    {
        _reference.Display();
        foreach(Word word in _words)
        {
            word.Display();
        }
    }
    public void IncrementDifficulty()
    {
        if(_difficulty < 5)
        {
            _difficulty++;
        }

    }
    public void HideWords()
    {
        int size = _words.Count;
        foreach(Word word in _words)
        {
            int hide = Random.Shared.Next(0, 6 - _difficulty);
            if(hide == 1)
            {
                word.Hide();
            }
        }
    }

}