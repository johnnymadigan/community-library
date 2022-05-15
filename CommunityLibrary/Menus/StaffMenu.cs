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
			while (true)
			{
				Header();
				Console.WriteLine("Please login with a staff account");

				Console.Write("\nUsername: ");
				string username = Console.ReadLine();
				Console.Write("Password: ");
				string password = Console.ReadLine();

				// if authenticated, break from loop to go to sub-menu, otherwise try again/exit
				if (username.Equals(Records.staffUsername) && password.Equals(Records.staffPassword)) break;
				Console.Write("\nInvalid credentials...\nEnter any key to try again, enter 0 to return to main menu: ");
				if (Console.ReadLine().Equals("0")) return; // return to MAINMENU
			}

			DisplayStaffMenu();
		}

		private static void DisplayStaffMenu()
        {
			Header();
			Options();

			// loop so the user can select options...
			while (true)
			{
				string choice = Console.ReadLine();

				if (choice.Equals("1")) /* todo */;
				else if (choice.Equals("2")) /* todo */;
				else if (choice.Equals("3")) RegisterMember();
				else if (choice.Equals("4")) DeregisterMember();
				else if (choice.Equals("5")) /* todo */;
				else if (choice.Equals("6")) /* todo */;
				else if (choice.Equals("0")) return; // return to end of DISPLAYSTAFFLOGIN which then returns to MAINMENU

				Header();
				Options();

				if (!choice.Equals("1") && !choice.Equals("2") && !choice.Equals("3") && !choice.Equals("4") &&
					!choice.Equals("5") && !choice.Equals("6")) Console.Write("Invalid choice, please try again: ");
			}
		}

		// OPTION 3 USER INPUT/LOOP
		private static void RegisterMember()
        {
			while (true)
            {
				Header();

				Console.Write("First name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				Console.Write("Phone number: ");
				string phone = Console.ReadLine();
				while (!IMember.IsValidContactNumber(phone))
                {
					Console.Write("Invalid phone, please try again: ");
					phone = Console.ReadLine();
				}
				Console.Write("Pin: ");
				string pin = Console.ReadLine();
				while (!IMember.IsValidPin(pin))
				{
					Console.Write("Invalid pin, please try again: ");
					pin = Console.ReadLine();
				}

				Console.WriteLine($"\nNew member: {first} {last}, {phone}, {pin}");
				Console.Write("Enter any key to register this member, 0 to cancel: ");

				if (Console.ReadLine().Equals("0")) return;
				else
				{
					IMember m = new Member(first, last, phone, pin);
					IMovieCollection borrowing = new MovieCollection();
					StaffFunctions.RegisterMember(m, borrowing);
					break;
				}
			}
		}

		// OPTION 4 USER INPUT/LOOP
		private static void DeregisterMember()
		{
			while (true)
			{
				Header();

				// full names are unique, therefore do not worry about confirming phone
				Console.Write("First name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				Console.WriteLine($"\nQueried member: {first} {last}");
				Console.Write("Enter any key to deregister this member, 0 to cancel: ");

				if (Console.ReadLine().Equals("0")) return;
				else
				{
					IMember m = new Member(first, last);
					StaffFunctions.DeregisterMember(m);
					break;
				}
			}
		}

		
	}
}

