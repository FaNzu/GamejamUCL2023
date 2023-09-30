using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.Model
{
	public class Item
	{
		public string Titel { get; set; }
		public string Description { get; set; }
		public Effects Effect { get; set; }
		public int Price { get; set; }
		
		public Item() 
		{
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
				Description = "Decreases your timer by 1 minut";
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
