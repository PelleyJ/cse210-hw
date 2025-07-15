using System;

class Program
{
    static void Main(string[] args)
    {
        // Create reference and scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        // Loop until user types "quit" or all words are hidden
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            Console.Write("> ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                break;
            }

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are now hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            // Hide 2–3 more words each time
            scripture.HideRandomWords(3);
        }
    }
}
