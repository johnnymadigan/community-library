// Johnny n Jamie's
// █▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█
// █▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░
// Initialises new global database with default staff credentials
// Calls initial interface (main menu)
using System;

namespace CommunityLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            new Records("staff", "today123");

            //TestStaffFunctions.RunAllTests();
            //TestMemberFunctions.RunAllTests();
            //Emperical();

            MainMenu.DisplayMainMenu();
        }


        // EMPIRCAL ANALYSIS on TOPTHREE ALGORITHM
        // Pre-condition: Nil
        // Post-condition: Generates sample data for a series of tests and...
        //                 display the number of times basic operation is executed
        static void Emperical()
        {
            IMovieCollection lib;
            Random r = new Random();

            for (int i = 1; i <= 10; i++) // 10 TESTS/INPUT SAMPLES (1000, 2000, ... 10,000)
            {
                lib = new MovieCollection();

                for (int j = 0; j <= i * 1000; j++) // CREATE INPUT SAMPLES (fill library up with movies)
                {
                    IMovie temp = new Movie($"{j}", MovieGenre.Action, MovieClassification.G, 1, 100);
                    temp.NoBorrowings = r.Next(101); // generate random NoBorrowings for each movie [0..100]
                    lib.Insert(temp);
                }

                // Run algo and display result
                int count = MemberFunctions.TopThree(lib.ToArray());
                Console.WriteLine($"Input: {i * 1000}\tCount: {count}\n");
            }
        }
    }
}

