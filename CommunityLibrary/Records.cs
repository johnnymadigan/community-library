using System;
using System.Collections.Generic;

namespace CommunityLibrary
{
	// accessible records
	public class Records
	{
		public static IMovieCollection lib;						 // community library
		public static Dictionary<IMember, IMovieCollection> reg; // registered members
		public static string staffUsername;
		public static string staffPassword;

		public Records(string sUsername, string sPassword)
		{
			lib = new MovieCollection();
			reg = new Dictionary<IMember, IMovieCollection>();
			staffUsername = sUsername;
            staffPassword = sPassword;
		}
	}
}

