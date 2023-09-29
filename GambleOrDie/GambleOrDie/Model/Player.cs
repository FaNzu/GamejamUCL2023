using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.Model
{
	public class Player
	{
		public int Coins { get; set; }
		public string Name { get; set; }
		public List<Item> Items { get; set; }
		public int Strikes { get; set; }
		public int Score { get; set; }
		public Player(string name) 
		{
			Items = new List<Item>();
			Strikes = 3;
			Score = 0;
			Name = name;
			Coins = 10;
		}
	}
}
