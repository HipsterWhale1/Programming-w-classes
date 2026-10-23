using System;

class Program
{
    static void Main(string[] args)
    {
        int percentage;
        string letter = "letter was not assigned";
        string modifier = "modifier was not assigned";
        bool passed = false;

        //get user input
        Console.Write("Hello user! Whats your grade percentage right now? ");
        percentage = int.Parse(Console.ReadLine());
        
        //determine letter grade
        if (percentage % 10 >= 7)
        {
            modifier = "+" ;
        }
        else if (percentage % 10 <= 3)
        {
            modifier = "-";
        }
        else
        {
            modifier = "";
        }

        //determine modifier (+ or -)
        if (percentage >= 90)
        {
            letter = "A";
            passed = true;
            if (percentage > 93)
            {
                modifier = "";
            }
        }
        else if (percentage >= 80)
        {
            letter = "B";
            passed = true;
        }
        else if (percentage >= 70)
        {
            letter = "C";
            passed = true;
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
            modifier = "";
        }

        // print grade
        Console.WriteLine($"Your grade is {letter}{modifier}");

        // print pass/fail
        if (passed == true)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("You put in great effort, but you did not pass the class. With help, we believe you can!");
        }
    }
}