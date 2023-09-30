using GambleOrDie.GameLogic;
using GambleOrDie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.Events
{
	public class CoinflipEvent
	{
		private readonly double probability;
		private readonly int multiplier;
		private string bet;
		private string playerChoice;
		private Player _player;
		private Random random;
		private Dictionary<int, string> coinFlipData;

		public CoinflipEvent(Player player)
		{
			probability = 0.2;
			multiplier = 2;
			_player = player;
			random = new Random();
			coinFlipData = new Dictionary<int, string>
			{
				{ 0, "heads" },
				{ 1, "tails" }
			};
		}

		public void InvokeEvent()
		{
			double randomValue = random.NextDouble();

			// Check if the event should trigger based on the probability
			if (randomValue <= probability)
			{
				EventTriggered();
			}
		}

		public void EventTriggered()
		{
			Console.Clear();
			Console.WriteLine("   _____      _        __ _ _         ______               _   _ \r\n  / ____|    (_)      / _| (_)       |  ____|             | | | |\r\n | |     ___  _ _ __ | |_| |_ _ __   | |____   _____ _ __ | |_| |\r\n | |    / _ \\| | '_ \\|  _| | | '_ \\  |  __\\ \\ / / _ \\ '_ \\| __| |\r\n | |___| (_) | | | | | | | | | |_) | | |___\\ V /  __/ | | | |_|_|\r\n  \\_____\\___/|_|_| |_|_| |_|_| .__/  |______\\_/ \\___|_| |_|\\__(_)\r\n                             | |                                 \r\n                             |_|                                 ");
			Console.WriteLine("Rules: This event is a coinflip, here you can bet x amount of coins, double it or lose the bet!");
			Console.WriteLine($"You're amount of coins: {_player.Coins}");
			Console.WriteLine("Enter amount to bet:");
			bool check = true;
			while (check)
			{
				try
				{
					bet = Console.ReadLine();
					if (Convert.ToInt32(bet) > _player.Coins)
					{
						_player.Coins -= Convert.ToInt32(bet);
						check = false;
					}
					else 
					{
						Console.WriteLine("Bet is more than you have... Enter amount again");
					}
				}
				catch
				{
					Console.WriteLine("Please enter valid amount of coins");
				}
			}

			Console.Clear();
			Console.WriteLine("   _____      _        __ _ _         ______               _   _ \r\n  / ____|    (_)      / _| (_)       |  ____|             | | | |\r\n | |     ___  _ _ __ | |_| |_ _ __   | |____   _____ _ __ | |_| |\r\n | |    / _ \\| | '_ \\|  _| | | '_ \\  |  __\\ \\ / / _ \\ '_ \\| __| |\r\n | |___| (_) | | | | | | | | | |_) | | |___\\ V /  __/ | | | |_|_|\r\n  \\_____\\___/|_|_| |_|_| |_|_| .__/  |______\\_/ \\___|_| |_|\\__(_)\r\n                             | |                                 \r\n                             |_|                                 ");
			Console.WriteLine("Rules: This event is a coinflip, here you can bet x amount of coins, double it or lose the bet!");
			Console.WriteLine($"You're amount of coins: {_player.Coins}");
			Console.WriteLine($"Bet: {bet}");
			Console.WriteLine("Heads or Tails? What's you're lucky pick?");
			check = true;
			while (check)
			{
				try
				{
					playerChoice = Console.ReadLine();
					check = false;
				}
				catch
				{
					Console.WriteLine("Please enter head or tails (h/t)");
				}
			}

			string flipCoinText = "Flipping coin";
			Console.WriteLine(flipCoinText);
			for (int i = 0; i < 5; i++)
			{
				Thread.Sleep(500);
				Console.Write(".");
			}

			int flippedCoin = random.Next(0, 1);
			string result = coinFlipData[flippedCoin];

			Console.WriteLine("It lands on " + result + "!");

			if (playerChoice == result)
			{
				//Write code that ads the coins with multiplier
				Console.WriteLine("You won the bet!");
				int coinsWon = Convert.ToInt32(bet) * multiplier;
				Console.WriteLine($"Coins won {coinsWon}");
				_player.Coins += coinsWon;
				Console.WriteLine($"New coin balance {_player.Coins}");
			}
			if (playerChoice != result)
			{
				//Write code that subtracts the bet coins
				Console.WriteLine("You lost the bet...");
				Console.WriteLine($"New coin balance {_player.Coins}");
			}
		}
	}
}
