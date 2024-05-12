using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!\n");
        
        Console.WriteLine("-------------------------------------- The Scripture Memorizer -----------------------------------");
        Console.WriteLine("                     Welcome to the Scripture Memorizer. Let's start memorizing!!                        \n");

        // Instanciating the reference class.
        // Because I'm using the instance of the reference class to get the values instead of a setter method,
        // I need to pass sort of a dummy parameters, and then give it new set of values to the parameters from the user.
        // I did it this way to avoid errors in my program.
        DisplayReference theReference = new(book:"", chap:0, vrs_s:0); 
        
        Console.Write("Enter the Scripture in the format - (Book, Chapter, Verse(s) separated by ',') : ");
        string[] listRef = Console.ReadLine().Split(",");
        
        // The if block statements are to count if the reference entered is a single verse or range of verses.
        // after I have split the user reference into list.
        if (listRef.Count() == 4)
        {
            // re-assigning the elements in the list to the reference class by it positional argument(parameters).
            theReference = new DisplayReference(book:listRef[0], chap:int.Parse(listRef[1]), vrs_s:int.Parse(listRef[2]), vrs_e:int.Parse(listRef[3]));
        }
        if (listRef.Count() == 3)
        {
            theReference = new DisplayReference(book:listRef[0], chap:int.Parse(listRef[1]), vrs_s:int.Parse(listRef[2]));
        }
         // Getting the verse or text from the user using the reference setter method.
        // But this setter method doesn't have a parameter to it. Instead it makes use of the readline.
        Console.WriteLine("Enter the scripture verse:\n ");
        theReference.SetVerse();
        // Console.WriteLine(theReference.GetFormattedReference());
        // Console.WriteLine(theReference.GetTheVerse());
        Scripture scripture = new(theReference);
        
        string isQuit = "";
        while (isQuit != "quit")
        {
            if(scripture.IsAllWordHidden())
            {
                break;
            }

            scripture.HideWord(5);
            Console.Clear();
            scripture.DisplayText();

            Console.Write("Press Enter to continue and 'QUIT' to stop the program: ");
            isQuit = Console.ReadLine().ToLower();
        }
        
        
            
    }
}