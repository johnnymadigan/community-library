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

		// HEADER
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

		// OPTIONS
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

		// LOGIN
		// Display member login page to get user input and verify credentials
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
				if (Console.ReadLine().Equals("0")) return; // return to MAIN MENU
			}
			DisplayMemberMenu();
		}

		// SUB-MENU
		// Display member sub-menu and await user's choice
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
					return; // return to end of DISPLAY MEMBER LOGIN which then returns to MAIN MENU
				}

				Header();
				Options();

				if (!choice.Equals("1") && !choice.Equals("2") && !choice.Equals("3") && !choice.Equals("4") &&
					!choice.Equals("5") && !choice.Equals("6")) Console.Write("Invalid choice, please try again: ");

			}
		}

		// OPTION 1
		// todo

		// OPTION 2
		// todo

		// OPTION 3
		// Get user input to add this logged-in registered member to the movie's borrowers list
		private static void BorrowDVD()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for movie to borrow...");

				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				// SCENARIO 1: movie exists, perform function
				if (Records.lib.Search(new Movie(t)))
                {
					// Boilerplate to confirm action
					Console.Write($"\nEnter any key to borrow {t}, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;

					IMovie m = new Movie(t);

					if (MemberFunctions.BorrowDVD(m, loggedInMember))
					{
						Console.Write($"\nBorrowed {t}, enter any key to continue: ");
						Console.ReadLine();
						return;
					}
					else
					{
						Console.Write($"\nFailed to borrow {t}, already borrowing, no available copies, or at max borrowers, enter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
				}
				// SCENARIO 2: movie does not exist, try again
				else
				{
					Console.Write($"\n{t} does not exist in library, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		// OPTION 4
		// todo

		// OPTION 5
		// todo

		// OPTION 6
		// todo
	}
}

