public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public int Bonus => _bonus;
    public int AmountCompleted => _amountCompleted;
    public int Target => _target;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"Good job! You earned {Points} points!");

        if (IsComplete())
        {
            Console.WriteLine($"Bonus! You completed the goal and earned {Bonus} extra points!");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {ShortName} ({Description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName},{Description},{Points},{_amountCompleted},{_target},{_bonus}";
    }
}
