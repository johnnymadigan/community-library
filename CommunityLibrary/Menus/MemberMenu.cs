using System;
namespace CommunityLibrary
{
	public class MemberMenu
	{
		public static void DisplayMemberLogin()
		{
			Console.Clear();
			Console.Write("===================================================================\n" +
				"Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n=============================Member Menu===========================\n\n");

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
					"Enter any key to try again\n" +
					"Enter 0 to return to main menu\n");

					if (Console.ReadLine().Equals("0")) return; // return to MAINMENU
				}
			}

			DisplayMemberMenu();
		}

		public static void DisplayMemberMenu()
        {
			Console.Clear();
			Console.Write("===================================================================\n" +
				"Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n=============================Member Menu===========================\n\n");

			Console.WriteLine("1. Browse all the movies");
			Console.WriteLine("2. Display all the information about a movie, given the title of the movie");
			Console.WriteLine("3. Borrow a movie DVD");
			Console.WriteLine("4. Return a movie DVD");
			Console.WriteLine("5. List current borrowing movies");
			Console.WriteLine("6. Display the top 3 movies rented by the members");
			Console.WriteLine("0. Return to the main menu");

			Console.Write("\nEnter your choice ==> (1/2/3/4/5/6/0): ");

			string choice = "";

			while (!choice.Equals("1") || !choice.Equals("2") || !choice.Equals("3") || !choice.Equals("4") ||
				!choice.Equals("5") || !choice.Equals("6") || !choice.Equals("0"))
			{
				choice = Console.ReadLine();

				if (choice.Equals("0")) return; // return to end of DISPLAYMEMBERLOGIN which then returns to MAINMENU
				else Console.Write("Invalid choice, please try again: ");
			}
		}
	}
}

