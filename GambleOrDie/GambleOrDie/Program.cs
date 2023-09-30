using GambleOrDie.GameLogic;
using GambleOrDie.Model;

using GambleOrDie.Games;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GambleOrDie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Player1");
            Menu menu = new Menu(player);
            menu.StartMenu();

            //OpenBrowser("https://www.youtube.com/watch?v=dQw4w9WgXcQ");

            //Wordle wordle = new Wordle();
            //wordle.board(1);
        }
        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}