using System;

class Testing
{
    public Entry _testEntry = new Entry();
    public Journal _testJournal = new Journal();
    public int count = -1;
    public TextReader _originalInput = Console.In;
    //main
    public void TestFunction()
    {
        Console.WriteLine("=> TestFunction():");
        
        TestEntryContents();
        TestGetRandomPrompt();
        TestDisplayPrompt();
        TestContinueEntry();
        TestGetTodaysDate();
        TestDisplayEntry();
        TestPrintEntryContents();
        TestSaveEntry();

        TestAddEntry();
        TestLoadEntries();
        TestEditEntry();
        TestDisplayJournal();
        TestChooseEntry1();
        TestChooseEntry2();
        TestSaveCurrentEntry();
        Console.WriteLine("End of TestFunction()!!!");
    }
    //#########TESTING ENTRY######
    //resetting class to default every time, so previous tests dont influence it
    public void ResetTestEntry()
    {
        _testEntry = new Entry();
        Console.SetIn(_originalInput);
    }
    //originally testing a function, now j testing the list
    public void TestEntryContents()
    {
        Console.WriteLine("=> TestEntryContents():");
        ResetTestEntry();
        
        count = Entry._prompts.Count();
        Console.WriteLine($"Size of entry.prompts is {count}");
    }
    public void TestGetRandomPrompt()
    {
        Console.WriteLine("=> TestGetRandomPrompt():");
        ResetTestEntry();

        TestGetRandomPrompt2();
        TestGetRandomPrompt2();
        TestGetRandomPrompt2();
    }
    public void TestGetRandomPrompt2()
    {
        //no print statement of funtion, since its part of TestGetRandomPrompt()
        Console.WriteLine($"_prompt before GetRandomPrompt(): {_testEntry._prompt}");
        _testEntry.GetRandomPrompt();
        Console.WriteLine($"_prompt after GetRandomPrompt(): {_testEntry._prompt}");
    }
    public void TestDisplayPrompt()
    {
        Console.WriteLine("=> TestDisplayPrompt():");
        ResetTestEntry();

        Console.SetIn(new StringReader("yes"));
        _testEntry.DisplayPrompt();
        Console.SetIn(new StringReader("no"));
        _testEntry.DisplayPrompt();
        Console.SetIn(new StringReader("srdtyhetryjh"));
        _testEntry.DisplayPrompt();
        Console.WriteLine($"_entryContents contains another prompt: ");
        _testEntry.PrintEntryContents();
    }
    public void TestContinueEntry()
    {
        Console.WriteLine("=> TestContinueEntry():");
        ResetTestEntry();

        //input to continue journaling
        //Console.SetIn(new StringReader("yes"));
        //loops 4 times, ends on the 4th
        Console.SetIn(new StringReader("yes\nyes\nyes\nno\nyes"));
        while (_testEntry._continueJournaling == true)
        {
            _testEntry.ContinueEntry();
        }
    }
    public void TestGetTodaysDate()
    {
        Console.WriteLine("=> TestGetTodaysDate():");
        ResetTestEntry();

        _testEntry.GetTodaysDate();
        Console.WriteLine(_testEntry._date);
    }
    public void TestDisplayEntry()
    {
        Console.WriteLine("=> TestDisplayEntry():");
        ResetTestEntry();

        //resetting _entryContents to what it would be (after modifying it in tests above)
        _testEntry._entryContents.Clear();
        _testEntry._continueJournaling = true;
        Console.SetIn(_originalInput);
        //yes to prompt, journal entry content, no to continue, yes to confirm
        Console.SetIn(new StringReader("yes\nToday was really great! We had a great time lorem ipsum\nno\nyes"));
        Console.WriteLine("DisplayEntry():");
        _testEntry.WriteEntry();
    }
    public void TestPrintEntryContents()
    {
        Console.WriteLine("=> TestPrintEntryContents():");
        ResetTestEntry();

        _testEntry._entryContents.Clear();
        _testEntry._continueJournaling = true;
        _testEntry._entryContents.Add("this is element 1");
        _testEntry._entryContents.Add("this is element 2");
        _testEntry._entryContents.Add("this is element 3");
        _testEntry._entryContents.Add("this is element 4");
        _testEntry.PrintEntryContents();
        Console.WriteLine("end of TestPrintEntryContents()");
    }
    public void TestSaveEntry()
    {
        Console.WriteLine("=> TestSaveEntry():");
        ResetTestEntry();
        
        _testEntry._filePath = $"{AppContext.BaseDirectory}test_save_entry_.txt";
        Console.WriteLine($"Current filePath in TestSaveEntry is: {_testEntry._filePath}");
        //populating necessary values
        _testEntry.GetTodaysDate();
        _testEntry._entryContents.Add("this is element 1 lorem ipsum");
        _testEntry.SaveEntry();
    }
    //#########END TESTING ENTRY######

