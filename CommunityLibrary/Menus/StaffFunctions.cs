// STAFF FUNCTIONS
// Functions used by the staff account (called only from StaffMenu)
// Seperates display/user-input from key functionality
// All methods are public for corresponding test plan (TestStaffFunctions)
using System;

namespace CommunityLibrary
{
	public class StaffFunctions
	{
		// OPTION 1 ===========================================================
		// Add new DVDs of a movie to the system (NEW MOVIE)
		// Pre-condition: Movie is new (library does not contain this movie)
		// Post-condition: Return true if movie is successfully inserted, false otherwise (prevents duplicates)
		public static bool AddDVD(IMovie m)
		{
			return Records.lib.Insert(m);
		}

		// OPTION 1 ===========================================================
		// Add new DVDs of a movie to the system (EXISTING MOVIE)
		// Pre-condition: Movie is not new (library contains this movie)
		// Post-condition: Increment and return total/available copies of the movie
		public static int AddDVD(string title)
		{
			IMovie movie = Records.lib.Search(title); ;

			if (movie != null)
			{
				movie.TotalCopies++;
				movie.AvailableCopies++;

				return movie.TotalCopies;
			}
			else return -1;
			
		}

		// OPTION 2 ===========================================================
		// Remove DVDs of a movie from the system
		// Pre-condition: nil
		// Post-condition: Decrement and return the total/available copies of the movie, otherwise -1 if movie does not exist
		public static int RemoveDVD(string title)
		{
			IMovie movie = Records.lib.Search(title); ;

			if (movie != null)
            {
				movie.TotalCopies--;
				movie.AvailableCopies--;

				if (movie.TotalCopies == 0) Records.lib.Delete(movie); // delete from library if no more copies

				return movie.TotalCopies--;
			}
			else return -1;
		}

		// OPTION 3 ===========================================================
		// Register a new member with the system
		// Pre-condition: nil
		// Post-condition: Return true if member is added (registered), false if dupe or contact/pin invalid
		public static bool RegisterMember(IMember m)
		{
			foreach (IMember member in Records.reg) if (member.CompareTo(m) == 0) return false; // false if dupe

			if (!IMember.IsValidContactNumber(m.ContactNumber) || !IMember.IsValidPin(m.Pin)) return false; // false if contact/pin invalid
			else
			{
				Records.reg.Add(m);
				return true;
			}
		}

		// OPTION 4 ===========================================================
		// Remove a registered member from the system
		// Pre-condition: nil
		// Post-condition: Return true if member is removed, false if not registered yet
		public static bool DeregisterMember(IMember m)
		{
			foreach (IMember member in Records.reg)
			{
				if (member.CompareTo(m) == 0)
				{
					Records.reg.Remove(member);
					return true;
				}
			}
			return false;
		}

		// OPTION 5 ===========================================================
		/* todo */

		// OPTION 6 ===========================================================
		/* todo */
	}
}

