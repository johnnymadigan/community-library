using System;
namespace CommunityLibrary
{
	public class StaffFunctions
	{
		// OPTION 1 FUNCTIONALITY (seperate + public for testing)
		public static bool AddDVD(IMovie m)
		{
			
			return Records.lib.Insert(m); // true if inserted into BST, false if dupe
		}

		// OPTION 2 FUNCTIONALITY (seperate + public for testing)
		public static bool RemoveDVD(IMovie m)
		{
			return Records.lib.Delete(m); // true if removed from BST, false if not found
		}

		// OPTION 3 FUNCTIONALITY (seperate + public for testing)
		public static bool RegisterMember(IMember m)
		{
			foreach (IMember k in Records.reg.Keys) if (k.CompareTo(m) == 0) return false; // return false if dupe

			if (!IMember.IsValidContactNumber(m.ContactNumber) || !IMember.IsValidPin(m.Pin)) return false; // false if contact/pin invalid
			else
			{
				Records.reg.Add(m, new MovieCollection());
				return true;
			}
		}

		// OPTION 4 FUNCTIONALITY (seperate + public for testing)
		public static bool DeregisterMember(IMember m)
		{
			foreach (IMember k in Records.reg.Keys)
			{
				if (k.CompareTo(m) == 0)
				{
					Records.reg.Remove(k);
					return true;
				}
			}
			return false;
		}
	}
}

