using System;
using System.Threading;

public class BreathingActivity : Activity
{
    // Constructor calls the base class constructor
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        ) { }

    // Override the base Run method
    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            // Breathe In
            Console.Write("Breathe in...");
            ShowBreathingAnimation(4); // 4 seconds in
            Console.WriteLine();

            // Check if duration is met before breathing out
            if (DateTime.Now >= endTime) break;

            // Breathe Out
            Console.Write("Breathe out...");
            ShowBreathingAnimation(6); // 6 seconds out
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    // Exceed Requirement: More meaningful animation for breathing
    private void ShowBreathingAnimation(int seconds)
    {
        // Calculate the pause time per step for a smoother animation
        int steps = 10;
        int stepDurationMs = (seconds * 1000) / steps;
        
        // Use a simple text-based "growth" to simulate the breath
        for (int i = 0; i <= steps; i++)
        {
            // Calculate number of characters to display (e.g., 0 to 10 periods)
            string dots = new string('.', i);
            Console.Write(dots);
            Thread.Sleep(stepDurationMs);

            // Move back and clear the dots for the next step
            for (int j = 0; j < dots.Length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}