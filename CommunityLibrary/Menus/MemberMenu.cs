using System;

namespace CommunityLibrary
{
	public class MemberMenu
	{
		// LOGGED IN MEMBER FOR SESSION ONLY
		public static IMember loggedInMember;
		
		private static void Header()
        {
			Console.Clear();
			Console.Write("===================================================================\n" +
				"Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n=============================Member Menu===========================\n\n");
		}

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

				Console.Write("\nUsername (first last): ");
				string username = Console.ReadLine();
				Console.Write("Password (pin): ");
				string password = Console.ReadLine();

				// if authenticated, break from loop to go to sub-menu, otherwise try again/exit
				bool authenticated = false;
				foreach (IMember k in Records.reg.Keys)
				{
					if ($"{k.FirstName} {k.LastName}" == username && k.Pin == password)
					{
						loggedInMember = k;
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
				else if (choice.Equals("3")) /* todo */;
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
	}
}

