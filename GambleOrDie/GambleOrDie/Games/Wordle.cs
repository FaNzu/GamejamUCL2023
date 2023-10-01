using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GambleOrDie.Model;
using static System.Net.Mime.MediaTypeNames;

namespace GambleOrDie.Games
{
    public class Wordle
    {
        private static Item iteminUse;
        private static List<string> Words = new List<string> {
            "adult", "agent", "anger", "apple", "award", "beach", "birth", "block", "chant", "banjo", "cough", "humor",
            "board", "brain", "bread", "break", "brown", "brand", "beast", "bench", "cello", "beans", "brave", "brass",
            "grass", "green", "mouse", "bored", "board", "beard", "phone", "brick", "breed", "plane", "plank", "squat",
            "camel", "crown", "crate", "creed", "greed", "plead", "speed", "steed", "carry", "curry", "hurry", "cause",
            "chain", "motto", "count", "glass", "candy", "laugh", "anime", "manga", "demon", "scare", "stole", "stand",
            "sheet", "music", "staff", "steal", "panda", "print", "perch", "parch", "purse", "craft", "close", "clash",
            "clock", "cream", "climb", "gongs", "power", "snake", "badge", "paper", "chair", "table", "spoon", "knife",
            "plate", "pasta", "spill", "spork", "sport", "trash", "model", "chest", "limit", "cloud", "chief", "spine",
            "boing", "chore", "paint", "white", "black", "child", "coast", "night", "human", "puppy", "zebra", "sound",
            "chime", "river", "piano", "shirt", "under", "haven", "ghost", "scarf", "grill", "chill", "crack", "sugar",
            "flour", "melon", "money", "mango", "bring", "broom", "sting", "steam", "smell", "taste", "sight", "touch",
            "voice", "speak", "after", "while", "stick", "stern", "spank", "spank", "bling", "broke", "brain", "brawl",
            "misty", "blink", "flame", "ditto", "drink", "koala", "clown", "hover", "cower", "cover", "tower", "glock",
            "roach", "harsh", "cross", "disco", "cocoa", "slide", "aback", "acorn", "admin", "essay", "fruit", "humor"};
        static bool victory = false;

        public static bool board(int? difficultyGiven)
        {
            int difficulty = difficultyGiven != null ? difficultyGiven.Value : 1;
            

            //Random Word Picker
            Random numberGen = new Random();
            int random = 0;
            Console.WriteLine("Start the game");

            for (int k = 0; k < difficulty; k++)
            {
                Console.WriteLine($"word number {k} out of {difficulty}");

                random = numberGen.Next(0, Words.Count());

                string guess;
                string theWord = (Words[random]);
                Console.WriteLine("Type your first guess (lowercase only)");

                //Guessing
                for (int i = 0; i <= 4; i++) // 5 tries per word
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    guess = Console.ReadLine();
                    if (guess.Length != 5)
                    {
                        Console.WriteLine("try agian");
                        i--;
                    }
                    else
                    {
                        Console.ForegroundColor = GetLetterColor(theWord[0], guess[0], theWord, difficulty);
                        Console.WriteLine(guess[0]);

                        Console.ForegroundColor = GetLetterColor(theWord[1], guess[1], theWord, difficulty);
                        Console.WriteLine(guess[1]);

                        Console.ForegroundColor = GetLetterColor(theWord[2], guess[2], theWord, difficulty);
                        Console.WriteLine(guess[2]);

                        Console.ForegroundColor = GetLetterColor(theWord[3], guess[3], theWord, difficulty);
                        Console.WriteLine(guess[3]);

                        Console.ForegroundColor = GetLetterColor(theWord[4], guess[4], theWord, difficulty);
                        Console.WriteLine(guess[4]);
                    }

                    //Win
                    if (guess == theWord)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You did it!");
                        victory = true;
                        break;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"you've guessed wrong you have {5 - i} tries left");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The Word Was: " + theWord);
            }
            Console.ReadLine();
            //Wait Before Closing
            return victory;
        }


        // Function to get letter color based on comparison
        private static ConsoleColor GetLetterColor(char wordChar, char guessChar, string theWord, int difficulty)
        {
            if (wordChar == guessChar)
            {
                return ConsoleColor.Green;
            }
            else if (theWord.Contains(guessChar.ToString()) && difficulty <= 3)
            {
                return ConsoleColor.Yellow;
            }
            else
            {
                return ConsoleColor.Red;
            }
        }
    }
}
