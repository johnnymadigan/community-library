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
            Records.lib.Insert(new Movie("potc", MovieGenre.Action, MovieClassification.M15Plus, 1, 1));




            MainMenu.DisplayMainMenu();
        }
    }
}

