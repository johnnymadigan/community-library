using System;

namespace CommunityLibrary
{
	public class StaffMenu
	{
		private static void Header()
		{
			Console.Clear();
			Console.Write("===================================================================\n" +
				"Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n=============================Staff Menu============================\n\n");
		}

		private static void Options()
		{
			Console.WriteLine("1. Add new DVDs of a new movie to the system");
			Console.WriteLine("2. Remove DVDs of a movie from the system");
			Console.WriteLine("3. Register a new member with the system");
			Console.WriteLine("4. Remove a registered member from the system");
			Console.WriteLine("5. Display a member's contact phone number, given the member's name");
			Console.WriteLine("6. Display all members who are currently renting a particular movie");
			Console.WriteLine("0. Return to the main menu");

			Console.Write("\nEnter your choice ==> (1/2/3/4/5/6/0): ");
		}

		public static void DisplayStaffLogin()
		{
			Header();
			Console.WriteLine("Please login with a staff account");

			bool auth = false;
			string username;
			string password;

			while (!auth)
			{
				Console.Write("\nUsername: ");
				username = Console.ReadLine();
				Console.Write("Password: ");
				password = Console.ReadLine();

				if (username.Equals("staff") && password.Equals("today123")) auth = true;
				else
				{
					Console.WriteLine("\nInvalid credentials...\n" +
					"Enter any key to try again, enter 0 to return to main menu\n");

					if (Console.ReadLine().Equals("0")) return; // return to MAINMENU
				}
			}

			DisplayStaffMenu();
		}

		private static void DisplayStaffMenu()
        {
			Header();
			Options();

			string choice = "";

			// loop so the user can select options...
            // if user selects to exit, break out of loop and return to end of DISPLAYSTAFFLOGIN which then returns to MAINMENU
			while (!choice.Equals("0"))
			{
				choice = Console.ReadLine();

				if (choice.Equals("1")) /* todo */;
				else if (choice.Equals("2")) /* todo */;
				else if (choice.Equals("3")) RegisterMember();
				else if (choice.Equals("4")) /* todo */;
				else if (choice.Equals("5")) /* todo */;
				else if (choice.Equals("6")) /* todo */;

				// when user completes action, display options again
				Header();
				Options();

				// additional line if user input was invalid
				if (!choice.Equals("1") && !choice.Equals("2") && !choice.Equals("3") && !choice.Equals("4") &&
				!choice.Equals("5") && !choice.Equals("6") && !choice.Equals("0")) Console.Write("Invalid choice, please try again: ");
			}
		}

		// OPTION 3
		private static void RegisterMember()
        {
			Header();

			Console.Write("First name: ");
			string first = Console.ReadLine();
			Console.Write("Last name: ");
			string last = Console.ReadLine();
			Console.Write("Phone number: ");
			string phone = Console.ReadLine();
			Console.Write("Pin: ");
			string pin = Console.ReadLine();

			Console.Write("Enter any key to register user, 0 to cancel: ");

			if (!Console.ReadLine().Equals("0"))
			{
				IMember m = new Member(first, last, phone, pin);
				IMovieCollection borrowing = new MovieCollection();
				Records.reg.Add(m, borrowing);
			}
		}
	}
}

