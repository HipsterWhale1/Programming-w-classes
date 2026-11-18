class Word
{
    string _originalText;
    string _displayText;
    char _punctuation = '\0';
    int _length;
    bool _isHidden = false;

    public void Hide()
    {
        _isHidden = true;
        SetDisplayText();
    }
    public void Unhide()
    {
        _isHidden = false;
        SetDisplayText();
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public void SetText(string word)
    {
        char lastChar = word[^1];
        if (!char.IsLetter(lastChar))
        {
            _punctuation = lastChar;
            word = word[..^1];
        }
        _originalText = word;
        _displayText = _originalText;
        _length = _displayText.Length;
        // Console.WriteLine($"DEBUG this is a word {_displayText}");
        // Display();
    }
    public void SetDisplayText()
    {
        if (_isHidden)
        {
            _displayText = new string('_', _length);
        }
        else
        {
            _displayText = _originalText;
        }
    }
    public void Display()
    {
        Console.Write($"{_displayText}{_punctuation} ");
    }

}