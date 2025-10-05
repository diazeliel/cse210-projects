using System;
using System.Runtime.CompilerServices;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        // Simple validation to ensure a number is entered
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number of seconds: ");
            input = Console.ReadLine();
        }
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5); // Pause and show a spinner for 5 seconds
    }

    // Common ending message logic
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3); // Pause for a few seconds
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(5); // Final pause
    }

    // Animation Method: Spinner (to meet design requirement)
    protected void ShowSpinner(int seconds)
    {
        // Define the spinner characters
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            // Write the spinner character
            Console.Write(spinner[i]);
            // Pause for a short time (e.g., 250 milliseconds)
            Thread.Sleep(250);
            // Overwrite the previous character: moves left, writes space, moves left again
            Console.Write("\b \b");

            // Cycle to the next spinner character
            i = (i + 1) % spinner.Length;
        }
    }

    // Animation Method: Countdown (to meet design requirement)
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            // Write the current number, padding with spaces to ensure overwrite is clean
            string countdownText = i.ToString().PadLeft(2);
            Console.Write(countdownText);
            Thread.Sleep(1000); // Pause for 1 second
            
            // Move back and clear the characters just written
            for (int j = 0; j < countdownText.Length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }

    // The Run method is the core activity logic, which will be overridden
    public virtual void Run()
    {
        // This base method will be empty, allowing derived classes to provide implementation.
    }
}