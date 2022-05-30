// STAFF TEST PLANS
// Test staff functions through a range of scenarios
using System;
namespace CommunityLibrary
{
	public class TestStaffFunctions
	{
		public static void RunAllTests()
		{
            TestAddDVD();
            TestAddSingleDVD();
            TestRemoveDVD();
            TestRegisterMember();
            TestDeregisterMember();
            TestDisplayContactNumber();
            TestDisplayMovieBorrowers();
        }

        public static void TestAddDVD()
        {
			Console.WriteLine("\n======== AddDVD test plan ========"); // This is for completion's sake, this was implemented in A2
			Records.Reset();

			// TEST DATA
			IMovie added = new Movie("evangelion", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);

			// SCENARIO #1: ADD MOVIE
			Console.WriteLine("SCENARIO: ADDING A MOVIE------------------");
			Console.WriteLine("BEFORE:");
			Console.WriteLine("Movie list length before adding: " + Records.lib.Number);

			Console.WriteLine("\nAFTER:");
			Records.lib.Insert(added);
			Console.WriteLine("Movie list length after adding: " + Records.lib.Number);

			Records.Reset();
		}

		public static void TestAddSingleDVD()
		{
			Console.WriteLine("\n======== AddSingleDVD test plan ========");
			Records.Reset();

			// TEST DATA
			IMovie notAdded = new Movie("midsommar", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
			IMovie added = new Movie("evangelion", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
			StaffFunctions.AddDVD(added);

			// SCENARIO #1: DVD ADDED SUCCESSFULLY
			Console.WriteLine("SCENARIO: ADDING A DVD------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"Number of DVDs for {added.Title}: {added.TotalCopies + 1}");

			Console.WriteLine("\nACTUAL:");
			Console.WriteLine($"Number of DVDs for {added.Title}: {StaffFunctions.AddDVD("evangelion", 1)}");

			// SCENARIO #2: MANY DVDs ADDED SUCCESSFULLY
			Console.WriteLine("\nSCENARIO: ADDING TOO MANY DVDs------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"Number of DVDs for {added.Title}: {added.TotalCopies + 99999999}");

			Console.WriteLine("\nACTUAL:");
			Console.WriteLine($"Number of DVDs for {added.Title}: {StaffFunctions.AddDVD("evangelion", 99999999)}");

			// SCENARIO #3: ADDING NEGATIVE AMOUNT OF DVDS
			Console.WriteLine("\nSCENARIO: ADDING NEGATIVE AMOUNT OF DVDS------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"Copies and duration must be a positive number");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.AddDVD("evangelion", -1); }
			catch (CustomException ex) { Console.WriteLine(ex.Message); }

			// SCENARIO #4: TRIED TO ADD DVD WITH NO TITLE
			Console.WriteLine("\nSCENARIO: ADDING A DVD FOR A MOVIE THAT DOES NOT EXIST------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({notAdded.Title}) does not exist in library yet");

			// SCENARIO #5: TRIED TO ADD DVD FOR MOVIE THAT DOES NOT EXIST
			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.AddDVD("midsommar", 1); }
			catch (CustomException ex) { Console.WriteLine(ex.Message); }

			// SCENARIO #6: TRIED TO ADD DVD WITH NO TITLE
			Console.WriteLine("\nSCENARIO: ADDING A DVD WITH NO TITLE------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine("Failed - Titles cannot be blank, enter any key to try again, 0 to cancel:");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.AddDVD("", 1); }
			catch (ArgumentNullException) { Console.WriteLine($"Failed - Titles cannot be blank, enter any key to try again, 0 to cancel: "); }

			Records.Reset();
		}

		public static void TestRemoveDVD()
        {
			Console.WriteLine("\n======== RemoveDVD test plan ========");
			Records.Reset();

			// TEST DATA
			IMovie notAdded = new Movie("midsommar", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
			IMovie added = new Movie("evangelion", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
			StaffFunctions.AddDVD(added);
			StaffFunctions.AddDVD("evangelion", 4);

			IMember m = new Member("johnny", "madman", "0111111111", "1111");
			IMember a = new Member("a", "madman", "0111111111", "1111");
			IMember b = new Member("v", "madman", "0111111111", "1111");
			IMember c = new Member("b", "madman", "0111111111", "1111");
			IMember d = new Member("d", "madman", "0111111111", "1111");
			IMember e = new Member("e", "madman", "0111111111", "1111");

			MemberFunctions.BorrowDVD(added, m);
			MemberFunctions.BorrowDVD(added, a);
			MemberFunctions.BorrowDVD(added, b);
			MemberFunctions.BorrowDVD(added, c);
			MemberFunctions.BorrowDVD(added, d);

			StaffFunctions.DisplayMovieBorrowers(added.Title);

			// SCENARIO #1: MOVIE DOES NOT EXIST
			Console.WriteLine("SCENARIO: DELETING A MOVIE THAT DOES NOT EXIST------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({notAdded.Title}) does not exist");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.RemoveDVD(notAdded.Title, 1); }
			catch(CustomException ex) { Console.WriteLine(ex.Message); }

			// SCENARIO #2: ALL MOVIES BORROWED
			Console.WriteLine("\nSCENARIO: DELETING A MOVIE WHOSE COPIES ARE ALL BORROWED------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"Members borrowing all remaining DVDs of ({added.Title}), please return first");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.RemoveDVD(added.Title, 10); }
			catch (CustomException ex) { Console.WriteLine(ex.Message); }

			// SCENARIO #3: SOME MOVIES BORROWED
			MemberFunctions.ReturnDVD(added, m);
			Console.WriteLine("\nSCENARIO: DELETING A MOVIE THAT STILL HAS SOME BORROWERS------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"Cannot remove {10} DVDs of ({added.Title}) as members still borrowing some, " +
                $"please return first or choose less DVDs to remove...\n");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.RemoveDVD(added.Title, 10); }
			catch (CustomException ex) { Console.WriteLine(ex.Message); }

			// SCENARIO #4: REMOVING NEGATIVE AMOUNT OF DVDS
			Console.WriteLine("\nSCENARIO: REMOVING NEGATIVE AMOUNT OF DVDS------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"Copies must be a positive number");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.RemoveDVD(added.Title, -1); }
			catch (CustomException ex) { Console.WriteLine(ex.Message); }

			// SCENARIO #5: DELETE ALL AVAILABLE MOVIES
			Console.WriteLine("\nSCENARIO: REMOVING DVD THAT IS NOT BORROWED------------------");
			Console.WriteLine("BEFORE:");
			Console.WriteLine($"NUMBER OF COPIES REMAINING: {added.AvailableCopies}");

			Console.WriteLine("\nAFTER:");
			StaffFunctions.RemoveDVD(added.Title, 1);
			Console.WriteLine($"NUMBER OF COPIES REMAINING: {added.AvailableCopies}");

			// SCENARIO #6: REMOVE LAST AVAILABLE DVD
			MemberFunctions.ReturnDVD(added, a);
			MemberFunctions.ReturnDVD(added, b);
			MemberFunctions.ReturnDVD(added, c);
			MemberFunctions.ReturnDVD(added, d);

			StaffFunctions.DisplayMovieBorrowers(added.Title);
			Console.WriteLine("\nSCENARIO: REMOVING LAST DVD------------------");
			Console.WriteLine("BEFORE:");
			Console.WriteLine($"Copies of {added.Title}: {Records.lib.Search(added.Title).AvailableCopies}");

			Console.WriteLine("AFTER:");
			StaffFunctions.RemoveDVD(added.Title, 4);
			Console.WriteLine($"{added.Title} exists in record: {Records.lib.Search(added)}");

			Records.Reset();
		}

		public static void TestRegisterMember()
        {
			Console.WriteLine("\n======== RegisterMember test plan ========");
			Records.Reset();

			//TEST DATA
			IMember valid = new Member("is", "valid", "0444444444", "1111");
			IMember badNumber = new Member("not", "valid", "04444544444", "1111");
			IMember badPIN = new Member("not", "valid", "0444444444", "1111231231");
			IMember noFirst = new Member("", "valid", "0444444444", "1111");
			IMember noLast = new Member("not", "", "0444444444", "1111");
			IMember alreadyRegistered = new Member("already", "valid", "0444444444", "1111");

			// SCENARIO #1: USER REGISTERED SUCCESSFULLY
			Console.WriteLine("SCENARIO: USER SUCCESSFULLY REGISTERED------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine("User can be found: True");

			Console.WriteLine("\nACTUAL:");
			StaffFunctions.RegisterMember(valid);
			Console.WriteLine("User can be found: " + Records.reg.Search(valid));

			// SCENARIO #2: USER IS A DUPLICATE
			Console.WriteLine("\nSCENARIO: USER IS A DUPLICATE------------------");
			StaffFunctions.RegisterMember(alreadyRegistered);

			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({alreadyRegistered.FirstName} {alreadyRegistered.LastName}) already registered");

			Console.WriteLine("\nACTUAL");
			try { StaffFunctions.RegisterMember(alreadyRegistered); }
			catch (Exception e) { Console.WriteLine(e.Message); }

			// SCENARIO #3: USER HAS A BAD CONTACT NUMBER
			Console.WriteLine("\nSCENARIO: USER HAS A BAD CONTACT NUMBER------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({badNumber.ContactNumber}) is an invalid contact #");

			Console.WriteLine("\nACTUAL");
			try { StaffFunctions.RegisterMember(badNumber); }
			catch (Exception e) { Console.WriteLine(e.Message); }

			// SCENARIO #4: USER HAS A BAD PIN NUMBER
			Console.WriteLine("\nSCENARIO: USER HAS A BAD PIN NUMBER------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({badPIN.Pin}) is an invalid PIN");

			Console.WriteLine("\nACTUAL");
			try { StaffFunctions.RegisterMember(badPIN); }
			catch (Exception e) { Console.WriteLine(e.Message); }

			// SCENARIO #5: USER NO FIRST NAME
			Console.WriteLine("\nSCENARIO: USER HAS NO FIRST NAME------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine("Names cannot be empty, enter any key to try again, 0 to cancel: ");

			Console.WriteLine("\nACTUAL");
			try { StaffFunctions.RegisterMember(noFirst); }
			catch (ArgumentNullException) { Console.WriteLine("Names cannot be empty, enter any key to try again, 0 to cancel: "); }

			// SCENARIO #6: USER NO LAST NAME
			Console.WriteLine("\nSCENARIO: USER HAS NO LAST NAME------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine("Names cannot be empty, enter any key to try again, 0 to cancel: ");

			Console.WriteLine("\nACTUAL");
			try { StaffFunctions.RegisterMember(noLast); }
			catch (ArgumentNullException) { Console.WriteLine("Names cannot be empty, enter any key to try again, 0 to cancel: "); }

			// SCENARIO #7: REGISTERED MEMBERS COLLECTION IS FULL
			Console.WriteLine("\nSCENARIO: REGISTERED MEMBERS COLLECTION IS FULL------------------");
			Records.Reset();
			for (int i = 0; i < Records.reg.Capacity; i++)
            {
				Records.reg.Add(new Member(i.ToString(), "fulltest", "0416202784", "1234"));
			}

			Console.WriteLine("EXPECTED:");
			Console.WriteLine("Max member limit reached");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.RegisterMember(valid); }
			catch(CustomException e) { Console.WriteLine(e.Message); }

			Records.Reset();
		}

		public static void TestDeregisterMember()
        {
			Console.WriteLine("\n======== DeregisterMember test plan ========");
			Records.Reset();

			// TEST DATA
			IMember notRegistered = new Member("not", "valid", "0444444444", "1111");
			IMember registered = new Member("is", "valid", "0444444444", "1111");
			IMember borrowing = new Member("is", "borrowing", "0444444444", "1111");
			IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
			Records.lib.Insert(a);
			Records.lib.Search(a.Title).AddBorrower(borrowing);
			Records.reg.Add(registered);
			Records.reg.Add(borrowing);

			// SCENARIO #1: REMOVE USER THAT DOES NOT EXIST
			Console.WriteLine();
			Console.WriteLine("\nSCENARIO: USER DOES NOT EXIST---------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ notRegistered.FirstName} { notRegistered.LastName}) does not exist");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.DeregisterMember(notRegistered); }
			catch (CustomException e) { Console.WriteLine(e.Message); }

			// SCENARIO #2: REMOVE USER THAT HAS BORROWED MOVIES
			Console.WriteLine();
			Console.WriteLine("\nSCENARIO: USER THAT HAS BORROWED MOVIES---------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"Can't remove, ({ borrowing.FirstName} { borrowing.LastName}) still borrowing DVDs");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.DeregisterMember(borrowing); }
			catch (CustomException e) { Console.WriteLine("Can't remove, " + e.Message); }

			// SCENARIO #3: REMOVE USER WHO IS NOT BORROWING AND IS VALID
			Console.WriteLine();
			Console.WriteLine("\nSCENARIO: REMOVE USER WHO IS NOT BORROWING AND IS VALID---------------");
			Console.WriteLine("BEFORE DELETE:\nMember exists: " + Records.reg.Search(registered));

			StaffFunctions.DeregisterMember(registered);
			Console.WriteLine("\nAFTER DELETE:\nMember exists: " + Records.reg.Search(registered));

			Records.Reset();
		}

		public static void TestDisplayContactNumber()
        {
			Console.WriteLine("\n======== DisplayContactNumber test plan ========");
			Records.Reset();

			// TEST DATA
			IMember notRegistered = new Member("not", "valid", "0444444444", "1111");
			IMember registered = new Member("is", "valid", "0444444444", "1111");

			// SCENARIO #1: USER DOES NOT EXISTS
			Console.WriteLine("\nSCENARIO: USER DOES NOT EXIST---------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ notRegistered.FirstName} { notRegistered.LastName}) does not exist");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.DisplayContactNumber(notRegistered); }
			catch (CustomException e) { Console.WriteLine(e.Message); }

			// SCENARIO #2: USER EXISTS
			Records.reg.Add(registered);

			Console.WriteLine("\nSCENARIO: USER IS ALREADY RECORDED IN ADT--------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ registered.FirstName} { registered.LastName})'s contact # is {registered.ContactNumber}");

			Console.WriteLine("\nACTUAL:");
			StaffFunctions.DisplayContactNumber(registered);

			Records.Reset();
		}

		public static void TestDisplayMovieBorrowers()
        {
			Console.WriteLine("\n======== DisplayBorrowers test plan ========");
			Records.Reset();

			// TEST DATA
			IMovie added = new Movie("evangelion", MovieGenre.Action, MovieClassification.M15Plus, 100, 1);
			Records.lib.Insert(added);

			IMember a = new Member("jamie", "a");
			IMember b = new Member("jamie", "b");
			IMember c = new Member("jamie", "c");
			IMember d = new Member("jamie", "d");
			IMember e = new Member("jamie", "e");
			IMember f = new Member("jamie", "f");
			IMember g = new Member("jamie", "g");
			IMember h = new Member("jamie", "h");

			StaffFunctions.AddDVD("evangelion", 10);

			MemberFunctions.BorrowDVD(added, a);
			MemberFunctions.BorrowDVD(added, b);
			MemberFunctions.BorrowDVD(added, c);
			MemberFunctions.BorrowDVD(added, d);

			// SCENARIO #1: INVALID TITLE
			Console.WriteLine("SCENARIO: INVALID TITLE------------------");
			Console.WriteLine("EXPECTED:\n(not a movie) does not exist");

			Console.WriteLine("\nACTUAL:");
			try { StaffFunctions.DisplayMovieBorrowers("not a movie"); }
			catch (CustomException ce) { Console.WriteLine(ce.Message); }

			// SCENARIO #2: VALID TITLE 
			Console.WriteLine("\nSCENARIO: VALID TITLE------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine(
				"a, jamie" +
                "\nb, jamie" +
                "\nc, jamie" +
                "\nd, jamie");

			Console.WriteLine("\nACTUAL:");
			StaffFunctions.DisplayMovieBorrowers("evangelion");

			Records.Reset();
		}
	}
}