    //#########TESTING JOURNAL######
    public void ResetTestJournal()
    {
        _testJournal = new Journal();
        Console.SetIn(_originalInput);
    }
    public void PopulateTestJournal()
    {
        int i = 0;
        while (i < 5)
        {    
            _testJournal._entries.Add(new Entry());
            int x = 0;
            while (x < 5)
            {
                _testJournal._entries[i]._entryContents.Add($"This is entry {i} and element {x}, either a prompt or a response.\nnewline, just testing special symbol. &");
                //do i need to set _currentEntry?
                x++;
            }
            i++;
        }
    }
    public void TestLoadEntries()
    {
        Console.WriteLine("=> TestLoadEntries():");
        Console.WriteLine("=> j testing");
        ResetTestJournal();
        
        _testJournal.LoadEntries();
        //first file first element
        Console.WriteLine($"{_testJournal._entries[0]._entryContents[0]}");
    }
    public void TestAddEntry()
    {
        Console.WriteLine("=> TestAddEntry():");
        ResetTestJournal();
        //PopulateTestJournal();

        int sizeBefore;
        int sizeAfter;
        
        
        _testJournal.LoadEntries();
        sizeBefore = _testJournal._entries.Count();
        _testJournal.TodaysEntry();
        sizeAfter = _testJournal._entries.Count();
        Console.WriteLine($"Num of entries before: {sizeBefore}. Size of entries after: {sizeAfter}");
    }
    public void TestEditEntry()
    {
        Console.WriteLine("=> TestEditEntry():");
        ResetTestJournal();
        PopulateTestJournal();

        _testJournal.TodaysEntry();

        int counter = 1;

        Console.WriteLine($"EditEntry {counter++}");
        Console.SetIn(new StringReader("yes\nToday I spent time learning how to improve my C# program. I made progress understanding lists, file handling, and user input.\nyes\nno\niughdsfg iuhdfagf iudfg\nno\nyes\nyesa\nyes"));
        _testJournal.EditEntry();

        Console.WriteLine($"EditEntry {counter++}");
        Console.SetIn(new StringReader("yes\nToday I took a walk and enjoyed the cool evening air. I returned home feeling relaxed and ready to finish my work.\nno\nyes\nno\nyes"));
        _testJournal.EditEntry();

        Console.WriteLine($"EditEntry {counter++}");
        Console.SetIn(_originalInput);
        Console.SetIn(new StringReader("no\nI tried a new recipe today and was surprised by how well it turned out. It reminded me that experimenting can lead to something great.\nno\nyes\n\nyes\nno\nyes"));
        _testJournal.EditEntry();
    }
    public void TestDisplayJournal()
    {
        Console.WriteLine("=> TestDisplayJournal():");
        ResetTestJournal();
        PopulateTestJournal();

        
        Console.WriteLine($"DEBUG: entry 4 element 2 should have an '&' at the end of it; {_testJournal._entries[3]._entryContents[1]}");
        _testJournal.DisplayJournal();
    }
    public void TestChooseEntry1()
    {
        Console.WriteLine("=> TestChooseEntry1():");
        ResetTestJournal();
        //PopulateTestJournal();

        int fileCount = Directory.EnumerateFiles(_testJournal._folder, _testJournal._fileName+"*").Count();
        string fileChoice = Random.Shared.Next(0, fileCount).ToString();
        _testJournal.LoadEntries();
        //Console.SetIn(_originalInput);
        Console.SetIn(new StringReader($"{fileChoice}\n"));
        _testJournal.ChooseEntry1();
    }
    public void TestChooseEntry2()
    {
        Console.WriteLine("=> TestChooseEntry2():");
        ResetTestJournal();
        ///PopulateTestJournal();

        _testJournal.LoadEntries();
        //Console.WriteLine($"DEBUG total entries is: {_testJournal._entries.Count()}, and we chose '3'");
        //Console.SetIn(_originalInput);
        Console.SetIn(new StringReader("3"));
        _testJournal.ChooseEntry2();
        //Console.SetIn(_originalInput);
        Console.SetIn(new StringReader("7654\nyes\nsrth\nno"));
        _testJournal.ChooseEntry2();

    }
    public void TestSaveCurrentEntry()
    {
        Console.WriteLine("=> TestSaveCurrentEntry():");
        ResetTestJournal();
        PopulateTestJournal();

        _testJournal.TodaysEntry();
        
        //Console.WriteLine("=> TestSaveCurrentEntry():");
        //yes to prompt, journal entry content, no to continue, yes to confirm
        Console.SetIn(new StringReader("yes\nToday was really great! We had a great time lorem ipsum (save to file)\nno\nyes"));
        _testJournal._entries[0].GetTodaysDate();
        _testJournal._entries[0].WriteEntry();
        //Console.WriteLine("DEBUG Start of actual SaveJournal() call");
        //this will throw off counting in 
        _testJournal._fileName = "test_save_current_entry_";
        _testJournal.SaveCurrentEntry();
        //Console.WriteLine("DEBUG Reached end of TestSaveCurrentEntry()");  
    }
}