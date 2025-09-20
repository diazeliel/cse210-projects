using System;
using System.Collections.Generic;
using System.Linq;

// Represents the reference of a scripture, e.g., "John 3:16" or "Proverbs 3:5-6"
public class Reference
{
    public string Book { get; private set; }
    public string Chapter { get; private set; }
    public string Verses { get; private set; }

    // Constructor for single verse
    public Reference(string book, string chapterVerse)
    {
        Book = book;
        var parts = chapterVerse.Split(':');
        if (parts.Length == 2)
        {
            Chapter = parts[0];
            Verses = parts[1];
        }
    }

    // Constructor for verse range
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        Book = book;
        Chapter = chapter;
        Verses = $"{startVerse}-{endVerse}";
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{Verses}";
    }
}