public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, penaltyPoints * -1) // Store penalty as a negative number
    {
        // Points are stored as a negative value for subtraction
    }

    // Polymorphism: Override RecordEvent
    public override int RecordEvent()
    {
        // Returns the negative point value (a penalty)
        return Points; 
    }

    // Polymorphism: Override GetStringRepresentation
    public override string GetStringRepresentation()
    {
        // Negative goals are never 'complete'
        return $"[ ] {GetDetailsString()} (Penalty: {Points} points)";
    }

    // Polymorphism: Override GetSaveString
    public override string GetSaveString()
    {
        // Stored points will be the negative value
        return $"NegativeGoal|{ShortName}|{Description}|{Points}";
    }
}