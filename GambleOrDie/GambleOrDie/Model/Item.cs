using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.Model
{
	public class Item
	{
		public int Id { get; set; }
		public string Titel { get; set; }
		public string Description { get; set; }
		public Effects Effect { get; set; }
		public int Price { get; set; }
		private static int id = 1;
		private static int GenerateId()
		{
			return id++;
		}

		public Item() 
		{
			Id = GenerateId();
			Price = 25;
			Random random= new Random();
			int randomResult = random.Next(0,3);

			if(randomResult == 0)
			{
				Effect = Effects.TimeAdder;
				Titel = "Clock Increaser 1000 Inator";
				Description = "Increases your timer by 2 minuts";
			}
			else if (randomResult == 1)
			{
				Effect = Effects.TimeRemover;
				Titel = "Clock Decreaser 2000 Inator";
				Description = "Decreases your timer by 1 minut, but gives extra coins if you win a game";
			}
			else
			{
				Effect = Effects.Hint;
				Titel = "Hint me";
				Description = "Gives a hint";
			}
		}
	}
}
