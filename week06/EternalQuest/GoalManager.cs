using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nTypes of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Enter target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoalNames();
        Console.Write("Enter the goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();

            if (goal is ChecklistGoal checklistGoal)
            {
                _score += checklistGoal.IsComplete()
                    ? checklistGoal.Points + checklistGoal.Bonus
                    : checklistGoal.Points;
            }
            else if (goal is SimpleGoal simpleGoal)
            {
                if (!simpleGoal.IsComplete())
                    _score += simpleGoal.Points;
            }
            else if (goal is EternalGoal eternalGoal)
            {
                _score += eternalGoal.Points;
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] data = parts[1].Split(",");

                if (type == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                }
                else if (type == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[3])));
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
