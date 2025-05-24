using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Reference class: encapsulates the scripture reference (single verse or range)
    public class Reference
    {
        private string book;
        private int chapter;
        private int startVerse;
        private int endVerse;

        public Reference(string book, int chapter, int verse)
        {
            this.book = book;
            this.chapter = chapter;
            this.startVerse = verse;
            this.endVerse = verse;
        }

        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            this.book = book;
            this.chapter = chapter;
            this.startVerse = startVerse;
            this.endVerse = endVerse;
        }

        public override string ToString()
        {
            return endVerse == startVerse ? $"{book} {chapter}:{startVerse}" : $"{book} {chapter}:{startVerse}-{endVerse}";
        }
    }

    // Word class: encapsulates a word and its hidden/revealed state
    public class Word
    {
        private string text;
        private bool hidden;

        public Word(string text)
        {
            this.text = text;
            hidden = false;
        }

        public bool IsHidden()
        {
            return hidden;
        }

        public void Hide()
        {
            hidden = true;
        }

        public string GetDisplayText()
        {
            return hidden ? new string('_', text.Length) : text;
        }
    }

    // Scripture class: encapsulates scripture text and manages hiding/display
    public class Scripture
    {
        private Reference reference;
        private List<Word> words;
        private Random random;

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            words = text.Split(' ').Select(w => new Word(w)).ToList();
            random = new Random();
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(reference);
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", words.Select(w => w.GetDisplayText())));
            Console.WriteLine();
        }

        public void HideRandomWords(int count)
        {
            int totalWords = words.Count;
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(totalWords);
                words[index].Hide();
            }
        }

        public bool AllWordsHidden()
        {
            return words.All(w => w.IsHidden());
        }
    }

    // Main Program class
    class Program
    {
        static void Main(string[] args)
        {
            // You can expand this to load from a library of scriptures or a file
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding; In all thy ways acknowledge him and he shall direct thy paths.";
            Scripture scripture = new Scripture(reference, scriptureText);

            // Display initial scripture
            scripture.Display();

            while (true)
            {
                Console.WriteLine("Press Enter to hide more words or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWords(3);  // Hide 3 random words each round
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Program will end.");
                    break;
                }
            }
        }
    }
}
