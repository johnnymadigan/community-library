// STAFF FUNCTIONS
// Functions used by the staff account (called only from StaffMenu)
// Seperates display/user-input from key functionality
// All methods are public for corresponding test plan (TestStaffFunctions)
// All methods utilise ADT interfaces
using System;
using System.Collections.Generic;

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
		// Post-condition: Add (register) member, throw an exception if dupe or contact/pin invalid
		public static void RegisterMember(IMember m)
		{
			if (Records.reg.Search(m)) throw new CustomException($"({m.FirstName} {m.LastName}) already registered");

			if (!IMember.IsValidContactNumber(m.ContactNumber)) throw new CustomException("Invalid contact number");
			else if (!IMember.IsValidPin(m.Pin)) throw new CustomException("Invalid PIN");
			else Records.reg.Add(m);
		}



		// OPTION 4 ===========================================================
		// Remove a registered member from the system
		// Pre-condition: Member is registered
		// Post-condition: Remove (deregister) member, throw an exception if not found or still borrowing
		public static void DeregisterMember(IMember member)
        {
			List<IMovie> borrowings = new List<IMovie>(); // Get member's borrowings

			// For each movie in the BST, if the member is currently borrowing (full name matches), add that movie to the list
			foreach (IMovie m in Records.lib.ToArray()) if (m.Borrowers.Search(member)) borrowings.Add(m);

			if (Records.reg.Find(member) == null) throw new CustomException($"({member.FirstName} {member.LastName}) does not exist");
			else if (borrowings.Count > 0) throw new CustomException($"({member.FirstName} {member.LastName}) still borrowing DVDs");
			else Records.reg.Delete(member); // remove if registered			
		}



		// OPTION 5 ===========================================================
		public static void DisplayContactNumber()
        {
			/* todo */
		}



		// OPTION 6 ===========================================================
		public static void DisplayMovieBorrowers()
		{
			/* todo */
		}
	}
}

