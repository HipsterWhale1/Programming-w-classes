using System.Text.Json;

class JsonFile
{
    static string _filePath = "./Scriptures.json";
    string _book = "";
    string _reference = "";
    string _verse = "";

    static public string ReadFile()
    {
        return File.ReadAllText(_filePath);
    }

    public string GetBook()
    {
        return _book;
    }
    public string GetReference()
    {
        return _reference;
    }
    public string GetVerse()
    {
        return _verse;
    }
}

