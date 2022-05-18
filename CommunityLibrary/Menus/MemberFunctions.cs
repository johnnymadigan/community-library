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
		/* todo */

		// OPTION 2 ===========================================================
		/* todo */

		// OPTION 3 ===========================================================
		// Allow a registered member to borrow a DVD
		// Pre-condition: Movie and member exist in records
		// Post-condition: Return true if member was added to the movie's borrowing list, false otherwise
		public static bool BorrowDVD(IMovie movie, IMember m)
		{
			// If member is not at borrowing limit (5 movies), and movie exists in records...
			// attempt to add (fails if already borrowing, at max borrowers (10), or no available copies)
			if (Records.GetMemberBorrowings(m).Count < 5 && Records.lib.Search(movie))
				return Records.lib.Search(movie.Title).AddBorrower(m);
			else return false;
		}

		// OPTION 4 ===========================================================
		// Allow a registered member to return a DVD
		// Pre-condition: Movie and member exist in records, member currently in movie's borrowing collection
		// Post-condition: Return true if member was borrowing and now no longer, false otherwise
		public static bool ReturnDVD(IMovie movie, IMember m)
		{
			if (Records.lib.Search(movie))
            {
				// return true if removed, false otherwise
				return Records.lib.Search(movie.Title).RemoveBorrower(m);
			}
			else return false;
		}

		// OPTION 5 ===========================================================
		/* todo */

		// OPTION 6 ===========================================================
		/* todo */
	}
}

