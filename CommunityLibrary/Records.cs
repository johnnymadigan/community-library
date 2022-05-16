using System;
using System.Collections.Generic;

namespace CommunityLibrary
{
	// accessible records
	public class Records
	{
		// Registered members (must be LIST as member collectiond does not allow access to pins...
        // Which means we are unable to verify login w the ADT
		public static List<IMember> reg;
		public static IMovieCollection lib;

		public static string staffUsername;
		public static string staffPassword;

		public Records(string sUsername, string sPassword)
		{
			lib = new MovieCollection();
			reg = new List<IMember>();

			staffUsername = sUsername;
            staffPassword = sPassword;
		}

		public static List<IMovie> GetMemberBorrowings(IMember m)
        {
			List<IMovie> borrowings = new List<IMovie>();

			// add all movies that are currently being borrowed by member to list
			foreach (IMovie movie in lib.ToArray()) if (movie.Borrowers.Search(m)) borrowings.Add(movie);
			return borrowings;
        }
	}
}

