using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Collections;
/*Steven Lantz
ITDEV-115-501
Fall 2019
Assignment 6: Farmer Game*/

namespace Lantz_FarmerGame
{

    class FarmerUI//Holds console logic for game
    {
        Farmer farmer = new Farmer();
        Information info = new Information();

//Displays info, welcome message and instructions
//Boolean test to ask user to continue or quit at end
        public void PlayGame()
        {
            bool playAgain = false ;
            String input;

            info.MyInfo("Assignment 6: Farmer Game");

            PressEnter("Press enter to continue...");
            Clear();

        //Display welcome message and directions
            DisplayWelcome();

            PressEnter("Press any key when you are " +
                                        "ready to start this thought " +
                                        "provoking game...");
            Clear();

            do//Play again or exit app
            {
                do//Check for game win/loss
                {
                    //Controls main aspects of game play
                    Play();
                    
                } while (!farmer.GameOver());

            //Reset values
                farmer.TheFarmer = Farmer.Direction.North;
                farmer.NorthBank.Clear();
                farmer.SouthBank.Clear();
                farmer.NorthBank.Add("FOX");
                farmer.NorthBank.Add("CHICKEN");
                farmer.NorthBank.Add("GRAIN");
             
            //Play again or exit app
                WriteLine("\n\nWould you like to play again? ");
                WriteLine("\n[y] to play again");
                Write("[n] to quit: ");

                input = ReadLine();

                if (input.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                    playAgain = true;

                Clear();
                
            } while (!playAgain);
        }//end of PlayGame()

//Controls main aspects of game play
        public void Play()
        {
            DisplayGameState();
            ProcessChoice(PromptForMove());
        }

//Shows north/south banks & river
        public void DisplayGameState()
        {
            WriteLine("\n\n\n\n");
            
            //Display the 'north' bank
            DisplaynNorthBank();

            WriteLine();

            DisplayRiver();

        //Display the 'south' bank
            DisplaynSouthBank();

        //Display farmer status
            WriteLine("\nThe farmer is on the " + farmer.TheFarmer+ " bank of the river.");
            
        }

//Get user choice
        public string PromptForMove()
        {
            Write("\nChoose the next item for the farmer." +
                "  If you choose nothing, just hit the enter key: ");

            string userInput = ReadLine().ToUpper();

            return userInput;
        }

//Test user choice for validity
//Take user choice and move it to other side of river 
        public void ProcessChoice(string userChoice)
        {
            farmer.Move(userChoice);
        }

//Display contents of ArrayList northBank and graphic
        public void DisplaynNorthBank()
        {
            String grass = "VVVVVVVVVVVVVVVVVVVVVVVVVVVVVV" +
                "VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV";
            String stars = "**************************North Bank" + 
                "**********************************";

            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.Green;
            }

            WriteLine(grass);
            WriteLine(grass);
            WriteLine(grass);
            WriteLine(stars);

            Console.ResetColor();

            foreach (var item in farmer.NorthBank)
            {
                Write(item + "   ");
            }
        }

//Display contents of ArrayList southBank and graphic
        public void DisplaynSouthBank()
        {
            String grass = "VVVVVVVVVVVVVVVVVVVVVVVVVVVVVV" +
                "VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV";
            String stars = "**************************South Bank" +
                "**********************************";

            foreach (var item in farmer.SouthBank)
            {
                Write(item + "   ");
            }

            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.Green;
            }


            WriteLine();
            WriteLine(grass);
            WriteLine(grass);
            WriteLine(grass);
            WriteLine(stars);

            Console.ResetColor();
        }

//Display river graphic
        public void DisplayRiver()
        {
            string waves = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            WriteLine(waves);
            WriteLine(waves);
            WriteLine(waves);
            WriteLine(waves);

            Console.ResetColor();
        }

//Welcome message and directions
        public void DisplayWelcome()
            {
        //Change text output color to red if user has a black background
            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Write("\n\n\t\tWelcome to the Farmer Game!!!. ");
            Write("\n\n\tThe object of the game is to get the farmer, fox, chicken, and grain " +
            "\n\tto the other side of the river.");
            Write("\n\n\tBut hold on, not so fast. ");
            Write(" \n\n\tIf the farmer leaves the chicken and grain on either side of the river alone, " +
            "\n\tthe chicken will eat the grain and that is not good.  ");
            Write("\n\n\tIf the farmer leaves the fox and chicken on any side of the river alone," +
            "\n\tthe fox will eat the chicken. That is also not good.  ");
            Write("\n\n\tIn either case you lose the game.  ");
            Write("\n\n\tIf you get the farmer, the chicken,the fox, and the grain ");
            Write("\n\tsafely across the river and intact, you win!!!!!!!");
            Write("\n\n\t\tGood Luck!!!!!!");

            Console.ResetColor();
        }


//Use to ask user to press enter
//Displays any message passed in
            public void PressEnter(String message)
            {
                WriteLine("\n\n");
                Write("\t" + message);
                ReadKey();
            }

    }//End of class
}//End of namespace
