using System;

namespace CoiniumServ.Utils
{
    /// <summary>
    /// Utility class to handle console window stuff.
    /// </summary>
    class ConsoleWindow
    {
        /// <summary>
        /// Prints an info banner.
        /// </summary>
        public static void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(@" ____                   _                      _ ");
			Console.WriteLine(@"/ ___| _ __   __ _ _ __| | ___ __   ___   ___ | |");
			Console.WriteLine(@"\___ \| '_ \ / _` | '__| |/ / '_ \ / _ \ / _ \| |");
			Console.WriteLine(@" ___) | |_) | (_| | |  |   <| |_) | (_) | (_) | |");
			Console.WriteLine(@"|____/| .__/ \__,_|_|  |_|\_\ .__/ \___/ \___/|_|");
			Console.WriteLine(@"      |_|                   |_|    ");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints a copyright banner.
        /// </summary>
        public static void PrintLicense()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ETH : 0xE095327C3E0d8e92A5870772aBC40163F2BBD956");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
