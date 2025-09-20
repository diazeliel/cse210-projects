using System;
public class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> Words;

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    // Displays the scripture with hidden words
    public void Display()
    {
        Console.WriteLine(Reference.ToString());
        Console.WriteLine(string.Join(" ", Words));
    }

    // Hides a number of random words (e.g., 2)
    public void HideWords(int count)
    {
        var rnd = new Random();

        for (int i = 0; i < count; i++)
        {
            // Select a random index
            int index = rnd.Next(Words.Count);
            // Hide the word if it's not already hidden
            if (!Words[index].IsHidden)
            {
                Words[index].Hide();
            }
        }
    }

    // Checks if all words are hidden
    public bool IsCompletelyHidden()
    {
        return Words.All(w => w.IsHidden);
    }
}
