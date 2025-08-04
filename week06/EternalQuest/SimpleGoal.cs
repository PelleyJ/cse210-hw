public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You earned {Points} points!");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName},{Description},{Points},{_isComplete}";
    }
}
