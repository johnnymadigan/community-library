// Johnny n Jamie's
// █▀▀ █▀█ █▀▄▀█ █▀▄▀█ █░█ █▄░█ █ ▀█▀ █▄█	█░░ █ █▄▄ █▀█ ▄▀█ █▀█ █▄█
// █▄▄ █▄█ █░▀░█ █░▀░█ █▄█ █░▀█ █ ░█░ ░█░	█▄▄ █ █▄█ █▀▄ █▀█ █▀▄ ░█░
// Initialises new global database with default staff credentials
// Calls initial interface (main menu)
namespace CommunityLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            new Records("staff", "today123", 100);



            // testing data only
            IMember m = new Member("bofa", "dem", "0123456789", "1234");
            Records.reg.Add(m);

            IMovie a = new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 1999, 1);
            IMovie b = new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 1111, 2);
            IMovie c = new Movie("batman", MovieGenre.Action, MovieClassification.M15Plus, 69, 3);

            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            a.AddBorrower(m);
            a.RemoveBorrower(m);
            b.AddBorrower(m);
            b.RemoveBorrower(m);
            b.AddBorrower(m);
            b.RemoveBorrower(m);
            c.AddBorrower(m);
            c.RemoveBorrower(m);

            Records.lib.Insert(a);
            Records.lib.Insert(b);
            Records.lib.Insert(c);

            // top 3 order should be a, b, c


            MainMenu.DisplayMainMenu();
        }
    }
}

