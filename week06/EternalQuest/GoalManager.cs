// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private const int PointsPerLevel = 1000; // Gamification: Leveling

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    // Public properties for access
    public int Score => _score;
    public int Level => _level;

    // --- Gamification: Leveling System ---
    private void UpdateLevel()
    {
        int newLevel = (_score / PointsPerLevel) + 1;
        if (newLevel > _level)
        {
            Console.WriteLine($"\n*** Congratulations! You've reached Level {newLevel}! ***");
            _level = newLevel;
        }
    }

    // --- Goal Creation ---
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (Exceeding Requirement)");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal (or penalty)? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            case "4":
                newGoal = new NegativeGoal(name, description, points);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"Goal '{name}' created successfully.");
        }
    }

    // --- Display Methods ---
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour current score is: {_score} points.");
        Console.WriteLine($"Your current Level is: {_level} (Next level at {(_level * PointsPerLevel)} points).");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            // Goal objects are called directly to show names/descriptions
            Console.WriteLine($"  {i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            // Polymorphism: Calling GetStringRepresentation on each object
            Console.WriteLine($"  {i + 1}. {_goals[i].GetStringRepresentation()}");
        }
    }

    // --- Event Recording ---
    public void RecordEvent()
    {
        ListGoalNames();
        if (_goals.Count == 0) return;

        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            int earnedPoints = goal.RecordEvent();

            if (earnedPoints != 0)
            {
                _score += earnedPoints;
                Console.WriteLine($"Congratulations! You have recorded the event: '{goal.ShortName}'.");
                Console.WriteLine($"You earned {Math.Abs(earnedPoints)} points!");

                // Check for bonus points (ChecklistGoal completion)
                if (goal is ChecklistGoal checklistGoal)
                {
                    // Using GetStringRepresentation to check for '[X]' (completed state) is another option,
                    // but checking the points directly is more explicit here.
                    int target = int.Parse(goal.GetSaveString().Split('|')[4]); 
                    int bonus = int.Parse(goal.GetSaveString().Split('|')[5]);
                    int completed = int.Parse(goal.GetSaveString().Split('|')[6]);
                    
                    if (completed == target && earnedPoints > goal.Points)
                    {
                        Console.WriteLine($"You also received a bonus of {bonus} points!");
                    }
                }
                
                // Check for negative goals
                if (goal is NegativeGoal)
                {
                    Console.WriteLine($"Your score has been reduced by {Math.Abs(earnedPoints)} points.");
                }

                DisplayPlayerInfo();
                UpdateLevel();
            }
            else
            {
                Console.WriteLine($"Goal '{goal.ShortName}' is already complete.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // --- File Handling (Save/Load) ---

    public void SaveGoals(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // Line 1: Score and Level
                outputFile.WriteLine($"{_score},{_level}");

                // Remaining lines: Goal data
                foreach (Goal goal in _goals)
                {
                    // Polymorphism: Calling GetSaveString() on each goal
                    outputFile.WriteLine(goal.GetSaveString());
                }
            }
            Console.WriteLine($"\nGoals and score saved to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving: {ex.Message}");
        }
    }

    public void LoadGoals(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"\nFile '{filename}' not found. Starting with a fresh slate.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();

            // Line 1: Load Score and Level
            if (lines.Length > 0)
            {
                string[] playerInfo = lines[0].Split(',');
                _score = int.Parse(playerInfo[0]);
                _level = int.Parse(playerInfo[1]);
            }

            // Remaining lines: Load Goals (Factory Pattern concept)
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal loadedGoal = null;

                switch (type)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(parts[4]);
                        loadedGoal = new SimpleGoal(name, description, points, isComplete);
                        break;
                    case "EternalGoal":
                        loadedGoal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int target = int.Parse(parts[4]);
                        int bonus = int.Parse(parts[5]);
                        int amountCompleted = int.Parse(parts[6]);
                        loadedGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                        break;
                    case "NegativeGoal":
                        loadedGoal = new NegativeGoal(name, description, Math.Abs(points)); // Pass absolute value, NegativeGoal handles the sign
                        break;
                }

                if (loadedGoal != null)
                {
                    _goals.Add(loadedGoal);
                }
            }
            Console.WriteLine($"\nGoals and score loaded from '{filename}'.");
            DisplayPlayerInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading: {ex.Message}. Starting with an empty list.");
            _goals.Clear();
            _score = 0;
            _level = 1;
        }
    }
}