using System;
class Program
{
    static void Main(string[] args)
    
    {
        // Example scripture
        var reference = new Reference("John", "3:16");
        string scriptureText = "For God so loved the world that he gave his one and only Son, " +
                               "that whoever believes in him shall not perish but have eternal life.";
        var scripture = new Scripture(reference, scriptureText);

        // Show creativity: load multiple scriptures from a list
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", "3:5-6"), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Psalm", "23:1"), "The Lord is my shepherd, I lack nothing."),
            
        };

        var rnd = new Random();
        // Select a random scripture
        var currentScripture = scriptures[rnd.Next(scriptures.Count)];

        // Display the full scripture
        Console.Clear();
        currentScripture.Display();

        while (true)
        {
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            if (currentScripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            // Hide a few words (e.g., 2)
            currentScripture.HideWords(2);

            Console.Clear();
            currentScripture.Display();

            if (currentScripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are now hidden.");
                break;
            }
        }
    }
}