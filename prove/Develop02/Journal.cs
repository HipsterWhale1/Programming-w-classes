using System;
using System.IO;

public class Journal
{
    //apparently better than just .\
    public string _folder = AppContext.BaseDirectory;
    //AppDomain.CurrentDomain.BaseDirectory;
    public string _fileName = "journal_entry_";
    string _fileType = ".txt";
    public Entry _currentEntry;
    public List<Entry> _entries = new List<Entry>();
    //prints all entries
    public Journal()
    {
        Directory.CreateDirectory(_folder);
    }
    //has test
    public void LoadEntries()
    {
        int fileCount = Directory.EnumerateFiles(_folder, _fileName+"*").Count();
        //Console.WriteLine($"DEBUG beginning of loadentries file count is : {fileCount}, and _entries.Count() is: {_entries.Count}");
        int fileCounter = 0;
        int sectionCounter = 0;
        List<string> textFile;
        //Console.WriteLine("started 'while' in LoadEntries()");
        while (fileCounter <= fileCount)
        {
            //Console.WriteLine($"DEBUG Started while loop {fileCounter+1} times");
            string filePath = $"{_folder}{_fileName}{fileCounter}{_fileType}";
            //Console.WriteLine($"DEBUG Filepath: {filePath}");
            if (File.Exists(filePath))
            {
                textFile = File.ReadAllLines(filePath).ToList();
            }
            else
            {
                //Console.WriteLine("There are no entries to load. Choose a different action");
                //Console.WriteLine($"DEBUG ending of loadentries file couunt is : {fileCount}, and _entries.Count() is: {_entries.Count()}");
                //Console.WriteLine($"Return early");
                return;
            }
            //setting _date as first line
            _entries.Add(new Entry());
            //Console.WriteLine($"DEBUG added file to _entries {fileCounter+1} times");
            _entries[fileCounter]._date = textFile[0];
            _entries[fileCounter]._fileNum = fileCounter;
            //j testing, remove this when done
            //Console.WriteLine(_entries[fileCounter]._date);
            //filling out _entryContent
            _entries[fileCounter]._entryContents.Add(textFile[1]);
            //Console.WriteLine($"Lines in file{fileCounter}: {textFile.Count()}");
            for (int lineCounter = 2; lineCounter < textFile.Count; lineCounter++)
            {
                //Console.WriteLine("Started loop");
                //Console.WriteLine($"DEBUG lineCounter is {lineCounter}");
                //Console.WriteLine($"DEBUG textFile[lineCounter] is {textFile[lineCounter]}");
                if (textFile[lineCounter].EndsWith('&'))
                {
                    _entries[fileCounter]._entryContents.Add(textFile[lineCounter]);
                    //Console.WriteLine($"Filecount: {fileCounter}, line count: {lineCounter}, yes &");
                    sectionCounter++;
                }
                else
                {
                    _entries[fileCounter]._entryContents[sectionCounter] += textFile[lineCounter];
                    //Console.WriteLine($"Filecount: {fileCounter}, line count: {lineCounter}, no &");
                }
                //Console.WriteLine("completed loop");
            }
            sectionCounter = 0;
            fileCounter++;
        }
    //Console.WriteLine($"DEBUG ending of loadentries file count is : {fileCount}, and _entries.Count() is: {_entries.Count()}");
    }
    //has test
    public void TodaysEntry()
    {
        //Console.WriteLine("=> Start actual function");
        int newest = _entries.Count - 1;
        //Console.WriteLine($"var newest is: {newest}");
        if (newest == -1)
        {
            _currentEntry = new Entry();
            _entries.Add(_currentEntry);
            newest++;
            _currentEntry._fileNum = newest;
        }
        else
        {
            if (_entries[newest]._date == DateTime.Today.ToString("MM/dd/yyyy"))
            {
                Console.WriteLine($"There is already an entry for todays date: {_entries[newest]._date}, you may add more in this entry");
                _currentEntry = _entries[newest];
            }
            else
            {
                _currentEntry = new Entry();
                //Console.WriteLine($"count of entriesbefore: {_entries.Count()}");
                _entries.Add(_currentEntry);
                _currentEntry._fileNum = newest + 1;
                //Console.WriteLine($"count of entries after: {_entries.Count()}");
            }
        }
    }
    //has test
    public void EditEntry()
    {
        //ChooseEntry1();
        _currentEntry.WriteEntry();
        Console.WriteLine($"You may save the entry. Would you like to review entry before saving? yes/no");
        if (Console.ReadLine() == "yes")
        {
            _currentEntry.PrintEntryContents();
        }
        Save();
    }
    public void Save()
    {
        Console.WriteLine($"Do you want to save entry? yes/no");
        if (Console.ReadLine() == "yes")
        {
            _currentEntry._filePath = $"{_folder}{_fileName}{_currentEntry._fileNum}{_fileType}";
            _currentEntry.SaveEntry();
            Console.WriteLine($"Entry Saved!");
        }
        else
        {
            Console.WriteLine($"Current changes will be lost. confirm yes/no");
            if (Console.ReadLine() == "no")
            {
                Save();
            }
        }
    }
    //has test
    public void DisplayJournal()
    {
        foreach(Entry entryElement in _entries)
        {
            Console.WriteLine(entryElement._date);
            for (int i = 0; i < entryElement._entryContents.Count(); i++)
            {
                List<string> elementList = entryElement._entryContents;
                elementList[i] = entryElement._entryContents[i];
                if (elementList[i].EndsWith('&'))
                {
                    elementList[i] = elementList[i][..^1];
                    //element = element.Substring(0, element.length - 1);
                    
                }
                    Console.WriteLine(elementList[i]);
            }
        }
    }
    //called in EditEntry()
    //has test
    public void ChooseEntry1()
    {
        int fileCount = Directory.EnumerateFiles(_folder, _fileName+"*").Count();
        //debugging
        if (fileCount != _entries.Count)
        {
            Console.WriteLine($"ERROR: fileCount is {fileCount} but _entries.Count is {_entries.Count}");
        }
        Console.WriteLine($"there are {fileCount} entries in your journal:");
        
        int entryCount = 1;
        foreach (Entry entryElement in _entries)
        {
            Console.WriteLine($"\tEntry {entryCount}: {entryElement._date}");
            entryCount++;
        }
        ChooseEntry2();
    }
    //has test
    public void ChooseEntry2()
    {
        int entryCount = _entries.Count();
        int entrySelection;
        Console.WriteLine("Which entry do you want to edit? (choose a number from the entries above)");
        string response = Console.ReadLine();
        if (int.TryParse(response, out entrySelection) && entrySelection >= 1 && entrySelection <= entryCount)
        {
            _currentEntry = _entries[entrySelection-1];
            _currentEntry._fileNum = int.Parse(response)-1;
            _currentEntry._filePath = $"{_folder}{_fileName}{_currentEntry._fileNum}{_fileType}";
        }
        else
        {
            Console.WriteLine("Do you want to edit an existing entry? yes/no");
            response = Console.ReadLine();
            if (response == "yes")
            {
                ChooseEntry2();
            }
            //else nothing
        }
    }
    //has test
    public void SaveCurrentEntry()
    {
        //int count = 0;
        // do
        // {
        //     filePath = Path.Combine(_folder, $"{fileName}{count}{extension}");
        //     count++;
        // }
        // while (File.Exists(fileName));
        // using (StreamWriter output = new StreamWriter(fileName))
        // {
        //     foreach (Entry entryElement in _entries)
        //     {
        //         output.WriteLine(entryElement._date);

        //         foreach (string element in entryElement._entryContents)
        //         {
        //             output.WriteLine(element);
        //         }
        //     }
        // }

        // Console.WriteLine($"Journal saved to: {fileName}");
        int newest = _entries.Count - 1;
        Console.WriteLine($"var newest is: {newest}");
        _currentEntry._filePath = $"{_folder}{_fileName}{_currentEntry._fileNum}{_fileType}";
        //TO DO save a separate variable for the count num (of whiech file) instead of full filepath, and compare that here instead of using date. Might have to split this into 2 functions. 
        // if (_entries[newest]._date == DateTime.Today.ToString("MM/dd/yyyy"))
        // {
        //         //if (Path.Exists($"{_folder}{_fileName}{count}{_extension}"))//currentEntry._filePath
        //     //setting the path it will save as to the correct iteration of journal
        //     _currentEntry._filePath = $"{_folder}{_fileName}{newest}{_fileType}";
        //     //just printing what these things are
        //     Console.WriteLine($"Current _folder is: {_folder}");
        //     Console.WriteLine($"Current fileName is: {_fileName}");
        //     Console.WriteLine($"Current file count is: {newest + 1}");
        //     Console.WriteLine($"So current filePath is: {_currentEntry._filePath}");
        // }
        // else
        // {
        //     _currentEntry._filePath = $"{_folder}{_fileName}{newest+1}{_fileType}";
        //     //just printing what these things are
        //     Console.WriteLine($"Current _folder is: {_folder}");
        //     Console.WriteLine($"Current fileName is: {_fileName}");
        //     Console.WriteLine($"Current file count is: {newest + 2}");
        //     Console.WriteLine($"So current filePath is: {_currentEntry._filePath}");
        // }
        Console.WriteLine($"this is supposed to be the filepath: {_currentEntry._filePath}");
        _currentEntry.SaveEntry();

        //to do: ask or warn about overwrites if file already exists
        //double check that adding to an entry is adding at end of list containing original entry contents
        
        //int count = 0;
        // while (true)
        // {
        //     if (Path.Exists($"{_folder}{_fileName}{count}{_extension}"))//currentEntry._filePath
        //     {
        //         count++;
        //     }
        //     else
        //     {
        //         //setting the path it will save as to the correct iteration of journal
        //         _currentEntry._filePath = $"{_folder}{_fileName}{count}{_extension}";
        //         //just printing what these things are
        //         Console.WriteLine($"Current _folder is: {_folder}");
        //         Console.WriteLine($"Current fileName is: {_fileName}");
        //         Console.WriteLine($"Current file count is: {count}");
        //         Console.WriteLine($"So current filePath is: {_currentEntry._filePath}");

        //         break;
        //     }
        //
        // Console.WriteLine($"this is supposed to be the filepath: {_currentEntry._filePath}");
        // _currentEntry.SaveEntry();

        // using (StreamWriter output = new StreamWriter(filePath))
        // {  
        //     // foreach (Entry entryElement in _entries)
        //     // {
        //     output.WriteLine(entryElement._date);
        //     foreach (string element in entryElement._entryContents)
        //     {
        //         output.WriteLine(element);
        //     }
        //     // }
        // }
    }
}