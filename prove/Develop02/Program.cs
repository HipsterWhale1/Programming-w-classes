using System;

class Program
{
    public List<Journal> _journals = new List<Journal>();
    public Journal _firstJournal = new Journal();
    //apparently better than just .\ 

    public static void Main()
    {
        //Console.WriteLine("Program main:");
        // Testing test = new Testing();
        // test.TestFunction();
        Program program = new Program();
        program.DisplayMenu();
    }
    public void DisplayMenu()
    {
        string input;
        _firstJournal.LoadEntries();
        Console.Write($"Hello! Welcome to your personal Journal! ");
        while (true)
        {
            Console.WriteLine($"You may:");
            Console.WriteLine($"\tRead your Journal (press \"1\")");
            Console.WriteLine($"\tContinue an old entry (press \"2\")");
            Console.WriteLine($"\tWrite in today's entry (press \"3\")");
            Console.WriteLine($"\tExit program (press \"e\")");
            input = Console.ReadLine();
            if (input == "1")
            {
                _firstJournal.DisplayJournal();
            }
            else if (input == "2")
            {
                _firstJournal.ChooseEntry1();
                _firstJournal._currentEntry.PrintEntryContents();
                Console.Write($"You may continue this entry.");
                _firstJournal.EditEntry();
            }
            else if (input == "3")
            {
                _firstJournal.TodaysEntry();
                _firstJournal.EditEntry();
            }
            else if (input == "q")
            {
                QuitProgram();
            }
        }
        //Lets Journal! Press any key to continue. You may also edit an old entry, or view the entire journal.
        // AddEntry(); EditEntry(); DisplayJournal(); 
        //save entry?
        //saveCurrentEntry (actually, take a look at this, do i need all this? thats a lot of writing files that have no changes
        //also if i want to, add function to edit the prompts
    }
    // public void LoadJournal()
    // {
    //     Console.WriteLine("Which journal do you want to load? (number value)");
    //     //put number in file path
    //     //if file doesnt exist, apologize. maybe list files that do exist
    // }
    public void QuitProgram()
    {
        Console.WriteLine($"Thank you! Have a good day.");
        Environment.Exit(0);
    }
}