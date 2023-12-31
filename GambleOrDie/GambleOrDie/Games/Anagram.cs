﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GambleOrDie.Model;

namespace GambleOrDie.Games
{
    public class Anagram 
    {

        #region variables
        //private Item itemInUse;
        private static string[] allwords = {
                "Elephant","Journey","Symphony","Rainbow",
                "Library","Whistle","Weather","Mountain",
                "Blossom","Harmony","Telescope","Universe",
                "Computer","Blossom","Eruption","Adventure",
                "Firework","Serenity","Wildlife","Discovery"
            };
        static int difficulty = 1; // lav logic der styre sværhedsgrads
        private static List<string> correctWords = new List<string>();
        #endregion


        public static bool board(int? difficultyGiven, Item givenItem)
        {
            Random random = new Random();
            difficulty = difficultyGiven != null ? difficultyGiven.Value : 1;
            for (int i = 0; i < 3; i++)
            {
                string selectedWord = allwords[random.Next(0, allwords.Length)];
                if (!correctWords.Contains(selectedWord.ToLower()))
                {
                    Console.WriteLine(selectedWord);
                    string shuffledWord = Shuffle(selectedWord);
                    correctWords.Add(selectedWord.ToLower());
                    Console.WriteLine(shuffledWord.ToLower());
                }
                else
                {
                    i--;
                }
            }
            bool victory = isValidGuess(difficulty, givenItem);

            return victory;
        }

        private static bool isValidGuess(int difficulty, Item? givenItem)
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

            int lives = 3; //adjust with difficulty
            if (difficulty <= 2)
            {
                lives = 5;
            }

            TimeOnly startTime = TimeOnly.FromDateTime(DateTime.Now);
            TimeOnly endTime = startTime.Add(new TimeSpan(0, 0, timeToPlay)); //60 is time in total for puzzle
            //list of words the player has guessed correct
            List<string> correctlyGuessedWords = new List<string>();

            //if time left and isnt dead and isnt 
            while (TimeOnly.FromDateTime(DateTime.Now) < endTime && lives > 0 && correctlyGuessedWords.Count() / correctWords.Count() != 1) // if the specified amount of time hasn't passed yet
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine(new string(' ', Console.WindowWidth)); // Clears the line from column 10 to the end
                Console.WriteLine($"you have {lives} lives left");
                Console.WriteLine($"you have {endTime - TimeOnly.FromDateTime(DateTime.Now)} left");

                Console.SetCursorPosition(10, 20);
                Console.Write("Type: ");
                string input = Console.ReadLine().ToLower();//input
                if (correctWords.Contains(input) && !correctlyGuessedWords.Contains(input))//check if player input is correct
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

            }
            Console.SetCursorPosition(0, 20);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, 20);

            if (lives <= 0)
                Console.WriteLine("\nYou ran out of lives\n");
            else if (correctlyGuessedWords.Count() / correctWords.Count() == 1)
                Console.WriteLine("you've guessed all the words");
            else
                Console.WriteLine("\ntime has run out\n");
            Console.WriteLine($"you correctly guessed {correctlyGuessedWords.Count()}/3");

            return ((correctlyGuessedWords.Count() / 3) >= 1 ? true : false); //if player guessed all words return true
        }



        static string Shuffle(string list)
        //shuffling the given word and returns it
        {
            int index;
            Random R = new Random();
            List<char> chars = new List<char>(list);
            StringBuilder sb = new StringBuilder();
            while (chars.Count > 0)
            {
                index = R.Next(chars.Count);
                sb.Append(chars[index]);
                chars.RemoveAt(index);
            }
            return sb.ToString();
        }
    }
}
