﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using GambleOrDie.Model;


namespace GambleOrDie.Games
{
	class WordPuzzle
	{

		#region variables
		private static int width = 10;
		private static int height = 10;
		private static char[,] alrPlacedWords;
		private static string[] allwords = {
			"HELLO", "DOOR", "NINE", "EIGHT",
			"APPLE", "BANANA", "ORANGE", "MANGO", "STRAWBERRY",
			"CAR", "BUS", "TRAIN", "PLANE", "SHIP",
			"DOG", "CAT", "ELEPHANT", "LION", "TIGER",
			"HOUSE", "SCHOOL", "PARK", "HOSPITAL", "LIBRARY",
			"COMPUTER", "PHONE", "TABLE", "CHAIR", "BOOK"
		};
		private static List<string> selectedWords = new List<string>();
		private static int difficulty = 1;
		#endregion

		private static char[,] PlaceWord(string word, char[,] grid, Random random, int width, int height, int difficulty)
		{
			if (alrPlacedWords == null)
			{
				alrPlacedWords = new char[width, height];
			}
			//reverse word if difficulty == 3
			if (random.Next(2) == 0 && difficulty >= 3)
			{
				word = new string(word.Reverse().ToArray());
			}
			//word = random.Next(2) == 0 ? word : new string(word.Reverse().ToArray());

			//1,1 is vertically

			int[,] directions;
			if (difficulty >= 2)
				// Include horizontal, vertical, and down-right directions
				directions = new int[,] { { 1, 0 }, { 0, 1 }, { 1, 1 } };
			else
				directions = new int[,] { { 1, 0 }, { 0, 1 } };

			int directionIndex = random.Next(directions.GetLength(0));
			int[] direction = { directions[directionIndex, 0], directions[directionIndex, 1] };

			int xStart;
			int yStart;
			if (direction[0] == 0)
				xStart = width;
			else
				xStart = width - word.Length;

			if (direction[1] == 0)
				yStart = height;
			else
				yStart = height - word.Length;

			int x = random.Next(0, xStart);
			int y = random.Next(0, yStart);

			for (int c = 0; c < word.Length; c++)
			{
				if (alrPlacedWords[x + direction[0] * c, y + direction[1] * c] != '\0')
				{
					// Word cannot be placed here, try again
					return PlaceWord(word, grid, random, width, height, difficulty);
				}
			}
			for (int c = 0; c < word.Length; c++)
			{
				grid[x + direction[0] * c, y + direction[1] * c] = word[c];
				alrPlacedWords[x + direction[0] * c, y + direction[1] * c] = word[c];
			}

			return grid;
		}


		public static bool board(int? difficultyGiven, Item? givenItem)
		{

			difficulty = difficultyGiven != null ? difficultyGiven.Value : 1;
			char[,] grid = new char[width, height];
			Random random = new Random();


			//fills grid with random letters
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					//grid[i, j] = (char)' ';
					grid[i, j] = (char)('A' + random.Next(26)); //fyld grid ud med bogstaver
				}
			}

			//set limiter for 5 words, adjust to difficulty
			for (int i = 0; i < 5; i++)
			{
				int randomIndex = random.Next(0, allwords.Length);
				string selectedWord = allwords[randomIndex];

				// Check if the word is already selected to avoid duplicates
				if (!selectedWords.Contains(selectedWord))
					selectedWords.Add(selectedWord);
				else
					i--;
				// If the word is a duplicate, decrease the loop counter to select another word
			}

			foreach (string word in selectedWords) // place words on board, overriding the previous letter
			{
				PlaceWord(word, grid, random, width, height, difficulty);
			}

			StringBuilder stringBuilder = new StringBuilder();
			// Display the word search puzzle
			Console.WriteLine("Word Search Puzzle: ");
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					stringBuilder.Append(grid[j, i] + " ");
				}
				stringBuilder.Append('\n');
			}
			bool victory = false;//game starts losing
			Console.WriteLine(stringBuilder);
			victory = isValidInput(givenItem); //change victory if player won
			Console.WriteLine(victory.ToString());
			Console.ReadLine();
			return victory;
		}

		private static bool isValidInput(Item? givenItem)
		{
			int timeToPlay = 120;
			if (givenItem != null)
			{
				switch (givenItem.Effect)
				{
					case Effects.TimeRemover:
						timeToPlay -= 60;
						break;
					case Effects.TimeAdder:
						timeToPlay += 60;
						break;
				}
			}
			TimeOnly startTime = TimeOnly.FromDateTime(DateTime.Now);
			TimeOnly endTime = startTime.Add(new TimeSpan(0, 0, timeToPlay)); //60 is time in total for puzzle
			int lives = 3; //adjust with difficulty
			List<string> correctlyGuessedWords = new List<string>();
			//list of words the player has guessed correct
			while (TimeOnly.FromDateTime(DateTime.Now) < endTime && lives > 0 && correctlyGuessedWords.Count() / selectedWords.Count() != 1) // if the specified amount of time hasn't passed yet
			{
				Console.SetCursorPosition(0, 12 + height);
				Console.WriteLine(new string(' ', Console.WindowWidth - 10)); // Clears the line from column 10 to the end
				Console.WriteLine($"you have {lives} lives left");

				Console.SetCursorPosition(10, 12 + height);
				Console.Write("Type: ");
				string input = Console.ReadLine().ToUpper();//input
				if (selectedWords.Contains(input) && !correctlyGuessedWords.Contains(input))//if the word player guessed is on the board
				{
					Console.WriteLine("You guessed right");
					correctlyGuessedWords.Add(input); //add to the list
				}
				else if (correctlyGuessedWords.Contains(input))
					Console.WriteLine("You've already guessed this!");
				else
				{
					Console.WriteLine("wrong guess");
					//remove life according to difficulty
					lives--;
				}

				Console.WriteLine($"you have {endTime - TimeOnly.FromDateTime(DateTime.Now)} left");
				Console.WriteLine($"You are missing {selectedWords.Count() - correctlyGuessedWords.Count()}");
			}
			if (lives <= 0)
				Console.WriteLine("\nYou ran out of lives\n");
			else if (correctlyGuessedWords.Count() / selectedWords.Count() == 1)
			{
				Console.WriteLine("You guessed them all");
			}
			else
				Console.WriteLine("\ntime has run out\n");
			Console.WriteLine($"you correctly guessed {correctlyGuessedWords.Count()}/{selectedWords.Count()}");

			return ((correctlyGuessedWords.Count() / selectedWords.Count()) == 1 ? true : false); //if player guessed all words return true
		}
	}
}