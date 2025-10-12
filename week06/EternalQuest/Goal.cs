using System;
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Public properties for read access to points and description
    public int Points => _points;
    public string ShortName => _shortName;
    public string Description => _description;

    // Abstract method to be overridden by derived classes (Polymorphism)
    public abstract int RecordEvent();

    // Virtual method for displaying goal details (Polymorphism)
    public virtual string GetDetailsString()
    {
        // Default implementation for the base class
        return $"{_shortName} ({_description})";
    }

    // Abstract method to show completion status for the list
    public abstract string GetStringRepresentation();
    
    // Abstract method for saving and loading (Serialization)
    public abstract string GetSaveString();
}