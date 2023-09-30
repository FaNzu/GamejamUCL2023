using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GambleOrDie.Games
{
    internal class Wordle
    {
        public void board(int? difficultyGiven)
        {

            List<string> Words = new List<string> {
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
            int difficulty = difficultyGiven != null ? difficultyGiven.Value : 1;


            //Random Word Picker
            Random numberGen = new Random();

            int random = 0;

            //Choices
            Console.WriteLine("Start the game");

            //Yes
            if (difficulty == 3)
            {
                for (int i = 0; i < 1; i++)
                {
                    random = numberGen.Next(0, 163);
                }
                string theWord = (Words[random]);
                Console.WriteLine("Type your first guess (lowercase only)");

                //Guessing

                for (int i = 0; i < 7; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    string guess = Console.ReadLine();
                    if (guess.Length != 5)
                    {
                        Console.WriteLine("try agian");
                        i--;
                    }
                    char a = theWord[0];
                    char b = theWord[1];
                    char c = theWord[2];
                    char d = theWord[3];
                    char e = theWord[4];

                    char aa = guess[0];
                    char bb = guess[1];
                    char cc = guess[2];
                    char dd = guess[3];
                    char ee = guess[4];

                    //First Letter Guess
                    if (a == aa)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(aa);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(aa);
                    }

                    //Second Letter
                    if (b == bb)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(bb);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(bb);
                    }

                    //Third Letter
                    if (c == cc)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(cc);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(cc);
                    }

                    //Fourth Letter
                    if (d == dd)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(dd);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(dd);
                    }

                    //Fifth Letter
                    if (e == ee)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(ee);
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ee);
                        Console.WriteLine("");
                    }


                    //Win
                    if (guess == theWord)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You did it!");
                        i = 999;
                    }

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The Word Was: " + theWord);
            }

            //No
            else if (difficulty <= 2 )
            {
                string theWord = Words[random];
                Console.WriteLine("Type your first guess (lowercase only)");
                

                for (int i = 0; i < 9; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    string guess = Console.ReadLine();
                    if(guess.Length != 5)
                    {
                        Console.WriteLine("try agian");
                        i--;
                    }
                    else
                    {

                        Console.ForegroundColor = GetLetterColor(theWord[0], guess[0], theWord);
                        Console.WriteLine(guess[0]);

                        Console.ForegroundColor = GetLetterColor(theWord[1], guess[1], theWord);
                        Console.WriteLine(guess[1]);

                        Console.ForegroundColor = GetLetterColor(theWord[2], guess[2], theWord);
                        Console.WriteLine(guess[2]);

                        Console.ForegroundColor = GetLetterColor(theWord[3], guess[3], theWord);
                        Console.WriteLine(guess[3]);

                        Console.ForegroundColor = GetLetterColor(theWord[4], guess[4], theWord);
                        Console.WriteLine(guess[4]);

                        if (guess == theWord)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("You did it!");
                            break;
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The Word Was: " + theWord);

                
            }

            //Wait Before Closing
            Console.ReadKey();
        }
        // Function to get letter color based on comparison
        private ConsoleColor GetLetterColor(char wordChar, char guessChar, string theWord)
        {
            if (wordChar == guessChar)
            {
                return ConsoleColor.Green;
            }
            else if (theWord.Contains(guessChar.ToString()))
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
