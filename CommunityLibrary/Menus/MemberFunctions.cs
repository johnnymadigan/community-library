using System;

namespace CommunityLibrary
{
	public class MemberFunctions
	{
		// OPTION 3 FUNCTIONALITY (seperate + public for testing)
		public static bool BorrowDVD(IMovie movie, IMember m)
		{
			// If member is not at borrowing limit (5 movies) and movie exists in library...
            // Attempt to add (fails if already borrowing, at max borrowers (10), or no available copies)
			if (Records.GetMemberBorrowings(m).Count <= 5 && Records.lib.Search(movie))
				return Records.lib.Search(movie.Title).AddBorrower(m);
			else return false;
		}
	}
}

