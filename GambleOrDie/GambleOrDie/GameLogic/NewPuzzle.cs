using GambleOrDie.Events;
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
					Console.WriteLine("You're bet range is 10 - 25 coins");
					input = Convert.ToInt32(Console.ReadLine());
					if (input >= 10 && input <= 25)
					{
						result = input;
						_player.Coins -= input;
						betNotMacthed = false;
					}
					else
					{
						Console.WriteLine("Bet needs to be alteast 10 coins and not higher then 25 coins.");
					}
				}
				if (difficulty == 2)
				{
					Console.WriteLine("You're bet range is 10 - 50 coins");
					input = Convert.ToInt32(Console.ReadLine());
					if (input <= 10 && input >= 50)
					{
						result = input;
						_player.Coins -= input;
						betNotMacthed = false;
					}
					else
					{
						Console.WriteLine("Bet needs to be alteast 10 coins and not higher then 50 coins.");
					}
				}
				if (difficulty == 3)
				{
					Console.WriteLine("You're bet range is 10 - 75 coins");
					input = Convert.ToInt32(Console.ReadLine());
					if (input <= 10 && input >= 75)
					{
						result = input;
						_player.Coins -= input;
						betNotMacthed = false;
					}
					else
					{
						Console.WriteLine("Bet needs to be alteast 10 coins and not higher then 75 coins.");
					}
				}

			}
			return result;
		}

		public void StartGamePuzzle()
		{
			Console.OutputEncoding = Encoding.UTF8;

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
							option = option == 0 ? 1 : option - 1;
							break;
						case ConsoleKey.DownArrow:
							option = option == 1 ? 0 : option + 1;
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
					//START NEW GAME AND BET COINS
					case 0:
						Anagram puzzle = new Anagram();
						bool betNotConfirmed = true;
						while (betNotConfirmed)
						{
							Console.Clear();
							Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
							Console.WriteLine($"Difficulty set to: {difficulty}");
							stake = BetCoins();
							Console.Clear();
							Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
							Console.WriteLine($"Difficulty set to: {difficulty}");
							Console.WriteLine($"Confirm bet current bet? {stake} (y/n)");
							while (betNotConfirmed)
							{
								string input = Console.ReadLine();
								if (input == "y" || input == "yes")
								{
									betNotConfirmed = false;
								}
								else if (input == "n"|| input == "no")
								{
									Console.Clear();
									Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
									Console.WriteLine($"Difficulty set to: {difficulty}");
									stake = BetCoins();
								}
								else
								{
									Console.WriteLine("Please enter yes or no");
								}
							}
						}
						Console.Clear();
						if (puzzle.board(difficulty))
						{
							VictoryScenario();
						}
						else
						{
							DefeatScenario();
						}
						break;
					//EXIT BACK TO MAIN MENU
					case 1:
						Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
						Console.WriteLine("Returning To Main Menu");
						isSelected = true;
						isFocused = false;
						break;
				}
				Console.ReadKey();
			}
		}

		public void VictoryScenario()
		{
			Console.Clear();

			//20% chance for coinflip event
			CoinflipEvent coinflipEvent = new CoinflipEvent(_player);
			coinflipEvent.InvokeEvent();
			Console.Clear();

			Console.WriteLine(" __      ___      _                   _ \r\n \\ \\    / (_)    | |                 | |\r\n  \\ \\  / / _  ___| |_ ___  _ __ _   _| |\r\n   \\ \\/ / | |/ __| __/ _ \\| '__| | | | |\r\n    \\  /  | | (__| || (_) | |  | |_| |_|\r\n     \\/   |_|\\___|\\__\\___/|_|   \\__, (_)\r\n                                 __/ |  \r\n                                |___/   ");
			int wonCoins = stake * multiplier;
			Console.WriteLine($"You won {wonCoins} coins!");

			_player.Coins += wonCoins;
			Console.WriteLine($"New amount of coins {_player.Coins}");

			_player.Score += 50;
			Console.WriteLine($"New score {_player.Score}");

			Console.SetCursorPosition(0, 20);
			Console.WriteLine("(ENTER to continue)");

			Console.ReadKey();
		}

		public void DefeatScenario()
		{
			Console.Clear();
			//20% chance for coinflip event
			CoinflipEvent coinflipEvent = new CoinflipEvent(_player);
			coinflipEvent.InvokeEvent();
			Console.Clear();
			Console.WriteLine("  _____        __           _           \r\n |  __ \\      / _|         | |          \r\n | |  | | ___| |_ ___  __ _| |_         \r\n | |  | |/ _ \\  _/ _ \\/ _` | __|        \r\n | |__| |  __/ ||  __/ (_| | |_ _ _ _ _ \r\n |_____/ \\___|_| \\___|\\__,_|\\__(_|_|_|_)\r\n                                        \r\n                                        ");

			Console.WriteLine($"You lost you're bet of {stake} coins...");

			_player.Strikes -= 1;
			Console.WriteLine($"You lost a strike and you {_player.Strikes} strikes left... ");

			Console.SetCursorPosition(0, 20);
			Console.WriteLine("(ENTER to continue)");
			Console.ReadKey();
		}

	}
}
