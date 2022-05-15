using System;
namespace CommunityLibrary
{
	public class MainMenu
	{
		public static void DisplayMainMenu()
		{
			Options();

			string choice = "";

			while (!choice.Equals("1") || !choice.Equals("2") || !choice.Equals("0"))
			{
				choice = Console.ReadLine();

				if (choice.Equals("1"))
				{
					StaffMenu.DisplayStaffLogin();
					Options(); // when user exits staff menu, display main menu again
				}
				else if (choice.Equals("2"))
				{
					MemberMenu.DisplayMemberLogin();
					Options(); // when user exits member menu, display main menu again
				}
				else if (choice.Equals("0"))
				{
					Console.Clear();
					Console.WriteLine("Exiting program...");
					return; // return to MAIN
				}
				else Console.Write("Invalid choice, please try again: ");
			}
		}

		private static void Options()
        {
			Console.Clear();
			Console.Write("===================================================================\n" +
				"Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n=============================Main Menu=============================\n\n");

			Console.WriteLine("1. Staff Login");
			Console.WriteLine("2. Member Login");
			Console.WriteLine("0. Exit");

			Console.Write("\nEnter your choice ==> (1/2/0): ");
		}
	}
}

