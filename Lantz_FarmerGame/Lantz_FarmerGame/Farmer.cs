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
 
    class Farmer
    {
       
//Constructor to initialize values
        public Farmer()
        {
            northBank.Add("FOX");
            northBank.Add("CHICKEN");
            northBank.Add("GRAIN");
            TheFarmer = Direction.North;
        }

//Fields
        public enum Direction
        {
            North,
            South,
        };

        private ArrayList northBank = new ArrayList();
        private ArrayList southBank = new ArrayList();
        private Direction farmer;

//Properties
        public ArrayList NorthBank { get => northBank; set => northBank = value; }
        public ArrayList SouthBank { get => southBank; set => southBank = value; }
        public Direction TheFarmer { get; set; }

//Return true if animal ate the food
        public bool AnimalAteFood()
        {
            if ((northBank.Contains("FOX")
                && northBank.Contains("CHICKEN")) 
                && TheFarmer != Direction.North)
            {
                Clear();
                
                Write("\n\n\nAw man!");
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("  Fox ate the chicken!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("\nGAME OVER");
                Console.ResetColor();
                return true;
            }
            if ((southBank.Contains("FOX")
                && southBank.Contains("CHICKEN"))
                && TheFarmer != Direction.South)
            {
                Clear();

                Write("\n\n\nAw man!");
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("  Fox ate the chicken!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("\nGAME OVER");
                Console.ResetColor();

                return true;
            }

            if (northBank.Contains("CHICKEN")
                && northBank.Contains("GRAIN")
                && TheFarmer != Direction.North)
            {
                Clear();

                Write("\n\n\nAw man!");
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("  Chicken ate the grain!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("\nGAME OVER");
                Console.ResetColor();

                return true;
            }

            if ((southBank.Contains("CHICKEN")
                && southBank.Contains("GRAIN"))
                && TheFarmer != Direction.South)
                {
                Clear();

                Write("\n\n\nAw man!");
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("  Chicken ate the grain!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("\nGAME OVER");
                Console.ResetColor();

                return true;
            }
            else
                return false;
        }
        
//Return true if game is won
        public bool DetermineWin()
        {
            if (southBank.Contains("FOX")
                && southBank.Contains("GRAIN")
                && southBank.Contains("CHICKEN"))
            {
                Clear();
                Write("\n\n\nYou win!!!");
                Write("\nNice job!!!");
                return true;
            }
            else
                return false;
        }

 //Test user choice for location of value
//Take user choice and move it to other side of river
        public void Move(String userChoice)
        {
            while (true)
            {
                if (TheFarmer == Direction.North)
                {
                    if (northBank.Contains(userChoice))
                    {
                        northBank.Remove(userChoice);
                        southBank.Add(userChoice);
                        TheFarmer = Direction.South;
                        Clear();
                        break;
                    }
                    else if (!northBank.Contains(userChoice) && !String.IsNullOrEmpty(userChoice))
                    {
                        Clear();
                        WriteLine("\nThat item is not on this side of the river.");
                        WriteLine("\nPlease try again...");
                        break;
                    }
                    else if (String.IsNullOrEmpty(userChoice))
                        Clear();
                    TheFarmer = Direction.South;
                    break;
                }

                if (TheFarmer == Direction.South)
                {
                    if (southBank.Contains(userChoice))
                    {
                        southBank.Remove(userChoice);
                        northBank.Add(userChoice);
                        TheFarmer = Direction.North;
                        Clear();
                        break;
                    }
                    else if (!southBank.Contains(userChoice) && !String.IsNullOrEmpty(userChoice))
                    {
                        Clear();
                        WriteLine("\nThat item is not on this side of the river.");
                        WriteLine("\nPlease try again...");
                        break;
                    }
                    else
                        TheFarmer = Direction.North;
                    Clear();
                    break;
                }
            }
        }//End of Move()

//Boolean test for game status
        public bool GameOver()
        {
            if (AnimalAteFood() == true || DetermineWin() == true)
                return true;
            else
                return false;
        }

    }//End of class
}//End of namespace
