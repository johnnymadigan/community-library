// MEMBER FUNCTIONS
// Functions used by registered members (called only from MemberMenu)
// Seperates display/user-input from key functionality
// All methods are public for corresponding test plan (TestMemberFunctions)
// All methods utilise ADT interfaces
using System;
using System.Collections.Generic;

namespace CommunityLibrary
{
	public class MemberFunctions
	{
		// OPTION 1 ===========================================================
		// Get information about all movies in dictionary order (via titles) and include current available copies
		// Pre-condition: Nil
		// Post-condition: Return information on all movies in dictionary order, in string format
		public static string DisplayAllMovies()
		{
			IMovie[] movies = Records.lib.ToArray();
			string s = "";

			// Each movie contains title, genre, classification, duration, and available copies
			foreach (IMovie m in movies) s += $"({m.ToString()})\n";

			return s; // string will be empty if there were no movies
		}



		// OPTION 2 ===========================================================
		// Get information on a specific movies given the title
		// Pre-condition: Nil
		// Post-condition: Return information on a specfic movies given the title
		public static string DisplayMovieInfo(string title)
		{
			IMovie movieRef = Records.lib.Search(title); // Get reference to the movie object

			if (movieRef == null) throw new CustomException($"({title}) does not exist");
			else return movieRef.ToString(); // Return movie's title, genre, classification, duration, and available copies
		}



		// OPTION 3 ===========================================================
		// Allow a registered member to borrow a DVD
		// Pre-condition: Member is registered
		// Post-condition: Return true if member was added to the movie's borrowing list, otherwise return false or throw exceptions
		public static bool BorrowDVD(IMovie movie, IMember member)
		{
			IMovie movieRef = Records.lib.Search(movie.Title); // get reference to the movie obj from records
			List<IMovie> borrowings = new List<IMovie>(); // Get member's borrowings

			// For each movie in the BST, if the member is currently borrowing (full name matches), add that movie to the list
			foreach (IMovie m in Records.lib.ToArray()) if (m.Borrowers.Search(member)) borrowings.Add(m);

			// Use ADT methods to find specific reasons why function might fail, otherwise return TRUE if successful
			if (borrowings.Count >= 5) throw new CustomException("You are at the max borrowing limit (5)");
			else if (movieRef == null) throw new CustomException("Movie does not exist in library");
			else if (movieRef.Borrowers.Search(member)) throw new CustomException("You are already borrowing this movie");
			else if (movieRef.AvailableCopies == 0) throw new CustomException($"No more available copies");
			else return Records.lib.Search(movie.Title).AddBorrower(member); // false if at max borrowers (10)
		}



		// OPTION 4 ===========================================================
		// Allow a registered member to return a DVD
		// Pre-condition: Member is registered
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

