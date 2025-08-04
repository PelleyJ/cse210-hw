// Enhancement: This program includes 3 goal types with polymorphism and saving/loading features.
// Exceeds requirements by using encapsulation properly, clean file structure, and flexible goal creation.
// Optionally: add level-up system, badges, or timestamps in future.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
