using GambleOrDie.Games;
using GambleOrDie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.GameLogic
{
	public class NewPuzzle
	{
		private Player _player;
		private WordPuzzle puzzle;
		private int difficulty;
		private int multiplier;
		private int stake;

		public NewPuzzle(Player player)
		{
			_player = player;
			//Check highscore to set level of difficulty
			if (_player.Score <= 100)
			{
				difficulty = 1;
				multiplier = 2;
			}
			else if (_player.Score <= 200 && _player.Score > 100)
			{
				difficulty = 2;
				multiplier = 3;
			}
			else if (_player.Score <= 300 && _player.Score > 200)
			{
				difficulty = 3;
				multiplier = 4;
			}
			puzzle = new WordPuzzle();
			StartGamePuzzle();
		}
		public int BetCoins()
		{
			bool betNotMacthed = true;
			int result = 0;
			while (betNotMacthed)
			{
				int input;
				if (difficulty == 1)
				{
					input = Convert.ToInt32(Console.ReadLine());
					if (input <= 10 && input >= 25)
					{
						result = input;
						betNotMacthed = false;
					}
				}
				if (difficulty == 2)
				{
					input = Convert.ToInt32(Console.ReadLine());
					if (input <= 10 && input >= 50)
					{
						result = input;
						betNotMacthed = false;
					}
				}
				if (difficulty == 3)
				{
					input = Convert.ToInt32(Console.ReadLine());
					if (input <= 10 && input >= 75)
					{

						result = input;
						betNotMacthed = false;
					}
					else
					{
					}
				}
			}
			return result;
		}

		public void StartGamePuzzle()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			int option = 0;
			string decorator = "➡️ \u001b[32m";
			ConsoleKeyInfo key;
			bool isSelected = false;
			bool isFocused = true;

			while (isFocused)
			{
				while (!isSelected)
				{
					Console.Clear();
					Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
					Console.WriteLine("Use arrows and ENTER to navigate");
					Console.WriteLine($"{(option == 0 ? decorator : "  ")}Start New Game \u001b[0m");
					Console.WriteLine($"{(option == 1 ? decorator : "  ")}Back To Menu \u001b[0m");

					key = Console.ReadKey();

					switch (key.Key)
					{
						case ConsoleKey.UpArrow:
							option = option == 0 ? 2 : option - 1;
							break;
						case ConsoleKey.DownArrow:
							option = option == 2 ? 0 : option + 1;
							break;
						case ConsoleKey.Enter:
							isSelected = true;
							break;
					}
				}
				Console.Clear();
				isSelected = false;
				switch (option)
				{
					case 0:
						Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
						Console.WriteLine($"Difficulty set to: {difficulty}");
						Console.WriteLine($"Enter coins to bet (atleast 10 coins to start)");
						Anagram puzzle = new Anagram();
						puzzle.board(difficulty);
						break;
					case 1:
						Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
						Console.WriteLine("Returning To Main Menu");
						isSelected = true;
						isFocused = false;
						break;
				}
				Console.ReadKey();
			
			}
			// puzzle.NotImplmentedMethod(difficulty);
		}
	}
}
