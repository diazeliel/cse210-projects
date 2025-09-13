
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"{entry._date}:{entry._entryText}");
        }
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date},{entry._promptText},{entry._entryText}");
            }
        }

    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string prompText = parts[1];
                    string entryText = parts[2];
                    _entries.Add(new Entry( date, prompText, entryText));
                }
            }
        }
    }
}
       