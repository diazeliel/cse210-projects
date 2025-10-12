public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor for loading from file
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Polymorphism: Override RecordEvent
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0; // Already complete
    }

    // Polymorphism: Override GetStringRepresentation
    public override string GetStringRepresentation()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {GetDetailsString()}";
    }

    // Polymorphism: Override GetSaveString
    public override string GetSaveString()
    {
        return $"SimpleGoal|{ShortName}|{Description}|{Points}|{_isComplete}";
    }
}