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
            // 10 TESTS/INPUT SAMPLES (1000, 2000, ... 10,000)
            for (int i = 1; i <= 10; i++)
            {
                // CREATE WORST-CASE INPUT SAMPLES (fill library up with movies)
                // As we are only interested in the WORST-CASE...
                // Set NoBorrowings for all movies to 0 forcing ALL basic operations to execute
                IMovie[] sample = new IMovie[i * 1000];
                
                for (int j = 0; j < i * 1000; j++)
                {
                    IMovie temp = new Movie($"{j}");
                    temp.NoBorrowings = 0;
                    sample[j] = temp;
                }

                Console.WriteLine("yeeett" + sample.Length);

                // DISPLAY RESULT
                int count = MemberFunctions.TopThree(sample);
                Console.WriteLine($"Input: {i * 1000}\tCount: {count}\n");
            }
        }
    }
}

