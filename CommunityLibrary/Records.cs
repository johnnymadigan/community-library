// RECORDS
// An accessible database comprising of registered members + movie library
// Only Staff/Member menu and function classes accesses these records
using System;
using System.Collections.Generic;

namespace CommunityLibrary
{
	public class Records
	{
		public static IMemberCollection reg;
		public static IMovieCollection lib;

		public static string staffUsername;
		public static string staffPassword;

		// Constructor with staff account username, password, and max # of registered members
		public Records(string sUsername, string sPassword, int memberSize)
		{
			lib = new MovieCollection();
			reg = new MemberCollection(memberSize);

			staffUsername = sUsername;
            staffPassword = sPassword;
		}
	}
}

