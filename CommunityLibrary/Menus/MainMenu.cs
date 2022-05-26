// MAIN MENU
// All displays/user-inputs for the main-menu and each option
// Branches off to sub-menus (staff and member)
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

			Console.Write("\nPress your choice ==> (1/2/0): ");
		}

		public static void DisplayMainMenu()
		{
			// loop so the user can select options...
			// if user selects to exit, return to PROGRAM
			while (true)
			{
				Header();
				Options();

				ConsoleKeyInfo k = Console.ReadKey();

				if (k.KeyChar == '1') StaffMenu.DisplayStaffLogin();
				else if (k.KeyChar == '2') MemberMenu.DisplayMemberLogin();
				else if (k.KeyChar == '0')
				{
					Console.WriteLine("\nExiting app...");
					return;
				}
			}
		}
	}
}

