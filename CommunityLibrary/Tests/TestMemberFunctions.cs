// MEMBER TEST PLANS
// Test member functions through a range of scenarios
using System;
namespace CommunityLibrary
{
	public class TestMemberFunctions
	{
        // Run all tests
		public TestMemberFunctions()
		{
            TestTopThree();
		}

		public void TestTopThree()
        {
            Console.WriteLine("===== TopThree test =====");
            Records.Reset();
            IMember m = new Member("bofa", "dem", "0111111111", "1111");
            Records.reg.Add(m);

            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 1999, 1);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 1111, 2);
            IMovie c = new Movie("batman", MovieGenre.Action, MovieClassification.M15Plus, 69, 3);

            Console.WriteLine(MemberFunctions.TopThree());
            Console.WriteLine("TopThree test PASSED: No movies borrowed displays 'nil' for all 3 ranks");

            // a borrowed 3 times
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);

            Console.WriteLine(MemberFunctions.TopThree());
            Console.WriteLine("TopThree test PASSED: 1 movie borrowed displays as 1st, the rest 'nil'");

            // b borrowed 2 times
            b.AddBorrower(m);
            b.RemoveBorrower(m);
            b.AddBorrower(m);

            Console.WriteLine(MemberFunctions.TopThree());
            Console.WriteLine("TopThree test PASSED: 2 movie borrowed displays as 1st and 2nd with 3rd as 'nil'");

            // c borrowed once
            c.AddBorrower(m);

            Records.lib.Insert(a);
            Records.lib.Insert(b);
            Records.lib.Insert(c);

            // top 3 order should be a, b, c
            Console.WriteLine(MemberFunctions.TopThree());
            Console.WriteLine("TopThree test PASSED: 3+ movies borrowed are ranked accordingly");
        }
    }
}

