// STAFF FUNCTIONS
// Functions used by the staff account (called only from StaffMenu)
// Seperates display/user-input from key functionality
// All methods are public for corresponding test plan (TestStaffFunctions)
// All methods utilise ADT interfaces
using System;

namespace CommunityLibrary
{
	public class StaffFunctions
	{
		// OPTION 1 ===========================================================
		// Add new DVDs of a movie to the system (NEW MOVIE)
		// Pre-condition: Nil
		// Post-condition: Return true if movie is new and therefore inserted, false otherwise (prevents duplicates)
		public static bool AddDVD(IMovie m)
		{
			return Records.lib.Insert(m);
		}

		// OPTION 1 ===========================================================
		// Add new DVDs of a movie to the system (EXISTING MOVIE)
		// Pre-condition: Nil
		// Post-condition: Increment total/available copies and return the new total copies of the movie
		public static int AddDVD(string title)
		{
			IMovie movieRef = Records.lib.Search(title); // get reference to the movie obj from records

			if (movieRef == null) throw new CustomException("Movie does not exist in library");
			else
			{
				movieRef.TotalCopies++;
				movieRef.AvailableCopies++;
				return movieRef.TotalCopies;
			}
		}



		// OPTION 2 ===========================================================
		// Remove DVDs of a movie from the system
		// Pre-condition: nil
		// Post-condition: Decrement total/available copies and return the new total or -1 if the movie has been deleted
		public static int RemoveDVD(string title)
		{
			IMovie movieRef = Records.lib.Search(title); // get reference to the movie obj from records

			if (movieRef == null) throw new CustomException("Movie does not exist in library");
			else if (movieRef.AvailableCopies <= 0) throw new CustomException("Members borrowing all remaining DVDs, please return first");
			else
            {
				movieRef.TotalCopies--;
				movieRef.AvailableCopies--;

				// delete from library if no more copies, otherwise return the new total
				if (movieRef.TotalCopies <= 0)
				{
					Records.lib.Delete(movieRef); 
					return -1;
				}
				else return movieRef.TotalCopies;
			}
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
		// Pre-condition: Member is registered
		// Post-condition: Return true if member is removed, false if not registered yet or currently borrowing a movie
		public static bool DeregisterMember(IMember m)
		{
			foreach (IMember member in Records.reg)
			{
				if (member.CompareTo(m) == 0)
				{
					// Seperate IF statement as once the unique registered member is found...
					// return false immediately if they are borrowing 1+ DVDs
					if (Records.GetMemberBorrowings(member).Count > 0) return false;
					else
					{
						Records.reg.Remove(member);
						return true;
					}
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

