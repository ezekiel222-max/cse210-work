using System;
using System.Collections.Generic;
using System.IO;
// Author: Ezekiel Edem
// Project: Journal Application
// Description: A console app to record and manage journal entries.
// Exceeds requirements by adding file handling, input validation, and entry formatting.

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} - {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    public override string ToString()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromString(string line)
    {
        var parts = line.Split('|');
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        return null;
    }
}

class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What made you smile today?",
        "What are you grateful for right now?",
        "Describe a challenge you overcame recently.",
        "What's a goal you're working toward?",
        "Write about a recent experience that brought you joy."
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        if (File.Exists(file))
        {
            foreach (var line in File.ReadAllLines(file))
            {
                Entry entry = Entry.FromString(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Your response: ");
                string entryText = Console.ReadLine();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                Entry entry = new Entry(date, prompt, entryText);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save to: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load from: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose again.");
            }

            Console.WriteLine();
        }
    }
}
