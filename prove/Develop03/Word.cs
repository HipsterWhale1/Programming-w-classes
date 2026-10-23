class Word
{
    string _text;
    int _length;
    bool _isHidden = false;

    public void Hide()
    {
        _isHidden = true;
    }
    
    public void GetWordLength()
    {
        _length = _text.Length;
    }
    public void GetDisplayString()
    {
        if (_isHidden == true)
        {
            _text = new string('_', _length);
        }
    }

    public void Display()
    {
        Console.Write($"_text ");
    }

}