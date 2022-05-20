// MEMBER FUNCTIONS
// Functions used by registered members (called only from MemberMenu)
// Seperates display/user-input from key functionality
// All methods are public for corresponding test plan (TestMemberFunctions)
// All methods utilise ADT interfaces
using System;

namespace CommunityLibrary
{
	public class MemberFunctions
	{
		// OPTION 1 ===========================================================
		private static void DisplayAllMovies()
		{
			/* todo */
		}



		// OPTION 2 ===========================================================
		private static void DisplayMovieInfo()
		{
			/* todo */
		}



		// OPTION 3 ===========================================================
		// Allow a registered member to borrow a DVD
		// Pre-condition: Member is already registered and exists in records
		// Post-condition: Return true if member was added to the movie's borrowing list, otherwise return false or throw exceptions
		public static bool BorrowDVD(IMovie movie, IMember member)
		{
			IMovie movieRef = Records.lib.Search(movie.Title); // get reference to the movie obj from records

			// Use ADT methods to find specific reasons why function might fail, otherwise return TRUE if successful
			if (Records.GetMemberBorrowings(member).Count >= 5) throw new CustomException("You are at the max borrowing limit (5)");
			else if (movieRef == null) throw new CustomException("Movie does not exist in library");
			else if (movieRef.Borrowers.Search(member)) throw new CustomException("You are already borrowing this movie");
			else if (movieRef.AvailableCopies == 0) throw new CustomException($"No more available copies");
			else return Records.lib.Search(movie.Title).AddBorrower(member); // false if at max borrowers (10)
		}



		// OPTION 4 ===========================================================
		// Allow a registered member to return a DVD
		// Pre-condition: Member is already registered and exists in records
		// Post-condition: Return true if member was borrowing and now no longer, otherwise return false or throw exceptions
		public static bool ReturnDVD(IMovie movie, IMember member)
		{
			IMovie movieRef = Records.lib.Search(movie.Title); // get reference to the movie obj from records

			// Use ADT methods to find specific reasons why function might fail, otherwise return TRUE if successful
			if (movieRef == null) throw new CustomException($"Movie does not exist in library");
			else return Records.lib.Search(movie.Title).RemoveBorrower(member); // false is member not borrowing
		}



		// OPTION 5 ===========================================================
		public static void DisplayCurrentBorrowings()
        {
			/* todo */
		}



		// OPTION 6 ===========================================================
		public static void TopThree()
		{
			/* todo */
		}
	}
}

