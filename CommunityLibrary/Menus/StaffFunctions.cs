using System;
namespace CommunityLibrary
{
	public class StaffFunctions
	{
		// OPTION 1 FUNCTIONALITY (seperate + public for testing)
		public static bool AddDVD(string t, MovieGenre g, MovieClassification c, int d, int n)
		{
			IMovie m = new Movie(t, g, c, d, n);
			return Records.lib.Insert(m); // true if inserted into BST, false if dupe
		}

		// OPTION 2 FUNCTIONALITY (seperate + public for testing)
		public static bool RemoveDVD(string t)
		{
			IMovie m = new Movie(t);
			return Records.lib.Delete(m); // true if removed from BST, false if not found
		}

		// OPTION 3 FUNCTIONALITY (seperate + public for testing)
		public static bool RegisterMember(string first, string last, string phone, string pin)
		{
			if (!IMember.IsValidContactNumber(phone) || !IMember.IsValidPin(pin)) return false;
			else
			{
				IMember m = new Member(first, last, phone, pin);
				IMovieCollection borrowing = new MovieCollection();
				Records.reg.Add(m, borrowing);
				return true;
			}
		}

		// OPTION 4 FUNCTIONALITY (seperate + public for testing)
		public static bool DeregisterMember(string first, string last)
		{
			foreach (IMember k in Records.reg.Keys)
			{
				if (k.FirstName == first && k.LastName == last)
				{
					Records.reg.Remove(k);
					return true;
				}
			}
			return false;
		}
	}
}

