// MEMBER TEST PLANS
// Test member functions through a range of scenarios
using System;
namespace CommunityLibrary
{
	public class TestMemberFunctions
	{
		public static void RunAllTests()
		{
            TestDisplayAllMovies();
            TestDisplayMovieInfo();
            TestBorrowDVD();
            TestReturnDVD();
            TestDisplayCurrentBorrowings();
            TestTopThree();
		}



        public static void TestDisplayAllMovies()
        {
            Console.WriteLine("\n======== DisplayAllMovies test plan ========");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("pirates", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie b = new Movie("arcane", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);

            // SCENARIO #1: LIBRARY EMPTY
            Console.WriteLine("SCENARIO: Library empty, no movies to display");
            Console.WriteLine($"EXPECTED:\nLibrary empty...");
            Console.WriteLine("RESULT:");
            MemberFunctions.DisplayAllMovies();

            //// SCENARIO #2: ADDED 2 MOVIES
            Records.lib.Insert(a);
            Records.lib.Insert(b);
            Console.WriteLine("\nSCENARIO: Added 2 movies, displays both in dictionary order");
            Console.WriteLine($"EXPECTED:\n({b.ToString()})\n({a.ToString()})");
            Console.WriteLine("RESULT:");
            MemberFunctions.DisplayAllMovies();

            //// SCENARIO #3: REMOVED 1 EXISTING MOVIE
            Records.lib.Delete(b);
            Console.WriteLine("\nSCENARIO: Removed 1 existing movie, does not display removed movie");
            Console.WriteLine($"EXPECTED:\n({a.ToString()})");
            Console.WriteLine("RESULT:");
            MemberFunctions.DisplayAllMovies();

            Records.Reset();
        }



        public static void TestDisplayMovieInfo()
        {
            Console.WriteLine("\n======== DisplayMovieInfo test plan ========");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("pirates", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);

            // SCENARIO #1: MOVIE DOES NOT EXIST (expecting to catch exception)
            try
            {
                MemberFunctions.DisplayMovieInfo("dummy");
                Console.WriteLine("SCENARIO FAILED: Movie does not exist");
            }
            catch (CustomException) { Console.WriteLine("SCENARIO PASSED: Movie does not exist"); }

            // SCENARIO #2: MOVIE EXISTS, DISPLAYS ALL INFO
            Records.lib.Insert(a);
            Console.WriteLine("\nSCENARIO: Movie exists, displays all info");
            Console.WriteLine($"EXPECTED:\n({a.ToString()})");
            Console.WriteLine("RESULT:");
            MemberFunctions.DisplayMovieInfo(a.Title);

            // SCENARIO #3: MOVIE NO LONGER EXISTS (expecting to catch exception)
            try
            {
                Records.lib.Delete(a);
                MemberFunctions.DisplayMovieInfo(a.Title);
                Console.WriteLine("\nSCENARIO FAILED: Movie removed and now no longer displays info");
            }
            catch (CustomException) { Console.WriteLine("\nSCENARIO PASSED: Movie removed and now no longer displays info"); }
            Records.Reset();
        }



        public static void TestBorrowDVD()
        {
            Console.WriteLine("\n======== BorrowDVD test plan ========");
            Records.Reset();

            // TEST DATA
            IMember m = new Member("johnny", "madman", "0411111111", "1234");

            IMovie a = new Movie("pirates", MovieGenre.Action, MovieClassification.G, 100, 1);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.G, 100, 1);
            IMovie c = new Movie("batman", MovieGenre.Action, MovieClassification.G, 100, 1);
            IMovie d = new Movie("midsommar", MovieGenre.Action, MovieClassification.G, 100, 1);
            IMovie e = new Movie("evangelion", MovieGenre.Action, MovieClassification.G, 100, 1);
            IMovie f = new Movie("love+death+robots", MovieGenre.Action, MovieClassification.G, 100, 1); // 6th movie to attempt borrowing 5+
            IMovie g = new Movie("shrek", MovieGenre.Action, MovieClassification.G, 100, 0);             // no available copies
            IMovie h = new Movie("cowboybebop", MovieGenre.Action, MovieClassification.G, 100, 20);      // movie already borrowed by 10 members
            for (int i = 0; i < 10; i++) h.AddBorrower(new Member($"{i}", $"{i}"));                      // fill movie up to max borrowers limit (10)

            Records.reg.Add(m);
            Records.lib.Insert(a);
            Records.lib.Insert(b);
            Records.lib.Insert(c);
            Records.lib.Insert(d);
            Records.lib.Insert(e);
            Records.lib.Insert(f);
            Records.lib.Insert(g);
            Records.lib.Insert(h);

            // SCENARIO #1: MEMBER TRIES TO BORROW A MOVIE THAT DOES NOT EXIST (expecting to catch exception)
            try
            {
                MemberFunctions.BorrowDVD(new Movie("dummy"), m);
                Console.WriteLine("SCENARIO FAILED: Member tries to borrow a movie that does not exist");
            }
            catch (CustomException) { Console.WriteLine("SCENARIO PASSED: Member tries to borrow a movie that does not exist"); }

            // SCENARIO #2: MEMBER HAS BORROWED A DVD (expecting true)
            if (MemberFunctions.BorrowDVD(a, m)) Console.WriteLine("SCENARIO PASSED: Member has borrowed a DVD");
            else Console.WriteLine("SCENARIO FAILED: Member has borrowed a DVD");

            // SCENARIO #3: MEMBER TRIES TO BORROW A MOVIE TWICE (expecting to catch exception)
            try
            {
                MemberFunctions.BorrowDVD(a, m);
                Console.WriteLine("SCENARIO FAILED: Member tries to borrow a movie twice");
            }
            catch (CustomException) { Console.WriteLine("SCENARIO PASSED: Member tries to borrow a movie twice"); }

            // SCENARIO #4: MEMBER TRIES TO BORROW A MOVIE W NO AVAILABLE COPIES (expecting to catch exception)
            try
            {
                MemberFunctions.BorrowDVD(g, m);
                Console.WriteLine("SCENARIO FAILED: Member tries to borrow a movie w no available copies");
            }
            catch (CustomException) { Console.WriteLine("SCENARIO PASSED: Member tries to borrow a movie w no available copies"); }

            // SCENARIO #5: MEMBER TRIES TO BORROW A MOVIE HOWEVER MOVIE AT MAX BORROWERS (10) (expecting false)
            if (!MemberFunctions.BorrowDVD(h, m)) Console.WriteLine("SCENARIO PASSED: Member tries to borrow a movie however movie at max borrowers (10)");
            else Console.WriteLine("SCENARIO FAILED: Member tries to borrow a movie however movie at max borrowers (10)");

            // SCENARIO #6: MEMBER TRIES TO BORROW PAST BORROWING LIMIT (5) (expecting to catch exception)
            MemberFunctions.BorrowDVD(b, m);
            MemberFunctions.BorrowDVD(c, m);
            MemberFunctions.BorrowDVD(d, m);
            MemberFunctions.BorrowDVD(e, m);

            try
            {
                MemberFunctions.BorrowDVD(f, m);
                Console.WriteLine("SCENARIO FAILED: Member tries to borrow past borrowing limit (5)");
            }
            catch (CustomException) { Console.WriteLine("SCENARIO PASSED: Member tries to borrow past borrowing limit (5)"); }

            Records.Reset();
        }



