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
            Console.WriteLine("\n===== DisplayAllMovies test plan =====");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            

            // SCENARIO #1: LIBRARY EMPTY, NO MOVIES TO DISPLAY
            string result = MemberFunctions.DisplayAllMovies();
            if (result.Equals(""))
                Console.WriteLine("DisplayAllMovies test PASSED: Library empty, no movies to display");
            else Console.WriteLine("DisplayAllMovies test FAILED: Library empty, no movies to display");

            // SCENARIO #2: ADDED 2 MOVIES, DISPLAYS BOTH
            Records.lib.Insert(a);
            Records.lib.Insert(b);

            result = MemberFunctions.DisplayAllMovies();
            if (result.Contains(a.Title) && result.Contains(b.Title))
                Console.WriteLine("DisplayAllMovies test PASSED: Added 2 movies, displays both");
            else Console.WriteLine("DisplayAllMovies test FAILED: Added 2 movies, displays both");

            // SCENARIO #3: REMOVED 1 EXISTING MOVIE, DOES NOT DISPLAY REMOVED MOVIE
            Records.lib.Delete(b);

            result = MemberFunctions.DisplayAllMovies();
            if (result.Contains(a.Title) && !result.Contains(b.Title))
                Console.WriteLine("DisplayAllMovies test PASSED: Removed 1 existing movie, does not display removed movie");
            else Console.WriteLine("DisplayAllMovies test FAILED: Removed 1 existing movie, does not display removed movie");
        }



        public static void TestDisplayMovieInfo()
        {
            Console.WriteLine("\n===== DisplayMovieInfo test plan =====");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);

            // SCENARIO #1: MOVIE DOES NOT EXIST (expecting to catch exception)
            try
            {
                MemberFunctions.DisplayMovieInfo("dummy");
                Console.WriteLine("DisplayMovieInfo test FAILED: Movie does not exist");
            }
            catch (CustomException)
            {
                Console.WriteLine("DisplayMovieInfo test PASSED: Movie does not exist");
            }

            // SCENARIO #2: MOVIE EXISTS, DISPLAYS ALL INFO
            Records.lib.Insert(a);
            if (a.ToString().Equals(MemberFunctions.DisplayMovieInfo(a.Title)))
                Console.WriteLine("DisplayMovieInfo test PASSED: Movie exists, displays all info");
            else Console.WriteLine("DisplayMovieInfo test FAILED: Movie exists, displays all info");

            // SCENARIO #3: MOVIE NO LONGER EXISTS (expecting to catch exception)
            try
            {
                Records.lib.Delete(a);
                MemberFunctions.DisplayMovieInfo(a.Title);
                Console.WriteLine("DisplayMovieInfo test FAILED: Movie removed and now no longer displays info");
            }
            catch (CustomException)
            {
                Console.WriteLine("DisplayMovieInfo test PASSED: Movie removed and now no longer displays info");
            }
        }



        public static void TestBorrowDVD()
        {
            Console.WriteLine("\n===== BorrowDVD test plan =====");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
            IMovie c = new Movie("batman", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
            IMovie d = new Movie("midsommar", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
            IMovie e = new Movie("evangelion", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
            IMovie f = new Movie("love+death+robots", MovieGenre.Action, MovieClassification.M15Plus, 100, 1); // 6th movie to attempt borrowing 5+
            IMovie g = new Movie("shrek", MovieGenre.Action, MovieClassification.M15Plus, 100, 0); // no available copies
            IMovie h = new Movie("cowboybebop", MovieGenre.Action, MovieClassification.M15Plus, 100, 20); // movie already borrowed by 10 members

            for (int i = 0; i < 10; i++) h.AddBorrower(new Member($"{i}", $"{i}")); // fill movie up to max borrowers limit (10)

            IMember m = new Member("bofa", "dem", "0111111111", "1111");
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
                Console.WriteLine("BorrowDVD test FAILED: Member tries to borrow a movie that does not exist");
            }
            catch (CustomException)
            {
                Console.WriteLine("BorrowDVD test PASSED: Member tries to borrow a movie that does not exist");
            }

            // SCENARIO #2: MEMBER HAS BORROWED A DVD (expecting true)
            if (MemberFunctions.BorrowDVD(a, m)) Console.WriteLine("BorrowDVD test PASSED: Member has borrowed a DVD");
            else Console.WriteLine("BorrowDVD test FAILED: Member has borrowed a DVD");

            // SCENARIO #3: MEMBER TRIES TO BORROW A MOVIE TWICE (expecting to catch exception)
            try
            {
                MemberFunctions.BorrowDVD(a, m);
                Console.WriteLine("BorrowDVD test FAILED: Member tries to borrow a movie twice");
            }
            catch (CustomException)
            {
                Console.WriteLine("BorrowDVD test PASSED: Member tries to borrow a movie twice");
            }

            // SCENARIO #4: MEMBER TRIES TO BORROW A MOVIE W NO AVAILABLE COPIES (expecting to catch exception)
            try
            {
                MemberFunctions.BorrowDVD(g, m);
                Console.WriteLine("BorrowDVD test FAILED: Member tries to borrow a movie w no available copies");
            }
            catch (CustomException)
            {
                Console.WriteLine("BorrowDVD test PASSED: Member tries to borrow a movie w no available copies");
            }

            // SCENARIO #5: MEMBER TRIES TO BORROW A MOVIE HOWEVER MOVIE AT MAX BORROWERS (10) (expecting false)
            if (!MemberFunctions.BorrowDVD(h, m)) Console.WriteLine("BorrowDVD test PASSED: Member tries to borrow a movie however movie at max borrowers (10)");
            else Console.WriteLine("BorrowDVD test FAILED: Member tries to borrow a movie however movie at max borrowers (10)");

            // SCENARIO #6: MEMBER TRIES TO BORROW PAST BORROWING LIMIT (5) (expecting to catch exception)
            MemberFunctions.BorrowDVD(b, m);
            MemberFunctions.BorrowDVD(c, m);
            MemberFunctions.BorrowDVD(d, m);
            MemberFunctions.BorrowDVD(e, m);

            try
            {
                MemberFunctions.BorrowDVD(f, m);
                Console.WriteLine("BorrowDVD test FAILED: Member tries to borrow past borrowing limit (5)");
            }
            catch (CustomException)
            {
                Console.WriteLine("BorrowDVD test PASSED: Member tries to borrow past borrowing limit (5)");
            }
        }



        public static void TestReturnDVD()
        {
            Console.WriteLine("\n===== ReturnDVD test plan =====");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
            IMember m = new Member("bofa", "dem", "0111111111", "1111");
            Records.reg.Add(m);
            Records.lib.Insert(a);

            // SCENARIO #1: MEMBER TRIES TO RETURN A MOVIE THAT DOES NOT EXIST (expecting to catch exception)
            try
            {
                MemberFunctions.ReturnDVD(new Movie("dummy"), m);
                Console.WriteLine("ReturnDVD test FAILED: Member tries to return a movie that does not exist");
            }
            catch (CustomException)
            {
                Console.WriteLine("ReturnDVD test PASSED: Member tries to return a movie that does not exist");
            }

            // SCENARIO #2: MEMBER HAS RETURNED A DVD (expecting true)
            a.AddBorrower(m);
            if (MemberFunctions.ReturnDVD(a, m)) Console.WriteLine("ReturnDVD test PASSED: Member has returned a DVD");
            else Console.WriteLine("ReturnDVD test FAILED: Member has returned a DVD");

            // SCENARIO #3: MEMBER TRIES TO A RETURN A DVD THEY ARE NOT BORROWING (expecting false)
            if (!MemberFunctions.ReturnDVD(a, m)) Console.WriteLine("ReturnDVD test PASSED: Member tries to return a DVD they are not borrowing");
            else Console.WriteLine("ReturnDVD test FAILED: Member tries to return a DVD they are not borrowing");
        }



        public static void TestDisplayCurrentBorrowings()
        {
            Console.WriteLine("\n===== DisplayCurrentBorrowings test plan =====");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMember m = new Member("bofa", "dem", "0111111111", "1111");
            Records.reg.Add(m);
            Records.lib.Insert(a);
            Records.lib.Insert(b);

            // SCENARIO #1: MEMBER NEVER BORROWED, BORROWINGS LIST EMPTY

            string result = MemberFunctions.DisplayCurrentBorrowings(m);
            if (result.Equals(""))
                Console.WriteLine("DisplayCurrentBorrowings test PASSED: Member has never borrowed, no current borrowings");
            else Console.WriteLine("DisplayCurrentBorrowings test FAILED: Member has never borrowed, no current borrowings");

            // SCENARIO #2: MEMBER BORROWS 2 MOVIES, BORROWINGS LIST CONTAINS BOTH MOVIES

            a.AddBorrower(m);
            b.AddBorrower(m);

            result = MemberFunctions.DisplayCurrentBorrowings(m);
            if (result.Contains(a.Title) && result.Contains(b.Title))
                Console.WriteLine("DisplayCurrentBorrowings test PASSED: Member borrows 2 movies, borrowings contain both");
            else Console.WriteLine("DisplayCurrentBorrowings test FAILED: Member borrows 2 movies, borrowings contain both");

            // SCENARIO #3: MEMBER RETURNS 1 MOVIES, BORROWINGS LIST CONTAINS ONE MOVIE

            b.RemoveBorrower(m);

            result = MemberFunctions.DisplayCurrentBorrowings(m);
            if (result.Contains(a.Title) && !result.Contains(b.Title))
                Console.WriteLine("DisplayCurrentBorrowings test PASSED: Member returns 1 movies, borrowings no longer contains removed movie");
            else Console.WriteLine("DisplayCurrentBorrowings test FAILED: Member returns 1 movies, borrowings no longer contains removed movie");
        }



        public static void TestTopThree()
        {
            Console.WriteLine("\n===== TopThree test plan =====");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie c = new Movie("batman", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMovie d = new Movie("midsommar", MovieGenre.Action, MovieClassification.M15Plus, 100, 5);
            IMember m = new Member("bofa", "dem", "0111111111", "1111");
            Records.reg.Add(m);
            Records.lib.Insert(a);
            Records.lib.Insert(b);
            Records.lib.Insert(c);
            Records.lib.Insert(d);

            // SCENARIO #1: NO MOVIES EXIST/BORROWED
            IMovie[] ranking = MemberFunctions.TopThree();
            if (ranking[0] == null && ranking[1] == null && ranking[2] == null)
                Console.WriteLine("TopThree test PASSED: No movies borrowed, all 3 ranks are null");
            else Console.WriteLine("TopThree test FAILED: No movies borrowed, all 3 ranks are null");

            // SCENARIO #2: 1 MOVIE HAS BEEN BORROWED
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);

            ranking = MemberFunctions.TopThree();
            if (ranking[0].Title.Equals(a.Title) && ranking[1] == null && ranking[2] == null)
                Console.WriteLine("TopThree test PASSED: 1 movie borrowed ranked 1st, the rest null");
            else Console.WriteLine("TopThree test FAILED: 1 movie borrowed ranked 1st, the rest null");

            // SCENARIO #3: 2 MOVIES HAVE BEEN BORROWED
            b.AddBorrower(m);
            b.RemoveBorrower(m);
            b.AddBorrower(m);

            ranking = MemberFunctions.TopThree();
            if (ranking[0].Title.Equals(a.Title) && ranking[1].Title.Equals(b.Title) && ranking[2] == null)
                Console.WriteLine("TopThree test PASSED: 2 movies borrowed ranked 1st and 2nd with 3rd null");
            else Console.WriteLine("TopThree test FAILED: 2 movies borrowed ranked 1st and 2nd with 3rd null");

            // SCENARIO #4: 3+ MOVIES HAVE BEEN BORROWED
            c.AddBorrower(m);
            d.AddBorrower(m);

            ranking = MemberFunctions.TopThree();
            if (ranking[0].Title.Equals(a.Title) && ranking[1].Title.Equals(b.Title) && ranking[2].Title.Equals(c.Title) && ranking.Length == 3)
                Console.WriteLine("TopThree test PASSED: 3+ movies borrowed and only top 3 are ranked accordingly");
            else Console.WriteLine("TopThree test FAILED: 3+ movies borrowed and only top 3 are ranked accordingly");

            // SCENARIO #5: 3 MOVIES HAVE BEEN BORROWED FOR THE SAME AMOUNT
            b.RemoveBorrower(m);
            b.AddBorrower(m);
            c.RemoveBorrower(m);
            c.AddBorrower(m);
            c.RemoveBorrower(m);
            c.AddBorrower(m);

            ranking = MemberFunctions.TopThree();
            if (ranking[0].Title.Equals(c.Title) && ranking[1].Title.Equals(b.Title) && ranking[2].Title.Equals(a.Title))
                Console.WriteLine("TopThree test PASSED: 3 movies borrowed for the same amount, ranked in dictionary order");
            else Console.WriteLine("TopThree test FAILED: 3 movies borrowed for the same amount, ranked in dictionary order");
        }
    }
}

