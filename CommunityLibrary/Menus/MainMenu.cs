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

			string choice = "";

			while (!choice.Equals("0"))
			{
				choice = Console.ReadLine();

				if (choice.Equals("1")) StaffMenu.DisplayStaffLogin();
				else if (choice.Equals("2")) MemberMenu.DisplayMemberLogin();

				// when user completes action, display options again
				Header();
				Options();

				// additional line if user input was invalid
				if (!choice.Equals("1") && !choice.Equals("2") && !choice.Equals("0")) Console.Write("Invalid choice, please try again: ");
			}
		}
	}
}

