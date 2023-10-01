using GambleOrDie.Events;
using GambleOrDie.Games;
using GambleOrDie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
		private Item chosenItem;

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


						Console.Clear();
						Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
						Console.WriteLine($"Difficulty set to: {difficulty}");
						Console.WriteLine($"Current coins: {_player.Coins}");
						stake = BetCoins();
						Console.Clear();
						Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");
						Console.WriteLine($"Difficulty set to: {difficulty}");
						Console.WriteLine($"Current bet: {stake}");
						Console.WriteLine($"Current coins: {_player.Coins}");

						if (_player.Items == null || _player.Items.Any())
						{

							if (UseItem())
							{
								chosenItem = GetItem();
								Console.WriteLine($"Chosen item is: {chosenItem.Titel} - {chosenItem.Description}");
							}
							else if (UseItem())
							{
								Console.WriteLine("No item was chosen");
							}
						}
						Console.WriteLine("Press ENTER to start the game");
						Console.ReadLine();
						Console.Clear();

						if (StartRandomPuzzleGame(chosenItem))
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

		public int BetCoins()
		{
			Console.Clear();
			Console.WriteLine("  _   _                 _____               _      \r\n | \\ | |               |  __ \\             | |     \r\n |  \\| | _____      __ | |__) |   _ _______| | ___ \r\n | . ` |/ _ \\ \\ /\\ / / |  ___/ | | |_  /_  / |/ _ \\\r\n | |\\  |  __/\\ V  V /  | |   | |_| |/ / / /| |  __/\r\n |_| \\_|\\___| \\_/\\_/   |_|    \\__,_/___/___|_|\\___|\r\n                                                   \r\n                                                   ");

			bool betNotMacthed = true;
			int result = 0;
			Console.WriteLine($"Current coins: {_player.Coins}");
			while (betNotMacthed)
			{
				int input;
				if (difficulty == 1)
				{
					Console.WriteLine("You're bet range is 10 - 25 coins");
					input = Convert.ToInt32(Console.ReadLine());

					if (input >= 10 && input <= 25 && input <= _player.Coins)
					{
						Console.WriteLine($"Confirm bet current bet? {input} (y/n)");
						bool betNotConfirmed = true;
						while (betNotConfirmed)
						{
							var inputExtra = Console.ReadLine();
							if (inputExtra == "y" || inputExtra == "yes")
							{
								betNotConfirmed = false;
								result = input;
								_player.Coins -= input;
								betNotMacthed = false;
							}
							else if (inputExtra == "n" || inputExtra == "no")
							{
								Console.WriteLine("Ok try another bet then....");
								betNotConfirmed = false;
							}
							else
							{
								Console.WriteLine("Please enter yes or no");
							}
						}
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

					if (input >= 10 && input <= 25 && input <= _player.Coins)
					{
						Console.WriteLine($"Confirm bet current bet? {input} (y/n)");
						bool betNotConfirmed = true;
						while (betNotConfirmed)
						{
							var inputExtra = Console.ReadLine();
							if (inputExtra == "y" || inputExtra == "yes")
							{
								betNotConfirmed = false;
								result = input;
								_player.Coins -= input;
								betNotMacthed = false;
							}
							else if (inputExtra == "n" || inputExtra == "no")
							{
								Console.WriteLine("Ok try another bet then....");
								betNotConfirmed = false;
							}
							else
							{
								Console.WriteLine("Please enter yes or no");
							}
						}
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

					if (input >= 10 && input <= 25 && input <= _player.Coins)
					{
						Console.WriteLine($"Confirm bet current bet? {input} (y/n)");
						bool betNotConfirmed = true;
						while (betNotConfirmed)
						{
							var inputExtra = Console.ReadLine();
							if (inputExtra == "y" || inputExtra == "yes")
							{
								betNotConfirmed = false;
								result = input;
								_player.Coins -= input;
								betNotMacthed = false;
							}
							else if (inputExtra == "n" || inputExtra == "no")
							{
								Console.WriteLine("Ok try another bet then....");
								betNotConfirmed = false;
							}
							else
							{
								Console.WriteLine("Please enter yes or no");
							}
						}
					}
					else
					{
						Console.WriteLine("Bet needs to be alteast 10 coins and not higher then 75 coins.");
					}
				}

			}
			return result;
		}

		public bool StartRandomPuzzleGame(Item? item)
		{
			bool result = false;
			Random random = new Random();
			switch (random.Next(0, 3))
			{
				case 0:
					result = WordPuzzle.board(difficulty, item);
					break;
				case 1:
					result = Anagram.board(difficulty, item);
					break;
				case 2:
					result = Wordle.board(difficulty);
					break;
			}
			return result;
		}

		public Item GetItem()
		{
			Console.WriteLine("Chose an item to use");

			foreach (Item item in _player.Items)
			{
				Console.WriteLine($"{item.Id} - {item.Titel} - {item.Description}");
			}
			int choice = Convert.ToInt32(Console.ReadLine());

			return _player.Items.Find(x => x.Id == choice);
		}

		public bool UseItem()
		{
			bool useItem = false;
			bool whileNotChosen = true;
			Console.WriteLine("Use item? (y/n)");
			string input = Console.ReadLine();
			while (whileNotChosen)
			{
				if (input == "y")
				{
					useItem = true;
					whileNotChosen = false;
				}
				else
				{
					Console.WriteLine("Enter y or n (yes/no)");
				}
				if (input == "n")
				{
					useItem = false;
					whileNotChosen = false;
				}
			}
			return useItem;
		}

		public void VictoryScenario()
		{
			int wonCoins = stake * multiplier;
			_player.Coins += wonCoins;

			Console.Clear();

			//20% chance for coinflip event
			CoinflipEvent coinflipEvent = new CoinflipEvent(_player);
			coinflipEvent.InvokeEvent();
			Console.Clear();

			if (_player.Coins <= 0)
			{
				DeathScreen deathScreen = new DeathScreen(_player);
			}

			Console.WriteLine(" __      ___      _                   _ \r\n \\ \\    / (_)    | |                 | |\r\n  \\ \\  / / _  ___| |_ ___  _ __ _   _| |\r\n   \\ \\/ / | |/ __| __/ _ \\| '__| | | | |\r\n    \\  /  | | (__| || (_) | |  | |_| |_|\r\n     \\/   |_|\\___|\\__\\___/|_|   \\__, (_)\r\n                                 __/ |  \r\n                                |___/   ");
			Console.WriteLine($"You won {wonCoins} coins!");

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
			if (_player.Coins == 0)
			{
				DeathScreen deathScreen = new DeathScreen(_player);
			}
			else if (_player.Strikes == 0)
			{
				DeathScreen deathScreen = new DeathScreen(_player);
			}

			CoinflipEvent coinflipEvent = new CoinflipEvent(_player);
			coinflipEvent.InvokeEvent();

			if (_player.Coins == 0)
			{
				DeathScreen deathScreen = new DeathScreen(_player);
			}

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


