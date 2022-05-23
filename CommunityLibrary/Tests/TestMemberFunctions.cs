// MEMBER TEST PLANS
// Test member functions through a range of scenarios
using System;
namespace CommunityLibrary
{
	public class TestMemberFunctions
	{
		public static void RunAllTests()
		{
            TestDisplayCurrentBorrowings();
            TestTopThree();
		}

        public static void TestDisplayCurrentBorrowings()
        {
            Console.WriteLine("\n===== DisplayCurrentBorrowings test plan =====");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 1999, 1);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 1111, 2);
            IMember m = new Member("bofa", "dem", "0111111111", "1111");
            Records.reg.Add(m);
            Records.lib.Insert(a);
            Records.lib.Insert(b);

            // SCENARIO #1: MEMBER NEVER BORROWED, BORROWINGS EMPTY

            IMovie[] ranking = MemberFunctions.TopThree();
            if (ranking[0] == null && ranking[1] == null && ranking[2] == null)
                Console.WriteLine("TopThree test PASSED: No movies borrowed, all 3 ranks are null");
            else Console.WriteLine("TopThree test FAILED: No movies borrowed, all 3 ranks are null");

            // SCENARIO #2: MEMBER BORROWS 2 MOVIES, BORROWINGS UPDATED

            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);

            ranking = MemberFunctions.TopThree();
            if (ranking[0].Title.Equals(a.Title) && ranking[1] == null && ranking[2] == null)
                Console.WriteLine("TopThree test PASSED: 1 movie borrowed ranked 1st, the rest null");
            else Console.WriteLine("TopThree test FAILED: 1 movie borrowed ranked 1st, the rest null");

            // SCENARIO #3: MEMBER RETURNS 1 MOVIES, BORROWINGS UPDATED

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

        public static void TestTopThree()
        {
            Console.WriteLine("\n===== TopThree test plan =====");
            Records.Reset();

            // TEST DATA
            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 1999, 1);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 1111, 2);
            IMovie c = new Movie("batman", MovieGenre.Action, MovieClassification.M15Plus, 69, 3);
            IMovie d = new Movie("midsommar", MovieGenre.Action, MovieClassification.M15Plus, 69, 3);
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

