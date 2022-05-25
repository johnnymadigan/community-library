// STAFF SUB-MENU
// All displays/user-inputs for the sub-menu and each option
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
				Console.Write("\nInvalid credentials, enter any key to try again, 0 to cancel: ");
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
				else if (choice.Equals("5")) DisplayContactNumber();
				else if (choice.Equals("6")) DisplayMovieBorrowers();
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
				Console.WriteLine("ADDING MOVIE DVD...");

				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				int copies;
				Console.Write("Copies to add: ");

				while (true)
				{
					if (int.TryParse(Console.ReadLine(), out copies)) break;
					else Console.Write("\nCopies must be a number, please try again: ");
				}


				// SCENARIO 1: movie already exists therefore total copies is updated (function returns TRUE)
				try
				{
					// Boilerplate to confirm action
					Console.Write($"\nEnter any key to add {copies} copies of ({t}) to the library, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;

					Console.Write($"\nTotal copies of ({t}) now {StaffFunctions.AddDVD(t, copies)}, enter any key to continue: ");
					Console.ReadLine();
					return;
				}
				// SCENARIO 2: movie is new, grab all info from user and add movie to library
				catch (ArgumentNullException)
                {
					Console.Write($"\nFailed - Titles cannot be blank, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
				catch (CustomException x)
                {
					// do not say "failed" as this is a special case with this function...
					// asking the user to input the rest of the data for the new movie
					Console.Write($"\n{x.Message}, enter any key to add {copies} copies of this new movie, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;

					// Get genre
					MovieGenre? g = null;
					Console.Write("\n1. Action\n2. Comedy\n3. Drama\n4. History\n5. Western\nSelect genre ==> (1/2/3/4/5): ");

					while (g == null)
					{
						string genreInput = Console.ReadLine();

						if (genreInput.Equals("1")) g = MovieGenre.Action;
						else if (genreInput.Equals("2")) g = MovieGenre.Comedy;
						else if (genreInput.Equals("3")) g = MovieGenre.Drama;
						else if (genreInput.Equals("4")) g = MovieGenre.History;
						else if (genreInput.Equals("5")) g = MovieGenre.Western;
						else Console.Write("\nInvalid genre, please try again: ");
					}

					// Get classification
					MovieClassification? c = null;
					Console.Write("\n1. G\n2. PG\n3. M\n4. M15Plus\nSelect classification ==> (1/2/3/4): ");

					while (c == null)
					{
						string classInput = Console.ReadLine();

						if (classInput.Equals("1")) c = MovieClassification.G;
						else if (classInput.Equals("2")) c = MovieClassification.PG;
						else if (classInput.Equals("3")) c = MovieClassification.M;
						else if (classInput.Equals("4")) c = MovieClassification.M15Plus;
						else Console.Write("\nInvalid classification, please try again: ");
					}

					// Get duration as number
					int d;
					Console.Write("\nDuration: ");

					while (true)
					{
						if (int.TryParse(Console.ReadLine(), out d)) break;
						else Console.Write("\nDuration must be a number, please try again: ");
					}

					// Boilerplate to confirm action
					Console.Write($"\nEnter any key to add {copies} copies of ({t}) to the library, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;

					// ADD NEW MOVIE (this overloaded version function does not throw any exceptions so no need to try/catch)
					if (StaffFunctions.AddDVD(new Movie(t, (MovieGenre)g, (MovieClassification)c, d, copies)))
					{
						Console.Write($"\n({t}) added, enter any key to continue: ");
						Console.ReadLine();
						return;
					}
					else // Safety check to prevent adding duplicates
					{
						Console.Write($"\nFailed - ({t}) already exists, enter any key to try again, 0 to cancel: ");
						if (Console.ReadLine().Equals("0")) return;
					}
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
				Console.WriteLine("REMOVING MOVIE DVD...");

				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				int copies;
				Console.Write("Copies to remove: ");

				while (true)
				{
					if (int.TryParse(Console.ReadLine(), out copies)) break;
					else Console.Write("\nCopies must be a number, please try again: ");
				}

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to remove {copies} copies of ({t}) from the library, 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;


				try // TRY TO REMOVE MOVIE DVD
				{
					int total = StaffFunctions.RemoveDVD(t, copies);

					if (total <= 0) Console.Write($"\nMovie ({t}) deleted as all copies removed, enter any key to continue: ");
					else Console.Write($"\nTotal copies of ({t}) now {total}, enter any key to continue: ");

					Console.ReadLine();
					return;
				}
				catch (CustomException x)
				{
					Console.Write($"\nFailed - {x.Message}, enter any key to try again, 0 to cancel: ");
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
				Console.WriteLine("REGISTERING NEW MEMBER...");

				// Get user input...
				Console.Write("First name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();
				Console.Write("Contact number: ");
				string phone = Console.ReadLine();
				Console.Write("Pin: ");
				string pin = Console.ReadLine();

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to register ({first} {last}), 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;

                try // TRY TO ADD (REGISTER) MEMBER
                {
					StaffFunctions.RegisterMember(new Member(first, last, phone, pin));
					Console.Write($"\n({first} {last}) registered, enter any key to continue: ");
					Console.ReadLine();
					return;

				}
				catch (ArgumentNullException)
				{
					Console.Write($"\nFailed - Names cannot be blank, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
				catch (CustomException x)
                {
					Console.Write($"\nFailed - {x.Message}, enter any key to try again, 0 to cancel: ");
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
				Console.WriteLine("REMOVING MEMBER...");

				// Only require full name to verify a match
				Console.Write("\nFirst name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to remove ({first} {last}), 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;

				try // TRY TO REMOVE (DEREGISTER) MEMBER
				{
					StaffFunctions.DeregisterMember(new Member(first, last));
					Console.Write($"\n({first} {last}) removed, enter any key to continue: ");
					Console.ReadLine();
					return;
				}
				catch (CustomException x)
				{
					Console.Write($"\nFailed - {x.Message}, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}



		// OPTION 5
		// Get user input to display a registered member's contact number
		private static void DisplayContactNumber()
		{
			while (true)
			{
				Header();
				Console.WriteLine("DISPLAYING A MEMBER'S CONTACT #...");

				// Only require full name to verify a match
				Console.Write("\nFirst name: ");
				string first = Console.ReadLine();
				Console.Write("Last name: ");
				string last = Console.ReadLine();

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to display ({first} {last})'s contact #, 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;


				try // TRY TO DISPLAY THE MEMBER'S CONTACT #
				{
					StaffFunctions.DisplayContactNumber(new Member(first, last));
					Console.Write($"\nEnter any key to continue: ");
					Console.ReadLine();
					return;
				}
				catch (CustomException x)
				{
					Console.Write($"\nFailed - {x.Message}, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}



		// OPTION 6
		// Get user input to display all a movie's full list of borrowers
		private static void DisplayMovieBorrowers()
		{
			while (true)
			{
				Header();
				Console.WriteLine("DISPLAYING A MOVIE'S BORROWERS...");

				Console.Write("Movie title: ");
				string t = Console.ReadLine();

				// Boilerplate to confirm action
				Console.Write($"\nEnter any key to display all members borrowing ({t}), 0 to cancel: ");
				if (Console.ReadLine().Equals("0")) return;


				try // TRY TO DISPLAY ALL MEMBERS BORROWING THIS MOVIE
				{
					Console.Write($"\nMembers currently borrowing ({t}):\n\n");
					StaffFunctions.DisplayMovieBorrowers(t);
					Console.Write($"\nEnter any key to continue: ");
					Console.ReadLine();
					return;
				}
				catch (CustomException x)
				{
					Console.Write($"\nFailed - {x.Message}, enter any key to try again, 0 to cancel: ");
					if (Console.ReadLine().Equals("0")) return;
				}
			}
		}
	}
}

