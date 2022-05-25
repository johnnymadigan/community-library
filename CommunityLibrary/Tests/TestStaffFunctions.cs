﻿// STAFF TEST PLANS
// Test staff functions through a range of scenarios
using System;
namespace CommunityLibrary
{
	public class TestStaffFunctions
	{
		public static void RunAllTests()
		{
			TestAddDVD();
			TestRemoveDVD();
			TestRegisterMember();
			TestDeregisterMember();
			TestDisplayContactNumber();
			TestDisplayMovieBorrowers();
		}

		public static void TestAddDVD()
        {

        }

		public static void TestRemoveDVD()
        {

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

			// USER REGISTERED SUCCESSFULLY
			Console.WriteLine("CASE: USER SUCCESSFULLY REGISTERED------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine("User can be found: True");

			Console.WriteLine("\nACTUAL:");
			StaffFunctions.RegisterMember(valid);
			Console.WriteLine("User can be found: " + Records.reg.Search(valid));

			// USER IS A DUPLICATE
			Console.WriteLine("\nCASE: USER IS A DUPLICATE------------------");
			StaffFunctions.RegisterMember(alreadyRegistered);

			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({alreadyRegistered.FirstName} {alreadyRegistered.LastName}) is already registered");

			Console.WriteLine("\nACTUAL");
			try
            {
				StaffFunctions.RegisterMember(alreadyRegistered);
            }
			catch (Exception e)
            {
				Console.WriteLine(e.Message);
            }

			// USER HAS A BAD CONTACT NUMBER
			Console.WriteLine("\nCASE: USER HAS A BAD CONTACT NUMBER------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({badNumber.ContactNumber}) is not a valid contact #");

			Console.WriteLine("\nACTUAL");
			try
			{
				StaffFunctions.RegisterMember(badNumber);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			// USER HAS A BAD PIN NUMBER
			Console.WriteLine("\nCASE: USER HAS A BAD PIN NUMBER------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({badPIN.Pin}) is an invalid PIN");

			Console.WriteLine("\nACTUAL");
			try
			{
				StaffFunctions.RegisterMember(badPIN);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			// USER NO FIRST OR LAST NAME
			Console.WriteLine("\nCASE: USER HAS NO FIRST NAME------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine("Names cannot be empty, enter any key to try again, 0 to cancel: ");

			Console.WriteLine("\nACTUAL");
			try
			{
				StaffFunctions.RegisterMember(noFirst);
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine("Names cannot be empty, enter any key to try again, 0 to cancel: ");
			}

			Console.WriteLine("\nCASE: USER HAS NO LAST NAME------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine("Names cannot be empty, enter any key to try again, 0 to cancel: ");

			Console.WriteLine("\nACTUAL");
			try
			{
				StaffFunctions.RegisterMember(noLast);
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine("Names cannot be empty, enter any key to try again, 0 to cancel: ");
			}

			Console.WriteLine("\nCASE: MEMBER COLLECTION IS FULL------------------");
			Records.Reset();
			for (int i = 0; i < Records.reg.Capacity; i++)
            {
				Records.reg.Add(new Member(i.ToString(), "fulltest", "0416202784", "1234"));
            }

			Console.WriteLine("EXPECTED:");
			Console.WriteLine("Max member limit reached!");

			Console.WriteLine("\nACTUAL:");
			try
            {
				StaffFunctions.RegisterMember(valid);
            }
			catch(CustomException e)
            {
				Console.WriteLine(e.Message);
            }

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

			// REMOVE USER THAT DOES NOT EXIST
			Console.WriteLine();
			Console.WriteLine("\nCASE: USER DOES NOT EXIST---------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ notRegistered.FirstName} { notRegistered.LastName}) does not exist");

			Console.WriteLine("\nACTUAL:");
			try
			{
				StaffFunctions.DeregisterMember(notRegistered);
			}
			catch (CustomException e)
			{
				Console.WriteLine(e.Message);
			}

			// REMOVE USER THAT HAS BORROWED MOVIES
			Console.WriteLine();
			Console.WriteLine("\nCASE: USER THAT HAS BORROWED MOVIES---------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ borrowing.FirstName} { borrowing.LastName}) still borrowing DVDs");

			Console.WriteLine("\nACTUAL:");
			try
			{
				StaffFunctions.DeregisterMember(borrowing);
			}
			catch (CustomException e)
			{
				Console.WriteLine(e.Message);
			}

			// REMOVE USER WHO IS NOT BORROWING AND IS VALID
			Console.WriteLine();
			Console.WriteLine("\nCASE: REMOVE USER WHO IS NOT BORROWING AND IS VALID---------------");
			Console.WriteLine("BEFORE DELETE:");
			Console.WriteLine("Member exists: " + Records.reg.Search(registered));

			Console.WriteLine("\nAFTER DELETE:");
			StaffFunctions.DeregisterMember(registered);
			Console.WriteLine("Member exists: " + Records.reg.Search(registered));

			Records.Reset();
		}

		public static void TestDisplayContactNumber()
        {
			Console.WriteLine("\n======== DisplayContactNumber test plan ========");
			Records.Reset();

			// TEST DATA
			IMember notRegistered = new Member("not", "valid", "0444444444", "1111");
			IMember registered = new Member("is", "valid", "0444444444", "1111");

			// USER DOES NOT EXISTS
			Console.WriteLine("\nCASE: USER DOES NOT EXIST---------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ notRegistered.FirstName} { notRegistered.LastName}) does not exist");

			Console.WriteLine("\nACTUAL:");
			try
            {
				StaffFunctions.DisplayContactNumber(notRegistered);
            }
			catch (CustomException e)
            {
				Console.WriteLine(e.Message);
            }


			// USER EXISTS
			Records.reg.Add(registered);

			Console.WriteLine("\nCASE: USER IS ALREADY RECORDED IN ADT--------------------");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ registered.FirstName} { registered.LastName})'s contact number is {registered.ContactNumber}");

			Console.WriteLine("\nACTUAL:");
			StaffFunctions.DisplayContactNumber(registered);

			Records.Reset();
		}

		public static void TestDisplayMovieBorrowers()
        {

        }
	}
}

