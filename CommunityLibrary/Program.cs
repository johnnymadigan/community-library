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
            Records.reg.Add(new Member("bofa", "dem", "0123456789", "1234"));
            Records.lib.Insert(new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 1999, 1));
            Records.lib.Insert(new Movie("eeaao", MovieGenre.Action, MovieClassification.M15Plus, 1111, 2));
            Records.lib.Insert(new Movie("batman", MovieGenre.Action, MovieClassification.M15Plus, 69, 3));




            MainMenu.DisplayMainMenu();
        }
    }
}

