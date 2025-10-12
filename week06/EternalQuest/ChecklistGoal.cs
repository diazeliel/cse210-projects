public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Constructor for loading from file
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    // Polymorphism: Override RecordEvent
    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            if (_amountCompleted == _target)
            {
                // Goal completed! Return base points + bonus
                return Points + _bonus;
            }
            else
            {
                // Not yet complete, return base points
                return Points;
            }
        }
        return 0; // Already complete
    }

    // Polymorphism: Override GetDetailsString to include progress
    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Polymorphism: Override GetStringRepresentation
    public override string GetStringRepresentation()
    {
        string status = (_amountCompleted == _target) ? "[X]" : "[ ]";
        return $"{status} {ShortName} ({Description}) -- Completed {_amountCompleted}/{_target}";
    }

    // Polymorphism: Override GetSaveString
    public override string GetSaveString()
    {
        return $"ChecklistGoal|{ShortName}|{Description}|{Points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}