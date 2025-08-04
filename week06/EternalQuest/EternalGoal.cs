public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Great work! You earned {Points} points!");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[∞] {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{ShortName},{Description},{Points}";
    }
}
