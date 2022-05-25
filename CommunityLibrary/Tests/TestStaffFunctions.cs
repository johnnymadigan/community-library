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

        }

		public static void TestDeregisterMember()
        {

        }

		public static void TestDisplayContactNumber()
        {
			Console.WriteLine("\n======== DisplayContactNumber test plan ========");
			Records.Reset();

			// TEST DATA
			IMember notRegistered = new Member("not", "valid", "0444444444", "1111");
			IMember registered = new Member("not", "valid", "0444444444", "1111");

			// USER DOES NOT EXISTS
			Console.WriteLine("Case when user does not exist");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ notRegistered.FirstName} { notRegistered.LastName}) does not exist");

			Console.WriteLine("ACTUAL:");
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

			Console.WriteLine("Case when user is recorded in the ADT");
			Console.WriteLine("EXPECTED:");
			Console.WriteLine($"({ registered.FirstName} { registered.LastName})'s contact number is {registered.ContactNumber}");

			Console.WriteLine("ACTUAL:");
			StaffFunctions.DisplayContactNumber(registered);

			Records.Reset();
		}

		public static void TestDisplayMovieBorrowers()
        {

        }
	}
}

