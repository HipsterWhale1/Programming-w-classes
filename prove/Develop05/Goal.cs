using System.IO;
using System.IO.Enumeration;

class Goal
{
    private string _title;
    private string _description;
    private int _points;
    private string _filename;

    public Goal(string title, string description, int points, string filename)
    {
        _title = title;
        _description = description;
        _points = points;
        _filename = filename
    }
    public void RecordEvent()
    {
        
    }
    public void IsComplete()
    {
        
    }
    public void GetDetailsString()
    {
        
    }
    public void Save(string outputStream)
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            outputFile.WriteLine(outputStream);
        }
    }
    public void Load(string inputStream)
    {
        string[] lines = System.IO.File.ReadAllLines(_filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~");

            _title = parts[0];
            _description = parts[1];
            _points = int.Parse(parts[2]);
            _filename = parts[3];
        }
    }

}