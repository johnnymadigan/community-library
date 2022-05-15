using System;

namespace CommunityLibrary
{
	public class MainMenu
	{
		private static void Header()
        {
			Console.Clear();
			Console.Write("===================================================================\n" +
				"Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n=============================Main Menu=============================\n\n");
		}

		private static void Options()
		{
			Console.WriteLine("1. Staff Login");
			Console.WriteLine("2. Member Login");
			Console.WriteLine("0. Exit");

			Console.Write("\nEnter your choice ==> (1/2/0): ");
		}

		public static void DisplayMainMenu()
		{
			Header();
			Options();

			// loop so the user can select options...
			// if user selects to exit, break out of loop and return to PROGRAM
			while (true)
			{
				string choice = Console.ReadLine();

				if (choice.Equals("1")) StaffMenu.DisplayStaffLogin();
				else if (choice.Equals("2")) MemberMenu.DisplayMemberLogin();
				else if (choice.Equals("0")) return;

				Header();
				Options();

				if (!choice.Equals("1") && !choice.Equals("2") && !choice.Equals("3")) Console.Write("Invalid choice, please try again: ");
			}
		}
	}
}

