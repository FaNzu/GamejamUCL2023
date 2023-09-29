using GambleOrDie.Games;

namespace GambleOrDie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            WordPuzzle wbs = new WordPuzzle();
            wbs.board();
        }
    }
}