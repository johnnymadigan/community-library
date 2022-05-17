// MEMBER SUB-MENU
// All display/user-inputs for the sub-menu and each option
// Options utilise corresponding functions (see MemberFunctions)
using System;

namespace CommunityLibrary
{
	public class MemberMenu
	{
		// STORE LOGGED IN MEMBER FOR SESSION ONLY (set to null when exiting with "0" from menu)
		public static IMember loggedInMember;

		// Reproducable header (clears console)
		private static void Header()
        {
			Console.Clear();
			Console.Write("===================================================================\n" +
				"Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n=============================Member Menu===========================\n\n");
		}

		// Reproducable options
		private static void Options()
        {
			Console.WriteLine("1. Browse all the movies");
			Console.WriteLine("2. Display all the information about a movie, given the title of the movie");
			Console.WriteLine("3. Borrow a movie DVD");
			Console.WriteLine("4. Return a movie DVD");
			Console.WriteLine("5. List current borrowing movies");
			Console.WriteLine("6. Display the top 3 movies rented by the members");
			Console.WriteLine("0. Return to the main menu");

			Console.Write("\nEnter your choice ==> (1/2/3/4/5/6/0): ");
		}

		public static void DisplayMemberLogin()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please login with a registered member account...");

				Console.Write("\nFirst name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();
				Console.Write("Password (pin): ");
				string password = Console.ReadLine();

				// if authenticated, break from loop to go to sub-menu, otherwise try again/exit
				bool authenticated = false;
				foreach (IMember member in Records.reg)
				{
					if (member.FirstName == first && member.LastName == last && member.Pin == password)
					{
						loggedInMember = member;
						authenticated = true;
						break;
					}
				}
				if (authenticated) break;
				Console.Write("\nInvalid credentials...\nEnter any key to try again, enter 0 to return to main menu: ");
				if (Console.ReadLine().Equals("0")) return; // return to MAINMENU
			}
			DisplayMemberMenu();
		}

		private static void DisplayMemberMenu()
        {
			Header();
			Options();

			// loop so the user can select options...
			while (true)
			{
				string choice = Console.ReadLine();

				if (choice.Equals("1")) /* todo */;
				else if (choice.Equals("2")) /* todo */;
				else if (choice.Equals("3")) BorrowDVD();
				else if (choice.Equals("4")) /* todo */;
				else if (choice.Equals("5")) /* todo */;
				else if (choice.Equals("6")) /* todo */;
				else if (choice.Equals("0"))
				{
					loggedInMember = null;
					return; // return to end of DISPLAYMEMBERLOGIN which then returns to MAINMENU
				}

				Header();
				Options();

				if (!choice.Equals("1") && !choice.Equals("2") && !choice.Equals("3") && !choice.Equals("4") &&
					!choice.Equals("5") && !choice.Equals("6")) Console.Write("Invalid choice, please try again: ");

			}
		}

		// OPTION 3 USER INPUT/LOOP
		private static void BorrowDVD()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for movie to borrow...");

				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				// confirm action
				Console.WriteLine($"\nMovie: {t}");
				Console.Write("Enter any key to borrow this movie, 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;

				IMovie m = new Movie(t);

				if (MemberFunctions.BorrowDVD(m, loggedInMember))
				{
					Console.Write($"\nBorrowed {t}...\nEnter any key to continue: ");
					Console.ReadLine();
					return;
				}
				else
				{
					Console.Write($"\nFailed to borrow {t}, already borrowing, no available copies, at max borrowers, or movie not found...\nEnter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}
	}
}

