using System;
using System.Collections.Generic;

namespace CommunityLibrary
{
	// accessible records
	public class Records
	{
		public static IMovieCollection lib;						 // community library
		public static Dictionary<IMember, IMovieCollection> reg; // registered members

		public Records()
		{
			lib = new MovieCollection();
			reg = new Dictionary<IMember, IMovieCollection>();
		}
	}
}

