using System;

class Program
{
<<<<<<< HEAD
    // #######################################
    // #### Creative Additions ###############
    // #######################################
    // I added music that plays during the activities. (if it doesnt work, might have to add 'dotnet add package System.Windows.Extensions')

    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
        Menu();
    }
    static public void Menu()
    {
        Activity _activity;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("\t1. Start Breathing Activity");
            Console.WriteLine("\t2. Start Reflecting Activity");
            Console.WriteLine("\t3. Start Listening Activity");
            Console.WriteLine("\t4. Listen to relaxing music");
            Console.WriteLine("\t5. Quit");
            Console.WriteLine("Select choice from menu");

            int activity = Input2Int();
            if (activity == 1)
            {
                _activity = new BreathingActivity();
            }
            else if (activity == 2)
            {
                _activity = new ReflectingActivity();
            }
            else if (activity == 3)
            {
                _activity = new ListeningActivity();
            }
            else if (activity == 4)
            {
                _activity = new MusicActivity();
            }
            else if (activity == 5)
            {
                Console.WriteLine("Thanks for participating!");
                return;
            }
            Console.Clear();
        }
    }

    static public int Input2Int()
    {
        int number;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
=======
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
>>>>>>> origin/main
    }
}