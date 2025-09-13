using System;
using System.Security.Cryptography.X509Certificates;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string date, string prompText, string entryText)
    {
        _date = date;
        _promptText = prompText;
        _entryText = entryText;
    }
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Promp: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
    }
}