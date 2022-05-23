// CUSTOM EXCEPTION CLASS
// Allows for custom messages on specific reasons why functions may fail
// MemberFunctions and StaffFunctions classes throw these exceptions
// MemberMenu and StaffMenu catch these exceptions
using System;

namespace CommunityLibrary
{
	public class CustomException : Exception
	{
        public CustomException(string msg) : base(msg) { }
	}
}

