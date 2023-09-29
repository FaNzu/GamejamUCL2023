﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace GambleOrDie.Games
{
    class WordPuzzle
    {
        private static char[,] alrPlacedWords;
        string[] allwords = {
                "HELLO", "DOOR", "NINE", "EIGHT",
                "APPLE", "BANANA", "ORANGE", "MANGO", "STRAWBERRY",
                "CAR", "BUS", "TRAIN", "PLANE", "SHIP",
                "DOG", "CAT", "ELEPHANT", "LION", "TIGER",
                "HOUSE", "SCHOOL", "PARK", "HOSPITAL", "LIBRARY",
                "COMPUTER", "PHONE", "TABLE", "CHAIR", "BOOK"
            };
        List<string> selectedWords = new List<string>();




        static char[,] PlaceWord(string word, char[,] grid, Random random, int width, int height, int difficulty)
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
                xStart = width - word.Length - 1;

            if (direction[1] == 0)
                yStart = height;
            else
                yStart = height - word.Length - 1;

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


        public void board()
        {
            int width = 10;
            int height = 10;
            char[,] grid = new char[width, height];
            Random random = new Random();

            int difficulty = 1; // lav logic der styre sværhedsgrads
            
            //fills grid with random letters
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    grid[i, j] = (char)' ';
                    //grid[i, j] = (char)('A' + random.Next(26)); //fyld grid ud med bogstaver
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

            foreach(string word in selectedWords) // place words on board, overriding the previous letter
            {
                PlaceWord(word, grid, random, width, height, difficulty);
            }

            // Display the word search puzzle
            Console.WriteLine("Word Search Puzzle:");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(grid[j, i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}