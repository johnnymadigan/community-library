using System;
namespace CommunityLibrary
{
	public class Login
	{
		public static void DisplayLogin()
        {
			Console.Clear();
			Console.Write("=================================================================\n" +
                "Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n============================Main Menu============================\n\n");

			Console.WriteLine("1. Staff Login");
			Console.WriteLine("2. Member Login");
			Console.WriteLine("0. Exit");

			Console.Write("\nEnter your choice ==> (1/2/0): ");

			string choice = "";

			while (!choice.Equals("1") || !choice.Equals("2") || !choice.Equals("0"))
			{
				choice = Console.ReadLine();

				if (choice.Equals("1")) MemberMenu.DisplayMemberMenu();
				else if (choice.Equals("2")) StaffMenu.DisplayStaffMenu();
				else if (choice.Equals("0")) return; // exit by returning to main
				else Console.Write("Invalid choice, please try again: ");
			}
		}
	}
}

