

class Reference
{
    string _book = "";
    int _chapter;
    int _startVerse = -1;
    int _endVerse = -1;

    public void Display()
    {
        string reference = $"{_book} {_chapter}:{_startVerse}";
        if (_endVerse != -1)
        {
            reference += _endVerse;
        }
        Console.WriteLine(reference);
    }

}