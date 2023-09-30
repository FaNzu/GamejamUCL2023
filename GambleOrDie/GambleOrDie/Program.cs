using GambleOrDie.GameLogic;
using GambleOrDie.Model;

using GambleOrDie.Games;

namespace GambleOrDie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Player1");
            Menu menu = new Menu(player);
            menu.StartMenu();
        }
    }
}
