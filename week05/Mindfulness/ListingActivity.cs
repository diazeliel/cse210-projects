using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Exceed Requirement: Keep track of used items
    private List<string> _unusedPrompts;
    private int _count; // To track the number of items listed

    // Constructor
    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
        _count = 0;
        // Initialize the unused prompts list
        _unusedPrompts = new List<string>(_prompts);
    }

    // Override the base Run method
    public override void Run()
    {
        DisplayStartingMessage();
        
        // Select a random starting prompt
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        PerformListing();

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        // If all prompts have been used, reset the unused list
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts.AddRange(_prompts);
        }

        Random random = new Random();
        int index = random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index); // Remove the prompt so it's not immediately repeated
        return prompt;
    }
    
    // Core listing logic
    private void PerformListing()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _count = 0;

        Console.WriteLine("Start listing items now (press Enter after each item):");
        
        // Loop while the current time is less than the end time
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            // Use ReadLine to get input without blocking for the whole duration
            // This is a simplification; in a real app, reading input while checking time is complex.
            // Here, we check time before and after the read operation.
            string input = Console.ReadLine(); 
            
            // Check again immediately after reading input to prevent overrunning the timer significantly
            if (DateTime.Now < endTime && !string.IsNullOrWhiteSpace(input))
            {
                _count++;
            }
        }
        
        Console.WriteLine();
        Console.WriteLine("Time's up!");
    }
}