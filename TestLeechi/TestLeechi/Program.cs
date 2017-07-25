using TestLeechi.ConsoleMenu;

namespace TestLeechi
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();

            int choice = 0;

            do
            {
                choice = menu.DisplayMenu();
                menu.ExecuteChoice(choice);
            }
            while (choice != 5);
        }
    }
}
