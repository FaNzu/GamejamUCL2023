using GambleOrDie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.GameLogic
{
	public class DeathScreen
	{
		public DeathScreen(Player player) 
		{
			Console.Clear();
			Console.WriteLine("   _____                         ____                          \r\n  / ____|                       / __ \\                         \r\n | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __          \r\n | | |_ |/ _` | '_ ` _ \\ / _ \\ | |  | \\ \\ / / _ \\ '__|         \r\n | |__| | (_| | | | | | |  __/ | |__| |\\ V /  __/ |_ _ _ _ _ _ \r\n  \\_____|\\__,_|_| |_| |_|\\___|  \\____/  \\_/ \\___|_(_|_|_|_|_|_)\r\n                                                               \r\n                                                               ");
			Console.WriteLine("You have lost the game!");
			Console.WriteLine($"Score was: {player.Score}");
			Console.WriteLine($"Coin amount was: {player.Coins}");
			Console.ReadKey();
			Environment.Exit(0);
		}
	}
}