        public static void TestReturnDVD()
        {
            Console.WriteLine("\n======== ReturnDVD test plan ========");
            Records.Reset();

            // TEST DATA
            IMember m = new Member("johnny", "madman", "0411111111", "1234");

            IMovie a = new Movie("pirates", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);

            Records.reg.Add(m);
            Records.lib.Insert(a);

            // SCENARIO #1: MEMBER TRIES TO RETURN A MOVIE THAT DOES NOT EXIST (expecting to catch exception)
            try
            {
                MemberFunctions.ReturnDVD(new Movie("dummy"), m);
                Console.WriteLine("SCENARIO FAILED: Member tries to return a movie that does not exist");
            }
            catch (CustomException) { Console.WriteLine("SCENARIO PASSED: Member tries to return a movie that does not exist"); }

            // SCENARIO #2: MEMBER HAS RETURNED A DVD (expecting true)
            a.AddBorrower(m);
            if (MemberFunctions.ReturnDVD(a, m)) Console.WriteLine("SCENARIO PASSED: Member has returned a DVD");
            else Console.WriteLine("SCENARIO FAILED: Member has returned a DVD");

            // SCENARIO #3: MEMBER TRIES TO A RETURN A DVD THEY ARE NOT BORROWING (expecting false)
            if (!MemberFunctions.ReturnDVD(a, m)) Console.WriteLine("SCENARIO PASSED: Member tries to return a DVD they are not borrowing");
            else Console.WriteLine("SCENARIO FAILED: Member tries to return a DVD they are not borrowing");
            Records.Reset();
        }



