/*
 * "C# Adventure Game" by http://programmingisfun.com, used under CC BY.
 * https://creativecommons.org/licenses/by/4.0/
 */

using System;
using System.Globalization;

namespace Adventure
{
    public static class Game
    {
        static int Scenarios = 3;
        static string CharacterName;

        static string[] PartOne = {
            "At the front of the imposing building you see a weathered old man with a cart.\nAs you near, you see the cart is filled with what looks like mostly junk and \nonly a few useful items. All you have on you is piece of a chalk.\nYou offer it to him, and he says he'll trade a flashlight or an umbrella for it.\nTo choose type either A for the flashlight, or B for the umbrella.",
            "The power in the building goes out - luckily you have a flashlight! \nYou move the light around and a large animal is frightened by the \nsudden brightness and takes off. As you move the light again, \nsomething glitters. You reach down and pick up a coin!",
            "The power in the building goes out! As you move down the hallway \nyou hear what sounds like a large animal nearby. You move the \numbrella in a widening arc in front of you to scare it, \nand the animal skitters off.",
            "The lights return and you move into a room at the end of the hall. \nThere is a vending machine.",
            "Luckily " + CharacterName + " you have that coin you found and you buy yourself a snack.",
            "Too bad you don't have a coin on you," + CharacterName + ",\nor you would have been able to get a snack.",
            "You begin to climb the stairs to the next floor."
        };
        static string[] PartTwo = {
            "Description of story part two ... and the choice A or B",
            "... part two - what happens if A is chosen...",
            "... part two - what happens if B is chosen...",
            "....more story.... .",
            "... part two, again - what happens if A is chosen...",
            "... part two again - what happens if B is chosen...",
            "You begin to climb the stairs to the next floor...."
        };
        static string[] PartThree = {
            "Description of story part three... and the choice A or B",
            "... part 3 - what happens if A is chosen...",
            "... part 3 - what happens if B is chosen...",
            "....more story.... .",
            "... part 3, again - what happens if A is chosen...",
            "... part 3 again - what happens if B is chosen...",
            "You begin to climb the stairs to the next floor...."
        };

        public static void StartGame()
        {
            GameTitle();

            //introduction text
            Utility.Write("You are about to enter the headquarters of your arch nemesis.");

            NameCharacter();
            Choice();
            EndGame();
        }

        public static void EndGame()
        {
            //end of game text
            Utility.Write("End of story text here.....");
            Utility.Write("Congratulations " + CharacterName + "!");
        }
        static void Choice()
        {
            for (int section = 1; section <= Scenarios; section++)
            {
                string input = "";

                switch (section)
                {
                    case 1:
                        //Part One

                        //same pattern for each of the sections. 1) print the first part of the section
                        Utility.Write(PartOne[0]);

                        //2)read in player's choice (a or b)
                        input = Utility.Input("Enter your choice");

                        //3) if a print the next part of the array, otherwise skip next and print 3rd
                        if (input == "a")
                        {
                            Utility.Write(PartOne[1]);

                        }
                        else
                        {
                            Utility.Write(PartOne[2]);
                        }

                        //4) print next part of the section
                        Utility.Write(PartOne[3]);

                        //5) again if a print next, otherwise skip ahead
                        if (input == "a")
                        {
                            Utility.Write(PartOne[4]);

                        }
                        else
                        {
                            Utility.Write(PartOne[5]);
                        }

                        //6) print last piece of the section
                        Utility.Write(PartOne[6]);



                        break;

                    case 2:
                        //Part Two

                        Utility.Write(PartTwo[0]);
                        input = Utility.Input("Enter your choice");

                        if (input == "a")
                        {
                            Utility.Write(PartTwo[1]);
                        }
                        else
                        {
                            Utility.Write(PartTwo[2]);
                        }

                        Utility.Write(PartTwo[3]);

                        if (input == "a")
                        {
                            Utility.Write(PartTwo[4]);
                        }
                        else
                        {
                            Utility.Write(PartTwo[5]);
                        }
                        Utility.Write(PartTwo[6]);

                        break;

                    case 3:
                        //Part Three
                        Utility.Write(PartThree[0]);

                        input = Utility.Input("Enter your choice");

                        if (input == "a")
                        {
                            Utility.Write(PartThree[1]);
                        }
                        else
                        {
                            Utility.Write(PartThree[2]);
                        }

                        Utility.Write(PartThree[3]);

                        if (input == "a")
                        {
                            Utility.Write(PartThree[4]);
                        }
                        else
                        {
                            Utility.Write(PartThree[5]);
                        }

                        Utility.Write(PartThree[6]);
                        break;

                    default:
                        //default if section number does not match one of the above
                        break;
                }

                //let player advance when ready, then clear the screen
                Utility.Pause();
            }
        }
        static void NameCharacter()
        {
            Utility.Write("You need a code name for this mission. What will it be?");

            CharacterName = Utility.Input("Enter your code name");

            Utility.Write("Your code name is confirmed to be " + CharacterName + ". Good luck!\n\n");

        }

