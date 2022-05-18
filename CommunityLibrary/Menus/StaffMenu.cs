// STAFF SUB-MENU
// All display/user-inputs for the sub-menu and each option
// Options utilise corresponding functions (see StaffFunctions)
using System;

namespace CommunityLibrary
{
	public class StaffMenu
	{
		// HEADER
		// Reproducable header (clears console)
		private static void Header()
		{
			Console.Clear();
			Console.Write("===================================================================\n" +
				"Johnny n Jamie's\n" +
				"█▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█\n" +
				"█▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░\n" +
				"\n=============================Staff Menu============================\n\n");
		}

		// OPTIONS
		// Reproducable options
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

		// LOGIN
		// Display staff login page to get user input and verify credentials
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
				if (Console.ReadLine().Equals("0")) return; // return to MAIN MENU
			}

			DisplayStaffMenu();
		}

		// SUB-MENU
		// Display staff sub-menu and await user's choice
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
				else if (choice.Equals("0")) return; // return to end of DISPLAY STAFF LOGIN which then returns to MAIN MENU

				Header();
				Options();

				if (!choice.Equals("1") && !choice.Equals("2") && !choice.Equals("3") && !choice.Equals("4") &&
					!choice.Equals("5") && !choice.Equals("6")) Console.Write("Invalid choice, please try again: ");
			}
		}

		// OPTION 1
		// Get user input to either add new DVD or update copies of an existing DVD
		private static void AddDVD()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for new DVD to add...");

				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				// SCENARIO 1: movie already exists, update the total copies and return to menu
				if (Records.lib.Search(new Movie(t)))
                {
					// Boilerplate to confirm action
					Console.Write($"\nMovie {t} already exists, enter any key to add a copy, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;

					Console.Write($"\nTotal copies of {t} now {StaffFunctions.AddDVD(t)}...\nEnter any key to continue: ");
					Console.ReadLine();
					return;
				}

				// SCENARIO 2: movie is new, grab all info from user and add movie to library
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
						Console.Write("\nInvalid genre, enter any key to try again, 0 to cancel: ");
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
						Console.Write("\nInvalid classification, enter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
				}

				string dInput;
				int d;
				while (true)
                {
					Console.Write("\nDuration: ");
					dInput = Console.ReadLine();

					if (int.TryParse(dInput, out d)) break;
					else
					{
						Console.Write("\nDuration must be a number, enter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
				}

				string nInput;
				int n;
				while (true)
				{
					Console.Write("\nTotal copies: ");
					nInput = Console.ReadLine();

					if (int.TryParse(nInput, out n)) break;
					else
					{
						Console.Write("\nTotal copies must be a number, enter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
				}

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to add {n} copies of {t} to the library, 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;

				// Call functions
				if (StaffFunctions.AddDVD(new Movie(t, (MovieGenre)g, (MovieClassification)c, d, n)))
				{
					Console.Write($"\n{t} added, enter any key to continue: ");
					Console.ReadLine();
					return;
				}
				else
				{
					Console.Write($"\n{t} already exists, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		// OPTION 2
        // Get user input to remove a DVD and remove the movie from the library if no more copies left
		private static void RemoveDVD()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for the DVD to delete...");

				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to remove a copy of {t} from the library, 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;

				// SCENARIO 1: movie already exists, update the total copies and return to menu
				if (Records.lib.Search(new Movie(t)))
				{
					int total = StaffFunctions.RemoveDVD(t);

					// if there are 0 copies, the function shall remove the Movie info from the library
					if (total == 0) Console.Write($"\nMovie {t} removed from library, enter any key to continue: ");
					else if (total < 0) Console.Write($"\nMembers still borrowing {t}, please return first, enter any key to continue: ");
					else Console.Write($"\nTotal copies of {t} now {total}, enter any key to continue: ");
					Console.ReadLine();
					return;
				}
				// SCENARIO 2: movie does not exist, try again
				else
				{
					Console.Write($"\nMovie {t} does not exist in library, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		// OPTION 3
		// Get user input to register (add) a new member into the system
		private static void RegisterMember()
        {
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for new member to add...");

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

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to register {first} {last}, 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;

				if (StaffFunctions.RegisterMember(new Member(first, last, phone, pin)))
				{
					Console.Write($"\nMember {first} {last} added, enter any key to continue: ");
					Console.ReadLine();
					return;
				}
				else
				{
					Console.Write($"\n{first} {last} already registered or invalid phone/pin, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		// OPTION 4
		// Get user input to remove a registered member from the system
		private static void DeregisterMember()
		{
			while (true)
			{
				Header();
				Console.WriteLine("Please enter info for member to delete...");

				// Only require full name to verify a match (full names are unique)
				Console.Write("\nFirst name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to remove {first} {last}, 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;

				if (StaffFunctions.DeregisterMember(new Member(first, last)))
				{
					Console.Write($"\n{first} {last} removed, enter any key to continue: ");
					Console.ReadLine();
					return;
				}
				else
				{
					Console.Write($"\n{first} {last} does not exist or currently borrowing DVDs, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}

		// OPTION 5
		// todo

		// OPTION 6
		// todo
	}
}

