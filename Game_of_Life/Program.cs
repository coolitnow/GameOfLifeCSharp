using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string alive = " _ ";
            string dead = " + ";

            //string[] colors = new string[5] { "White" dead, "Yellow", "Green", "Orange", "Red" oldest};
            //int colorIndex = 0;
            //

            Console.WriteLine("Welcome to the game of life! What size world would you like to create?");
            int gridSize = Convert.ToInt32(Console.ReadLine());
            string[,] mommyGrid = new string[gridSize, gridSize];
            string[,] babyGrid = new string[gridSize, gridSize];
            int[,] ageGrid = new int[gridSize, gridSize]; // keeps count of generations, changes color as ages.

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    Random rand = new Random();
                    double randnum = rand.NextDouble();
                    if (randnum < .2)
                        mommyGrid[x, y] = alive;
                    else
                        mommyGrid[x, y] = dead;
                }
            }

          
            bool run= true;
            while (run)
            {
                // displaying mommy grid for the user
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        if (mommyGrid[x, y].Equals(alive))
                        {
                            if (ageGrid[x, y] >= 5) //setting colors to show the different generations, red is oldest
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write(mommyGrid[x, y]);
                            }
                            if (ageGrid[x, y] == 4)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.Write(mommyGrid[x, y]);
                            }
                            if (ageGrid[x, y] == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(mommyGrid[x, y]);
                            }
                            if (ageGrid[x, y] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write(mommyGrid[x, y]);
                            }
                            if (ageGrid[x, y] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(mommyGrid[x, y]);
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(mommyGrid[x, y]);
                        }
                        babyGrid[x, y] = mommyGrid[x, y];
                    }
                    Console.WriteLine();
                }
                // counts number of alives
                int aliveCount = 0;
                // checking our rules
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        aliveCount = 0;
                        // this loop iterates around the coordinates around a given
                        for (int xoffset = -1; xoffset < 2; xoffset++)
                        {
                            for (int yoffset = -1; yoffset < 2; yoffset++)
                            {
                                int testX = x + xoffset;
                                int testY = y + yoffset;
                                if (!(testX <= 0 || testX >= gridSize || testY <= 0 || testY >= gridSize) && !(testX == x && testY == y))
                                {
                                    //as long as this is a valid square to check, proceed
                                    if (mommyGrid[testX, testY] == alive)
                                    {
                                        aliveCount++;
                                    }
                                }
                            }
                        }

                        if (mommyGrid[x, y].Equals(alive))
                        {
                            if (aliveCount != 2 && aliveCount != 3)
                            {
                                babyGrid[x, y] = dead;
                                ageGrid[x, y] = 0;
                            }
                            else
                            {
                             ageGrid[x, y]++;
                            }
                        }
                        else
                        {
                            if (aliveCount == 3)
                            {
                                babyGrid[x, y] = alive;
                                ageGrid[x, y]++;
                            }
                        }
                    }
                }
                for (int gridx = 0; gridx < gridSize; gridx++)
                {
                    for (int gridy = 0; gridy < gridSize; gridy++)
                    {
                        mommyGrid[gridx, gridy] = babyGrid[gridx, gridy];
                    }
                }
                //Console.ReadLine();
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}


