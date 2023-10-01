using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.Games
{
	public class PuzzleGames
	{
		public Anagram Anagram { get; set; }
		public Wordle Wordle { get; set; }
		public WordPuzzle WordPuzzle { get; set; }
		public PuzzleGames() 
		{
			Anagram = new Anagram();
			Wordle = new Wordle();
			WordPuzzle = new WordPuzzle();
		}
	}
}
