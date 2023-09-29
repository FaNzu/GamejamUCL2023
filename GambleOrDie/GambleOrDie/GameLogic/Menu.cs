using GambleOrDie.Model;

namespace GambleOrDie.GameLogic
{
	public class Menu
	{

		private Player _player;
		public int HighScore { get; set; }
		public int LowScore { get; set; }
		public Menu(Player player)
		{
			_player = player;
		}
		public void StartMenu()
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
					Console.WriteLine("   _____                 _     _         ____         _____  _      _ \r\n  / ____|               | |   | |       / __ \\       |  __ \\(_)    | |\r\n | |  __  __ _ _ __ ___ | |__ | | ___  | |  | |_ __  | |  | |_  ___| |\r\n | | |_ |/ _` | '_ ` _ \\| '_ \\| |/ _ \\ | |  | | '__| | |  | | |/ _ \\ |\r\n | |__| | (_| | | | | | | |_) | |  __/ | |__| | |    | |__| | |  __/_|\r\n  \\_____|\\__,_|_| |_| |_|_.__/|_|\\___|  \\____/|_|    |_____/|_|\\___(_)\r\n                                                                      \r\n                                                                      ");
					Console.WriteLine("Use arrows and ENTER to navigate");
					Console.WriteLine($"{(option == 0 ? decorator : "  ")}Shop \u001b[0m");
					Console.WriteLine($"{(option == 1 ? decorator : "  ")}Inventory \u001b[0m");
					Console.WriteLine($"{(option == 2 ? decorator : "  ")}Start New Game \u001b[0m");
					Console.WriteLine($"{(option == 3 ? decorator : "  ")}Exit \u001b[0m");

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
						Shop shop = new Shop(_player);
						shop.StartShop();
						break;
					case 1:
						Console.WriteLine("Here is your inventory");
						foreach (Item item in _player.Items)
						{
							Console.WriteLine($"{item.Titel} - {item.Description}");
						}
						break;
					case 2:
						break;
					case 3:
						Console.WriteLine("   _____                 _     _         ____         _____  _      _ \r\n  / ____|               | |   | |       / __ \\       |  __ \\(_)    | |\r\n | |  __  __ _ _ __ ___ | |__ | | ___  | |  | |_ __  | |  | |_  ___| |\r\n | | |_ |/ _` | '_ ` _ \\| '_ \\| |/ _ \\ | |  | | '__| | |  | | |/ _ \\ |\r\n | |__| | (_| | | | | | | |_) | |  __/ | |__| | |    | |__| | |  __/_|\r\n  \\_____|\\__,_|_| |_| |_|_.__/|_|\\___|  \\____/|_|    |_____/|_|\\___(_)\r\n                                                                      \r\n                                                                      ");
						isSelected = true;
						isFocused = false;
						break;
				}
				Console.ReadKey();
			}
		}
	}
}