        static void GameTitle()
        {
            Utility.Title("Super Game Adventure");
            Utility.Pause();
        }
    }
    class Item
    {

    }
    class Program
    {
        static void Main()
        {
            Game.StartGame();
            Console.Read();
        }

    }
    class Utility
    {
        static string margin = "  ";
        static string indent = "    ";

        public static string Input()
        {
            Console.Write(margin + ": ");
            string input = Console.ReadLine();
            input = input.ToLower();
            Console.ResetColor();
            return input;
        }
        public static string Input(string _string)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margin + _string + ": ");
            string input = Console.ReadLine();
            input = input.ToLower();
            Console.ResetColor();
            return input;
        }
        public static void Write(string _string)
        {
            _string = _string.Replace("\n", "\n" + margin);
            Console.WriteLine(margin + _string);
        }
        public static void Write(string _string, string _color)
        {
            _string = _string.Replace("\n", "\n" + margin);
            switch (_color)
            {
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "darkyellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "darkred":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkgreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkgray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "darkcyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkblue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Write(_string);
            Console.ResetColor();
        }
        public static void Write(string _string, string _color, string _background)
        {
            _string = _string.Replace("\n", "\n" + margin);
            switch (_color)
            {
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "darkyellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "darkred":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkgreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkgray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "darkcyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkblue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            switch (_background)
            {
                case "blue":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "magenta":
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "gray":
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case "darkyellow":
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                case "darkred":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkgreen":
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkgray":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case "darkcyan":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkblue":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
            }

            Write(_string);
            Console.ResetColor();
        }
        public static void Heading(string _string)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(margin + indent + _string);
            Console.ResetColor();
        }

        public static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(margin + "Press enter to continue...");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }

        public static void Title(string _title, string _subheading)
        {
            Console.Title = _title;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Center("Welcome to"));
            Console.WriteLine("\n" + Center("*´·._.·" + _title + "·._.·`*") + "\n");
            Console.WriteLine(Center(_subheading));
            Console.ResetColor();
        }
        public static void Title(string _title)
        {
            Console.Title = _title;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Center("Welcome to"));
            Console.WriteLine("\n" + Center("*´·._.·" + _title + "·._.·`*") + "\n");
            Console.ResetColor();
        }

        public static string Center(string _string)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = _string.Length;
            int spaces = (screenWidth / 2) + (stringWidth / 2);
            return _string.PadLeft(spaces);
        }

        public static string TitleCase(string _string)
        {
            TextInfo TitleCase = new CultureInfo("en-US", false).TextInfo;
            _string = TitleCase.ToTitleCase(_string);
            return _string;
        }

        //modification of method at https://msdn.microsoft.com/en-us/library/d9hy2xwa(v=vs.110).aspx
        public static bool Search(string[] _array, string _string)
        {
            bool result = false;
            int i = 0;
            foreach (string s in _array)
            {
                _array[i] = s.ToLower();
                i++;
            }

            if (Array.Find(_array, element => element == _string) == _string)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        //modification of DisplayValues method at https://msdn.microsoft.com/en-us/library/aw9s5t8f(v=vs.110).aspx
        public static void AllValues(String[] _array)
        {
            for (int i = _array.GetLowerBound(0); i <= _array.GetUpperBound(0); i++)
            {
                Console.WriteLine(margin + _array[i]);
            }
            Console.WriteLine();
        }
    }
}