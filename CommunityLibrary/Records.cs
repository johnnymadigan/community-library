// RECORDS
// An accessible database comprising of registered members + movie library
// Only Staff/Member menu and function classes accesses these records
using System;
using System.Collections.Generic;

namespace CommunityLibrary
{
	public class Records
	{
		// Registered members stored in a LIST as MEMBERCOLLECTION does not allow access to pins...
        // Which means we are unable to verify login w that ADT
		public static IMemberCollection reg;
		public static IMovieCollection lib;

		public static string staffUsername;
		public static string staffPassword;

		// Constructor with staff account username + password
		public Records(string sUsername, string sPassword, int memberSize)
		{
			lib = new MovieCollection();
			reg = new MemberCollection(memberSize);

			staffUsername = sUsername;
            staffPassword = sPassword;
		}

		// Creates a list of all movies that a registered member is currently borrowing
		// Pre-condition: nil
		// Post-condition: Return list of movies the queried member is currently borrowing
		public static List<IMovie> GetMemberBorrowings(IMember m)
        {
			List<IMovie> borrowings = new List<IMovie>();

			// For each movie in the BST, if the member is currently borrowing (full name matches), add that movie to the list
			foreach (IMovie movie in lib.ToArray()) if (movie.Borrowers.Search(m)) borrowings.Add(movie);
			return borrowings;
        }
	}
}

