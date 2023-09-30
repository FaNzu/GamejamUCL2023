using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambleOrDie.Games
{
    internal class Wordle
    {
        public void board()
        {

            List<string> Words = new List<string>();

            //Word List  
            Words.Add("adult");
            Words.Add("agent");
            Words.Add("anger");
            Words.Add("apple");
            Words.Add("award");
            Words.Add("beach");
            Words.Add("birth");
            Words.Add("block");
            Words.Add("board");
            Words.Add("brain");
            Words.Add("bread");
            Words.Add("break");
            Words.Add("brown");
            Words.Add("brand");
            Words.Add("beast");
            Words.Add("bench");
            Words.Add("cello");
            Words.Add("beans");
            Words.Add("brave");
            Words.Add("brass");
            Words.Add("grass");
            Words.Add("green");
            Words.Add("mouse");
            Words.Add("bored");
            Words.Add("board");
            Words.Add("beard");
            Words.Add("phone");
            Words.Add("brick");
            Words.Add("breed");
            Words.Add("plane");
            Words.Add("plank");
            Words.Add("squat");
            Words.Add("camel");
            Words.Add("crown");
            Words.Add("crate");
            Words.Add("creed");
            Words.Add("greed");
            Words.Add("plead");
            Words.Add("speed");
            Words.Add("steed");
            Words.Add("carry");
            Words.Add("curry");
            Words.Add("hurry");
            Words.Add("cause");
            Words.Add("chain");
            Words.Add("motto");
            Words.Add("count");
            Words.Add("glass");
            Words.Add("candy");
            Words.Add("laugh");
            Words.Add("anime");
            Words.Add("manga");
            Words.Add("demon");
            Words.Add("scare");
            Words.Add("stole");
            Words.Add("stand");
            Words.Add("sheet");
            Words.Add("music");
            Words.Add("staff");
            Words.Add("steal");
            Words.Add("panda");
            Words.Add("print");
            Words.Add("perch");
            Words.Add("parch");
            Words.Add("purse");
            Words.Add("craft");
            Words.Add("close");
            Words.Add("clash");
            Words.Add("clock");
            Words.Add("cream");
            Words.Add("climb");
            Words.Add("gongs");
            Words.Add("power");
            Words.Add("snake");
            Words.Add("badge");
            Words.Add("paper");
            Words.Add("chair");
            Words.Add("table");
            Words.Add("spoon");
            Words.Add("knife");
            Words.Add("plate");
            Words.Add("pasta");
            Words.Add("spill");
            Words.Add("spork");
            Words.Add("sport");
            Words.Add("trash");
            Words.Add("model");
            Words.Add("chest");
            Words.Add("limit");
            Words.Add("cloud");
            Words.Add("chief");
            Words.Add("spine");
            Words.Add("boing");
            Words.Add("chore");
            Words.Add("paint");
            Words.Add("white");
            Words.Add("black");
            Words.Add("child");
            Words.Add("coast");
            Words.Add("night");
            Words.Add("human");
            Words.Add("puppy");
            Words.Add("zebra");
            Words.Add("sound");
            Words.Add("chime");
            Words.Add("river");
            Words.Add("piano");
            Words.Add("shirt");
            Words.Add("under");
            Words.Add("haven");
            Words.Add("ghost");
            Words.Add("scarf");
            Words.Add("grill");
            Words.Add("chill");
            Words.Add("crack");
            Words.Add("sugar");
            Words.Add("flour");
            Words.Add("melon");
            Words.Add("money");
            Words.Add("mango");
            Words.Add("bring");
            Words.Add("broom");
            Words.Add("sting");
            Words.Add("steam");
            Words.Add("smell");
            Words.Add("taste");
            Words.Add("sight");
            Words.Add("touch");
            Words.Add("voice");
            Words.Add("speak");
            Words.Add("after");
            Words.Add("while");
            Words.Add("stick");
            Words.Add("stern");
            Words.Add("spank");
            Words.Add("spank");
            Words.Add("bling");
            Words.Add("broke");
            Words.Add("brain");
            Words.Add("brawl");
            Words.Add("misty");
            Words.Add("blink");
            Words.Add("flame");
            Words.Add("ditto");
            Words.Add("drink");
            Words.Add("koala");
            Words.Add("clown");
            Words.Add("hover");
            Words.Add("cower");
            Words.Add("cover");
            Words.Add("tower");
            Words.Add("glock");
            Words.Add("roach");
            Words.Add("harsh");
            Words.Add("cross");
            Words.Add("disco");
            Words.Add("cocoa");
            Words.Add("slide");
            Words.Add("aback");
            Words.Add("acorn");
            Words.Add("admin");
            Words.Add("essay");
            Words.Add("fruit");
            Words.Add("humor");
            Words.Add("chant");
            Words.Add("banjo");
            Words.Add("cough");



            //Random Word Picker
            Random numberGen = new Random();

            int random = 0;

            //Choices
            Console.WriteLine("Start the game");
            Console.WriteLine("Old or New Layout?");
            string answer = Console.ReadLine();

            //New
            if (answer == "New")
            {
                Console.WriteLine("Do You Want Asian Mode?");
                answer = Console.ReadLine();

                //Yes
                if (answer == "Yes")
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

                        string guess = Convert.ToString(Console.ReadLine());

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
                else if (answer == "No")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        random = numberGen.Next(0, 163);
                    }
                    string theWord = (Words[random]);
                    Console.WriteLine("Type your first guess (lowercase only)");

                    //Guessing

                    for (int i = 0; i < 9; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        string guess = Convert.ToString(Console.ReadLine());

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

                        //First Letter
                        if (a == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(aa);
                        }
                        else if (b == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(aa);
                        }
                        else if (c == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(aa);
                        }
                        else if (d == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(aa);
                        }
                        else if (e == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                        else if (a == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(bb);
                        }
                        else if (c == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(bb);
                        }
                        else if (d == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(bb);
                        }
                        else if (e == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                        else if (a == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(cc);
                        }
                        else if (b == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(cc);
                        }
                        else if (d == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(cc);
                        }
                        else if (e == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                        else if (a == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(dd);
                        }
                        else if (b == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(dd);
                        }
                        else if (c == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(dd);
                        }
                        else if (e == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                        else if (a == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(ee);
                            Console.WriteLine("");
                        }
                        else if (b == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(ee);
                            Console.WriteLine("");
                        }
                        else if (c == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(ee);
                            Console.WriteLine("");
                        }
                        else if (d == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
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

                //Wait Before Closing
                Console.ReadKey();
            }

            //Old
            else if (answer == "Old")
            {
                Console.WriteLine("Do You Want Asian Mode?");
                answer = Console.ReadLine();

                //Yes
                if (answer == "Yes")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        random = numberGen.Next(0, 158);
                    }
                    string theWord = (Words[random]);
                    Console.WriteLine("Type your first guess (lowercase only)");

                    //Guessing

                    for (int i = 0; i < 7; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        string guess = Convert.ToString(Console.ReadLine());

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
                            Console.WriteLine("The First Letter Matches!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The First Letter Does Not Match");
                        }

                        //Second Letter
                        if (b == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Second Letter Matches!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Second Letter Does Not Match");
                        }

                        //Third Letter
                        if (c == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Third Letter Matches!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Third Letter Does Not Match");
                        }

                        //Fourth Letter
                        if (d == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Fourth Letter Matches!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Fourth Letter Does Not Match");
                        }

                        //Fifth Letter
                        if (e == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Fifth Letter Matches!");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Fifth Letter Does Not Match");
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
                else if (answer == "No")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        random = numberGen.Next(0, 158);
                    }
                    string theWord = (Words[random]);
                    Console.WriteLine("Type your first guess (lowercase only)");

                    //Guessing

                    for (int i = 0; i < 9; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        string guess = Convert.ToString(Console.ReadLine());

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

                        //First Letter
                        if (a == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The First Letter Matches!");
                        }
                        else if (b == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The First Letter Is In The Wrong Spot!");
                        }
                        else if (c == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The First Letter Is In The Wrong Spot!");
                        }
                        else if (d == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The First Letter Is In The Wrong Spot!");
                        }
                        else if (e == aa)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The First Letter Is In The Wrong Spot!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The First Letter Does Not Match");
                        }

                        //Second Letter
                        if (b == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Second Letter Matches!");
                        }
                        else if (a == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Second Letter Is In The Wrong Spot!");
                        }
                        else if (c == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Second Letter Is In The Wrong Spot!");
                        }
                        else if (d == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Second Letter Is In The Wrong Spot!");
                        }
                        else if (e == bb)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Second Letter Is In The Wrong Spot!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Second Letter Does Not Match");
                        }

                        //Third Letter
                        if (c == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Third Letter Matches!");
                        }
                        else if (a == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Third Letter Is In The Wrong Spot!");
                        }
                        else if (b == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Third Letter Is In The Wrong Spot!");
                        }
                        else if (d == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Third Letter Is In The Wrong Spot!");
                        }
                        else if (e == cc)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Third Letter Is In The Wrong Spot!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Third Letter Does Not Match");
                        }

                        //Fourth Letter
                        if (d == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Fourth Letter Matches!");
                        }
                        else if (a == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Fourth Letter Is In The Wrong Spot!");
                        }
                        else if (b == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Fourth Letter Is In The Wrong Spot!");
                        }
                        else if (c == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Fourth Letter Is In The Wrong Spot!");
                        }
                        else if (e == dd)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Fourth Letter Is In The Wrong Spot!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Fourth Letter Does Not Match");
                        }

                        //Fifth Letter
                        if (e == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The Fifth Letter Matches!");
                            Console.WriteLine("");
                        }
                        else if (a == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Fifth Letter Is In The Wrong Spot!");
                            Console.WriteLine("");
                        }
                        else if (b == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Fifth Letter Is In The Wrong Spot!");
                            Console.WriteLine("");
                        }
                        else if (c == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Fifth Letter Is In The Wrong Spot!");
                            Console.WriteLine("");
                        }
                        else if (d == ee)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Fifth Letter Is In The Wrong Spot!");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The Fifth Letter Does Not Match");
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

                //Wait Before Closing
                Console.ReadKey();
            }

        }
    }
}