// STAFF SUB-MENU
// All displays/user-inputs for the sub-menu and each option
// Options utilise corresponding functions (see StaffFunctions)
using System;
using System.Text.RegularExpressions;

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

			Console.Write("\nPress your choice ==> (1/2/3/4/5/6/0): ");
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

				Console.Write("\nInvalid credentials, press any key to try again, 0 to cancel: ");
				if (Console.ReadKey().KeyChar == '0') return; // return to MAIN MENU
			}

			// must be called outside the above loop so when the user wants to navigates back to the MAIN MENU...
			// this method will end and they will be returned to the MAIN MENU's method
			DisplayStaffMenu();
		}



		// SUB-MENU
		// Display staff sub-menu and await user's choice
		private static void DisplayStaffMenu()
        {
			// loop so the user can select options...
			while (true)
			{
				Header();
				Options();

				ConsoleKeyInfo k = Console.ReadKey();

				if (k.KeyChar == '1') AddDVD();
				else if (k.KeyChar == '2') RemoveDVD();
				else if (k.KeyChar == '3') RegisterMember();
				else if (k.KeyChar == '4') DeregisterMember();
				else if (k.KeyChar == '5') DisplayContactNumber();
				else if (k.KeyChar == '6') DisplayMovieBorrowers();
				else if (k.KeyChar == '0') return; // return to end of DISPLAY STAFF LOGIN which then returns to MAIN MENU
			}
		}



		// OPTION 1
		// Get user input to either add new DVD or update copies of an existing DVD
		private static void AddDVD()
		{
			// loop so the user can select options...
			while (true)
			{
				Header();
				Console.WriteLine("ADDING MOVIE DVD...");

				Console.Write("\nMovie title: ");
				string t = Console.ReadLine();

				Console.Write("Copies to add: ");
				int copies;

				while (true)
				{
					// no need to reset copies' value to try again since if the user input failed...
					// the current val after tryparse will still be negative anyway
					if (int.TryParse(Console.ReadLine(), out copies) && copies > 0) break;
					else Console.Write("Copies must be a positive number, please try again: ");
				}

				// Boilerplate to confirm action
				Console.Write($"\nPress any key to add {copies} copies of ({t}) to the library, 0 to cancel: ");
				if (Console.ReadKey().KeyChar == '0') return;

				// SCENARIO 1: movie already exists therefore total copies is updated (function returns TRUE)
				try
				{
					Console.Write($"\n\nTotal copies of ({t}) now {StaffFunctions.AddDVD(t, copies)}, press any key to continue: ");
					Console.ReadKey();
					return;
				}
				// SCENARIO 2: movie is new, grab all info from user and add movie to library
				catch (ArgumentNullException)
                {
					Console.Write($"\n\nFailed - Titles cannot be blank, press any key to try again, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;
				}
				catch (CustomException x)
                {
					// do not say "failed" as this is a special case with this function...
					// asking the user to input the rest of the data for the new movie
					Console.Write($"\n\n{x.Message}, press any key to add ({t}) as a new movie with {copies} copies, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;

					// Get genre
					MovieGenre? g = null;
					Console.Write("\n\n1. Action\n2. Comedy\n3. Drama\n4. History\n5. Western\nSelect genre ==> (1/2/3/4/5): ");

					while (g == null)
					{
						ConsoleKeyInfo k = Console.ReadKey();

						if (k.KeyChar == '1') g = MovieGenre.Action;
						else if (k.KeyChar == '2') g = MovieGenre.Comedy;
						else if (k.KeyChar == '3') g = MovieGenre.Drama;
						else if (k.KeyChar == '4') g = MovieGenre.History;
						else if (k.KeyChar == '5') g = MovieGenre.Western;
						else Console.Write("\nInvalid genre, please try again: ");
					}

					// Get classification
					MovieClassification? c = null;
					Console.Write("\n\n1. G\n2. PG\n3. M\n4. M15Plus\nSelect classification ==> (1/2/3/4): ");

					while (c == null)
					{
						ConsoleKeyInfo k = Console.ReadKey();

						if (k.KeyChar == '1') c = MovieClassification.G;
						else if (k.KeyChar == '2') c = MovieClassification.PG;
						else if (k.KeyChar == '3') c = MovieClassification.M;
						else if (k.KeyChar == '4') c = MovieClassification.M15Plus;
						else Console.Write("\nInvalid classification, please try again: ");
					}

					// Get duration as number
					Console.Write("\n\nDuration: ");
					int d;

					while (true)
					{
						// no need to reset duration' value to try again since if the user input failed...
						// the current val after tryparse will still be negative anyway
						if (int.TryParse(Console.ReadLine(), out d) && d > 0) break;
						else Console.Write("Duration must be a positive number, please try again: ");
					}

					// Boilerplate to confirm action
					Console.Write($"\nPress any key to add {copies} copies of ({t}) to the library, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;

					// ADD NEW MOVIE (this overloaded version function does not throw any exceptions so no need to try/catch)
					if (StaffFunctions.AddDVD(new Movie(t, (MovieGenre)g, (MovieClassification)c, d, copies)))
					{
						Console.Write($"\n\n({t}) added, press any key to continue: ");
						Console.ReadKey();
						return;
					}
					else // Safety check to prevent adding duplicates
					{
						Console.Write($"\n\nFailed - ({t}) already exists, press any key to try again, 0 to cancel: ");
						if (Console.ReadKey().KeyChar == '0') return;
					}
				}
			}
		}



		// OPTION 2
        // Get user input to remove a DVD and remove the movie from the library if no more copies left
		private static void RemoveDVD()
		{
			// loop so the user can select options...
			while (true)
			{
				Header();
				Console.WriteLine("REMOVING MOVIE DVD...");

				Console.Write("\nMovie title: ");
				string t = Console.ReadLine();

				Console.Write("Copies to remove: ");
				int copies;

				while (true)
				{
					// no need to reset copies' value to try again since if the user input failed...
					// the current val after tryparse will still be negative anyway
					if (int.TryParse(Console.ReadLine(), out copies) && copies > 0) break;
					else Console.Write("Copies must be a positive number, please try again: ");
				}

				// Boilerplate to confirm action
				Console.Write($"\nPress any key to remove {copies} copies of ({t}) from the library, 0 to cancel: ");
				if (Console.ReadKey().KeyChar == '0') return;


				try // TRY TO REMOVE MOVIE DVD
				{
					int total = StaffFunctions.RemoveDVD(t, copies);

					if (total <= 0) Console.Write($"\n\nMovie ({t}) deleted as all copies removed, press any key to continue: ");
					else Console.Write($"\n\nTotal copies of ({t}) now {total}, press any key to continue: ");

					Console.ReadKey();
					return;
				}
				catch (CustomException x)
				{
					Console.Write($"\n\nFailed - {x.Message}, press any key to try again, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;
				}
			}
		}



		// OPTION 3
		// Get user input to register (add) a new member into the system
		private static void RegisterMember()
        {
			// loop so the user can select options...
			while (true)
			{
				Header();
				Console.WriteLine("REGISTERING NEW MEMBER...");

				// Get user input...
				Console.Write("\nFirst name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				Console.Write("Contact number: ");
				string phone;

				while (true)
				{
					phone = Console.ReadLine();

					if (Regex.IsMatch(phone, @"^[0-9]+$")) break;
					else Console.Write("Contact # must be a number, please try again: ");
				}

				Console.Write("PIN: ");
				string pin;

				while (true)
				{
					pin = Console.ReadLine();

					if (Regex.IsMatch(pin, @"^[0-9]+$")) break;
					else Console.Write("\nPIN must be a number, please try again: ");
				}

				// Boilerplate to confirm action
				Console.Write($"\nPress any key to register ({first} {last}), 0 to cancel: ");
				if (Console.ReadKey().KeyChar == '0') return;

				try // TRY TO ADD (REGISTER) MEMBER
				{
					StaffFunctions.RegisterMember(new Member(first, last, phone, pin));
					Console.Write($"\n\n({first} {last}) registered, press any key to continue: ");

					Console.ReadKey();
					return;
				}
				catch (ArgumentNullException)
				{
					Console.Write($"\n\nFailed - Names cannot be blank, press any key to try again, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;
				}
				catch (CustomException x)
                {
					Console.Write($"\n\nFailed - {x.Message}, press any key to try again, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;
				}
			}
		}



		// OPTION 4
		// Get user input to remove a registered member from the system
		private static void DeregisterMember()
		{
			// loop so the user can select options...
			while (true)
			{
				Header();
				Console.WriteLine("REMOVING MEMBER...");

				// Only require full name to verify a match
				Console.Write("\nFirst name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				// Boilerplate to confirm action
				Console.Write($"\nPress any key to remove ({first} {last}), 0 to cancel: ");
				if (Console.ReadKey().KeyChar == '0') return;

				try // TRY TO REMOVE (DEREGISTER) MEMBER
				{
					StaffFunctions.DeregisterMember(new Member(first, last));
					Console.Write($"\n\n({first} {last}) removed, press any key to continue: ");

					Console.ReadKey();
					return;
				}
				catch (CustomException x)
				{
					Console.Write($"\n\nFailed - {x.Message}, press any key to try again, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;
				}
			}
		}



		// OPTION 5
		// Get user input to display a registered member's contact number
		private static void DisplayContactNumber()
		{
			// loop so the user can select options...
			while (true)
			{
				Header();
				Console.WriteLine("DISPLAYING A MEMBER'S CONTACT #...");

				// Only require full name to verify a match
				Console.Write("\nFirst name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				try // TRY TO DISPLAY THE MEMBER'S CONTACT #
				{
					Console.WriteLine("");
					StaffFunctions.DisplayContactNumber(new Member(first, last));
					Console.Write($"\nPress any key to continue: ");

					Console.ReadKey();
					return;
				}
				catch (CustomException x)
				{
					Console.Write($"Failed - {x.Message}, press any key to try again, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;
				}
			}
		}



		// OPTION 6
		// Get user input to display all a movie's full list of borrowers
		private static void DisplayMovieBorrowers()
		{
			// loop so the user can select options...
			while (true)
			{
				Header();
				Console.WriteLine("DISPLAYING A MOVIE'S BORROWERS...");

				Console.Write("\nMovie title: ");
				string t = Console.ReadLine();

				try // TRY TO DISPLAY ALL MEMBERS BORROWING THIS MOVIE
				{
					Console.Write($"\nMembers currently borrowing ({t}):\n\n");
					StaffFunctions.DisplayMovieBorrowers(t);
					Console.Write($"Press any key to continue: ");

					Console.ReadKey();
					return;
				}
				catch (CustomException x)
				{
					Console.Write($"Failed - {x.Message}, press any key to try again, 0 to cancel: ");
					if (Console.ReadKey().KeyChar == '0') return;
				}
			}
		}
	}
}

