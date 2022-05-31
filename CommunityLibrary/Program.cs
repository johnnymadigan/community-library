// Johnny n Jamie's
// █▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█
// █▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░
// Initialises new global database with default staff credentials
// Calls initial interface (main menu)
using System;
using System.Diagnostics;

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
        // Post-condition: Generates sample data for a series of tests and displays...
        //                 number of times basic operation is executed and total time elapsed
        static void Emperical()
        {
            IMovieCollection lib;
            Random r = new Random();

            for (int i = 1; i <= 10; i++) // 10 INPUT SAMPLES (1000, 2000, ... 10,000)
            {
                lib = new MovieCollection();

                for (int j = 0; j <= i * 1000; j++) // CREATE INPUT SAMPLES 
                {
                    IMovie temp = new Movie($"{j}", MovieGenre.Action, MovieClassification.G, 1, 100);
                    temp.NoBorrowings = r.Next(101); // generate random NoBorrowings [0..100]
                    lib.Insert(temp);
                }

                Stopwatch timer = new Stopwatch(); // New stopwatch for each test
                timer.Start();
                int count = MemberFunctions.TopThree(lib.ToArray()); // Run algo
                timer.Stop();
                TimeSpan elapsed = timer.Elapsed;
                Console.WriteLine($"Input: {i * 1000}\tCount: {count}\tTime: {elapsed:m\\:ss\\.fff}\n"); // Result
            }
        }
    }
}

