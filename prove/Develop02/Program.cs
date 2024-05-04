using System;

partial class Program 
{
    static void Main(string[] args)
    {
        DateTime currentDateTime = DateTime.Now;
        
        Console.WriteLine("---------------------------- Welcome to Easy Journal-------------------------------");
        Console.WriteLine("         What can I do for you today(select the option by it number)                             ");
        Console.WriteLine("");
        //Initiating the Journal object
        Journal journal = new();
        // Initiating the Display object
        Display display = new();

        
        int theResponse;

        do
        {
            display.ShowMenu();
            theResponse = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (theResponse == 1)
            {
                Console.Write("What is the name of the Journal: ");
                string entryName = Console.ReadLine();
                Console.WriteLine("");
                
                // Console.WriteLine();
                journal._fileName = entryName;
                journal._date = currentDateTime.ToLongDateString();
                journal.Entry(fileN: journal.fileAccessName(journal._fileName), prompt: display.GetPrompt());
            }
        
            else if (theResponse == 2)
            {
                journal.Continue(prompt: display.GetPrompt());
            }

            else if (theResponse == 3)
            {
                display.LoadJournal();
            }

            else if (theResponse == 4)
            {
                display.FileDelete();
            }
        } while (theResponse != 5);
        
    }
}