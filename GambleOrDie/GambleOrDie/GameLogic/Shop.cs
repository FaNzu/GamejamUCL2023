using GambleOrDie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.GameLogic
{
	public class Shop
	{
		private Player _player;
		public Shop(Player player) 
		{
			_player = player;
		}
		public void StartShop()
		{
			Console.OutputEncoding = Encoding.UTF8;

			int option = 0;
			string decorator = "➡️ \u001b[32m";
			ConsoleKeyInfo key;
			bool isSelected = false;
			bool isFocused = true;

			while (isFocused)
			{
				Console.Clear();
				while (!isSelected)
				{
					Console.Clear();
					Console.WriteLine("   _____ _                 \r\n  / ____| |                \r\n | (___ | |__   ___  _ __  \r\n  \\___ \\| '_ \\ / _ \\| '_ \\ \r\n  ____) | | | | (_) | |_) |\r\n |_____/|_| |_|\\___/| .__/ \r\n                    | |    \r\n                    |_|    ");
					Console.WriteLine("Use arrows and ENTER to navigate");
					Console.WriteLine($"{(option == 0 ? decorator : "  ")}Buy Item \u001b[0m");
					Console.WriteLine($"{(option == 1 ? decorator : "  ")}Back To Main Menu \u001b[0m");

					key = Console.ReadKey();

					switch (key.Key)
					{
						case ConsoleKey.UpArrow:
							option = option == 0 ? 5 : option - 1;
							break;
						case ConsoleKey.DownArrow:
							option = option == 5 ? 0 : option + 1;
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
						Item boughtItem = new Item();
						_player.Coins = _player.Coins - boughtItem.Price;
						_player.Items.Add(boughtItem);
						Console.WriteLine("You've got lucky with this one!");
						Console.WriteLine($"{boughtItem.Titel} - {boughtItem.Description}");
						break; 
					case 1:
						isSelected = true;
						isFocused = false;
						Console.WriteLine("See ya!");
						break;
				}
				Console.ReadKey();
			}
		}
	}
}