        public static void TestDisplayCurrentBorrowings()
        {
            Console.WriteLine("\n======== DisplayCurrentBorrowings test plan ========");
            Records.Reset();

            // TEST DATA
            IMember m = new Member("johnny", "madman", "0411111111", "1234");

            IMovie a = new Movie("pirates", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie b = new Movie("arcane", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);

            Records.reg.Add(m);
            Records.lib.Insert(a);
            Records.lib.Insert(b);

            // SCENARIO #1: MEMBER NEVER BORROWED, BORROWINGS LIST EMPTY
            Console.WriteLine("SCENARIO: Member has never borrowed, displays default msg");
            Console.WriteLine($"EXPECTED:\nNo current borrowings...");
            Console.WriteLine("RESULT:");
            MemberFunctions.DisplayCurrentBorrowings(m);

            // SCENARIO #2: MEMBER BORROWS 2 MOVIES, BORROWINGS LIST CONTAINS BOTH MOVIES
            a.AddBorrower(m);
            b.AddBorrower(m);
            Console.WriteLine("\nSCENARIO: Member borrows 2 movies, display both in dictionary order");
            Console.WriteLine($"EXPECTED:\n({b.ToString()})\n({a.ToString()})");
            Console.WriteLine("RESULT:");
            MemberFunctions.DisplayCurrentBorrowings(m);

            // SCENARIO #3: MEMBER RETURNS 1 MOVIES, BORROWINGS LIST CONTAINS ONE MOVIE
            b.RemoveBorrower(m);
            Console.WriteLine("\nSCENARIO: Member returns 1 movies, no longer displays removed movie");
            Console.WriteLine($"EXPECTED:\n({a.ToString()})");
            Console.WriteLine("RESULT:");
            MemberFunctions.DisplayCurrentBorrowings(m);

            Records.Reset();
        }



        public static void TestTopThree()
        {
            Console.WriteLine("\n===== TopThree test plan =====");
            Records.Reset();

            // TEST DATA
            IMember m = new Member("johnny", "madman", "0411111111", "1234");

            IMovie a = new Movie("pirates", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie b = new Movie("arcane", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie c = new Movie("batman", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie d = new Movie("midsommar", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);

            Records.reg.Add(m);
            Records.lib.Insert(a);
            Records.lib.Insert(b);
            Records.lib.Insert(c);
            Records.lib.Insert(d);

            // SCENARIO #1: NO MOVIES EXIST/BORROWED
            Console.WriteLine("SCENARIO: No movies borrowed, all 3 ranks are null");
            Console.WriteLine($"EXPECTED:\n1. nil\n2. nil\n3. nil");
            Console.WriteLine("RESULT:");
            MemberFunctions.TopThree(Records.lib.ToArray());

            // SCENARIO #2: 1 MOVIE HAS BEEN BORROWED
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);

            Console.WriteLine("\nSCENARIO: 1 movie borrowed ranked 1st, the rest null");
            Console.WriteLine($"EXPECTED:\n1. {a.Title} borrowed {a.NoBorrowings}x\n2. nil\n3. nil");
            Console.WriteLine("RESULT:");
            MemberFunctions.TopThree(Records.lib.ToArray());

            //// SCENARIO #3: 2 MOVIES HAVE BEEN BORROWED
            b.AddBorrower(m);
            b.RemoveBorrower(m);
            b.AddBorrower(m);

            Console.WriteLine("\nSCENARIO: 2 movies borrowed ranked 1st and 2nd with 3rd null");
            Console.WriteLine($"EXPECTED:\n1. {a.Title} borrowed {a.NoBorrowings}x\n" +
                $"2. {b.Title} borrowed {b.NoBorrowings}x\n3. nil");
            Console.WriteLine("RESULT:");
            MemberFunctions.TopThree(Records.lib.ToArray());

            //// SCENARIO #4: 3+ MOVIES HAVE BEEN BORROWED
            c.AddBorrower(m);
            d.AddBorrower(m);

            Console.WriteLine("\nSCENARIO: 3+ movies borrowed and only top 3 are ranked accordingly");
            Console.WriteLine($"EXPECTED:\n1. {a.Title} borrowed {a.NoBorrowings}x\n" +
                $"2. {b.Title} borrowed {b.NoBorrowings}x\n" +
                $"3. {c.Title} borrowed {c.NoBorrowings}x");
            Console.WriteLine("RESULT:");
            MemberFunctions.TopThree(Records.lib.ToArray());

            //// SCENARIO #5: 3 MOVIES HAVE BEEN BORROWED FOR THE SAME AMOUNT
            b.RemoveBorrower(m);
            b.AddBorrower(m);
            c.RemoveBorrower(m);
            c.AddBorrower(m);
            c.RemoveBorrower(m);
            c.AddBorrower(m);

            Console.WriteLine("\nSCENARIO: 3 movies borrowed for the same amount, ranked in dictionary order");
            Console.WriteLine($"EXPECTED:\n1. {b.Title} borrowed {b.NoBorrowings}x\n" +
                $"2. {c.Title} borrowed {c.NoBorrowings}x\n" +
                $"3. {a.Title} borrowed {a.NoBorrowings}x");
            Console.WriteLine("RESULT:");
            MemberFunctions.TopThree(Records.lib.ToArray());

            Records.Reset();
        }
    }
}

