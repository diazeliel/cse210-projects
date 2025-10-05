using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";
       
        do
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Select a choise from the menu:");

            choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    System.Threading.Thread.Sleep(2000);
                    continue; // Skip to the next iteration of the loop
            }

            // If an activity was selected, run it.
            if (activity != null)
            {
                activity.Run();
            }

        } while (choice != "4");
    }
}