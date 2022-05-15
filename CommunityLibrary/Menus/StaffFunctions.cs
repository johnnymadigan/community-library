using System;
namespace CommunityLibrary
{
	public class StaffFunctions
	{
		// OPTION 3 FUNCTIONALITY (seperate + public for testing)
		public static bool RegisterMember(IMember m, IMovieCollection borrowing)
		{
			Records.reg.Add(m, borrowing);
			return true;
		}

		// OPTION 4 FUNCTIONALITY (seperate + public for testing)
		public static bool DeregisterMember(IMember m)
		{
			foreach (IMember k in Records.reg.Keys)
			{
				if (k.FirstName == m.FirstName && k.LastName == m.LastName)
				{
					Records.reg.Remove(k);
					return true;
				}
			}
			return false;
		}
	}
}

