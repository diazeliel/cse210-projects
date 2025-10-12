using System;
using System.IO; 

class Program
{
    // Description of exceeding requirements:
    /*
    Exceeding Requirements:
    1. Leveling System: I have implemented a gamification component where the user
       earns a new "Level" for every 1000 points they achieve. The current level is
       displayed along with the score. This is managed in the GoalManager class.
    2. Negative Goal: A new goal type, `NegativeGoal`, was created to track bad
       habits. Recording this goal subtracts the penalty points from the user's total score.
       This goal type is fully integrated with the save/load functionality and the goal creation menu.
    */

    static void Main(string[] args)
    {
        // Name of the file for saving and loading data
        string filename = "goals.txt";
        GoalManager manager = new GoalManager();

        // Automatically load data when the program starts
        manager.LoadGoals(filename);

        string choice = "";

        do
        {
            Console.WriteLine("\n==============================");
            manager.DisplayPlayerInfo();
            Console.WriteLine("==============================");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoalDetails();
                    break;
                case "3":
                    manager.SaveGoals(filename);
                    break;
                case "4":
                    manager.LoadGoals(filename);
                    break;
                case "5":
                    manager.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Thank you for using the Eternal Quest program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a number from the menu.");
                    break;
            }

        } while (choice != "6");
    }
}