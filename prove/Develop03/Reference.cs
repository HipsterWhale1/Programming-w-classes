

class Reference
{
    string _book = "";
    int _chapter = -1;
    string _secondPart = "";
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
    public void SetReference(string book, string reference)
    {
        _book = book;
        List<string> splitReference = new List<string>();
        splitReference = reference.Split(':').ToList();
        _chapter = int.Parse(splitReference[0]);
        _secondPart = splitReference[1];

        if (_secondPart.Contains("-"))
        {
            List<string> splitVerse = new List<string>();
            splitVerse = _secondPart.Split('-').ToList();
            _startVerse = int.Parse(splitVerse[0]);
            _endVerse = int.Parse(splitVerse[1]);
        }


    }
}