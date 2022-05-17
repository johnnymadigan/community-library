// MEMBER FUNCTIONS
// Functions used by registered members (called only from MemberMenu)
// Seperates display/user-input from key functionality
// All methods are public for corresponding test plan (TestMemberFunctions)
using System;

namespace CommunityLibrary
{
	public class MemberFunctions
	{
		// OPTION 1 ===========================================================

		// OPTION 2 ===========================================================

		// OPTION 3 ===========================================================
		// Borrow a movie DVD
		// Pre-condition: The member registered
		// Post-condition: Return true if member is added to the movie's borrowers collection
		public static bool BorrowDVD(IMovie movie, IMember m)
		{
			// If member is not at borrowing limit (5 movies), and movie exists in library...
			// attempt to add (fails if already borrowing, at max borrowers (10), or no available copies)
			if (Records.GetMemberBorrowings(m).Count <= 5 && Records.lib.Search(movie))
				return Records.lib.Search(movie.Title).AddBorrower(m);
			else return false;
		}

		// OPTION 4 ===========================================================

		// OPTION 5 ===========================================================

		// OPTION 6 ===========================================================
	}
}

