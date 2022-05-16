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
				Console.WriteLine("Please login with a staff account...");

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

				if (choice.Equals("1")) AddDVD();
				else if (choice.Equals("2")) RemoveDVD();
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

		// OPTION 1 USER INPUT/LOOP
		// ??
		// Pre-condition: nil
		// Post-condition: nil
		private static void AddDVD()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for movie to add...");

				// it is assumed full names are unique
				// todo might check if name is not taken tho
				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				string genreInput;
				MovieGenre? g = null;
				        
				while (g == null)
				{
					Console.Write("\n1. Action\n2. Comedy\n3. Drama\n4. History\n5. Western\nSelect genre ==> (1/2/3/4/5): ");
					genreInput = Console.ReadLine();

					if (genreInput.Equals("1")) g = MovieGenre.Action;
					else if (genreInput.Equals("2")) g = MovieGenre.Comedy;
					else if (genreInput.Equals("3")) g = MovieGenre.Drama;
					else if (genreInput.Equals("4")) g = MovieGenre.History;
					else if (genreInput.Equals("5")) g = MovieGenre.Western;
					else
					{
						Console.Write("\nInvalid genre...\nEnter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
				}

				string classInput;
				MovieClassification? c = null;
				while (c == null)
				{
					Console.Write("\n1. G\n2. PG\n3. M\n4. M15Plus\nSelect classification ==> (1/2/3/4): ");
					classInput = Console.ReadLine();
					
					if (classInput.Equals("1")) c = MovieClassification.G;
					else if (classInput.Equals("2")) c = MovieClassification.PG;
					else if (classInput.Equals("3")) c = MovieClassification.M;
					else if (classInput.Equals("4")) c = MovieClassification.M15Plus;
					else
					{
						Console.Write("\nInvalid classification...\nEnter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
				}

				string dInput;
				int d;
				while (true)
                {
					Console.Write("Duration: ");
					dInput = Console.ReadLine();

					if (int.TryParse(dInput, out d)) break;
					else
					{
						Console.Write("\nDuration must be a number...\nEnter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
				}

				string nInput;
				int n;
				while (true)
				{
					Console.Write("Total copies: ");
					nInput = Console.ReadLine();

					if (int.TryParse(nInput, out n)) break;
					else
					{
						Console.Write("\nTotal copies must be a number...\nEnter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
				}

				Console.WriteLine($"\nNew movie: {t}");
				Console.Write("Enter any key to add this movie, 0 to cancel: ");

				if (Console.ReadLine().Equals("0")) return;

				if (StaffFunctions.AddDVD(new Movie(t, (MovieGenre)g, (MovieClassification)c, d, n)))
				{
					Console.Write($"Movie {t} added...\nEnter any key to continue: ");
					Console.ReadLine();
					return;
				}
				else
				{
					Console.Write($"\nMovie {t} is a duplicate...\nEnter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		// OPTION 2 USER INPUT/LOOP
		// ??
		// Pre-condition: nil
		// Post-condition: nil
		private static void RemoveDVD()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for movie to delete...");

				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				if (StaffFunctions.RemoveDVD(new Movie(t)))
				{
					Console.Write($"\nMovie {t} removed...\nEnter any key to continue: ");
					Console.ReadLine();
					return;
				}
				else
				{
					Console.Write($"\nMovie {t} does not exist...\nEnter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		// OPTION 3 USER INPUT/LOOP
		private static void RegisterMember()
        {
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for new member...");

				// it is assumed full names are unique
				// todo might check if name is not taken tho
				Console.Write("First name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();
				Console.Write("Phone number: ");
				string phone = Console.ReadLine();
				Console.Write("Pin: ");
				string pin = Console.ReadLine();

				Console.WriteLine($"\nNew member: {first} {last}, {phone}, {pin}");
				Console.Write("Enter any key to register this member, 0 to cancel: ");

				if (Console.ReadLine().Equals("0")) return;

				if (StaffFunctions.RegisterMember(new Member(first, last, phone, pin)))
				{
					Console.Write($"\nMember {first} {last} added...\nEnter any key to continue: ");
					Console.ReadLine();
					return;
				}
				else
				{
					Console.Write($"\Member {first} {last} is a duplicate or invalid phone/pin...\nEnter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		// OPTION 4 USER INPUT/LOOP
		// ??
		// Pre-condition: nil
		// Post-condition: nil
		private static void DeregisterMember()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for member to delete...");

				// full names are unique, therefore do not worry about confirming phone
				Console.Write("First name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				if (StaffFunctions.DeregisterMember(new Member(first, last)))
				{
					Console.Write($"\nMember {first} {last} removed...\nEnter any key to continue: ");
					Console.ReadLine();
					return;
				}
				else
				{
					Console.Write($"\nMember {first} {last} does not exist...\nEnter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		
	}
}

