public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Polymorphism: Override RecordEvent
    public override int RecordEvent()
    {
        // Always returns points as it's never 'complete'
        return Points;
    }

    // Polymorphism: Override GetStringRepresentation
    public override string GetStringRepresentation()
    {
        // Eternal goals are never complete, so they always show [ ]
        return $"[ ] {GetDetailsString()}";
    }

    // Polymorphism: Override GetSaveString
    public override string GetSaveString()
    {
        return $"EternalGoal|{ShortName}|{Description}|{Points}";
    }
}