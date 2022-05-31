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
        // Post-condition: Generates worst-case sample data for a series of tests and...
        //                 display the number of times basic operation is executed
        static void Emperical()
        {
            IMovieCollection lib;
            Random r = new Random();

            // 10 TESTS/INPUT SAMPLES (1000, 2000, ... 10,000)
            for (int i = 1; i <= 10; i++)
            {
                lib = new MovieCollection();

                // CREATE WORST-CASE INPUT SAMPLES (fill library up with movies)
                // As we are only interested in the WORST-CASE...
                // set first and second place at the beginning, and the rest in ascending order...
                // this means 3rd place always updates, forcing ALL basic operations to execute
                IMovie first = new Movie("always first");
                IMovie second = new Movie("always second");
                first.NoBorrowings = 2000000; // 2 million
                second.NoBorrowings = 1000000; // 1 million
                lib.Insert(first);
                lib.Insert(second);

                for (int j = 3; j <= i * 1000; j++) // ascending order so 3rd place always updates
                {
                    IMovie temp = new Movie($"j}");
                    temp.NoBorrowings = j;
                    lib.Insert(temp);
                }

                // DISPLAY RESULT
                int count = MemberFunctions.TopThree(lib.ToArray());
                Console.WriteLine($"Input: {i * 1000}\tCount: {count}\n");
            }
        }
    }
}

