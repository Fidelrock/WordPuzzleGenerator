using System;
using System.Linq;
using WordPuzzleGenerator.Services;

namespace WordPuzzleGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words to include in the puzzle (comma-separated): ");
            var input = Console.ReadLine();

            var words = input?.Split(',').Select(w=>w.Trim()).Where(w => w.Length > 0).ToList();

            var puzzle = new PuzzleGenerator(words);
            puzzle.Generate();

            Console.WriteLine("\n🔠 Word Puzzle:\n");

            puzzle.Display();

            Console.WriteLine("\n✅ Words Included:");
            words.ForEach(w => Console.WriteLine("- " + w.ToUpper()));

        }
    }
}
