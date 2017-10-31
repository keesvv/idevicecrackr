using System;
using System.IO;
using System.Threading;

using iDeviceCrackr.Classes;

namespace iDeviceCrackr
{
    public class Tools
    {
        private static string SplashText =
            @"  _ _____             _           _____                _         " + "\n" +
            @" (_)  __ \           (_)         / ____|              | |        " + "\n" +
            @"  _| |  | | _____   ___  ___ ___| |     _ __ __ _  ___| | ___ __ " + "\n" +
            @" | | |  | |/ _ \ \ / / |/ __/ _ \ |    | '__/ _` |/ __| |/ / '__|" + "\n" +
            @" | | |__| |  __/\ V /| | (_|  __/ |____| | | (_| | (__|   <| |   " + "\n" +
            @" |_|_____/ \___| \_/ |_|\___\___|\_____|_|  \__,_|\___|_|\_\_|   " + "\n" +
            @"                                                                 " + "\n" +
            "";

        public static string StringIndent { get; set; } = "   ";

        public static void ShowSplashScreen()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            using (var reader = new StringReader(SplashText))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    Console.WriteLine(line);
                    Thread.Sleep(80);
                }
            }

            Thread.Sleep(300);
            Console.ResetColor();
            Console.Clear();
            DisplaySplashText();
        }

        public static void DisplaySplashText()
        {
            Console.WriteLine(SplashText);
        }

        public static void ShowMainMenu(string warningMessage = "", bool warnForNoResponse = false)
        {
            Console.Clear();
            DisplaySplashText();

            if(warningMessage != "")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(StringIndent + "■  Warning: " + warningMessage);
                Console.ResetColor();
            }

            if(warnForNoResponse)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(StringIndent + "■  Please note that the program may become unresponsive");
                Console.WriteLine(StringIndent + "   and will not respond on further commands.");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(StringIndent + "■  ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Connected to {iDeviceCrackr.DeviceName}");
            Console.ResetColor();

            DisplayMenu.MainMenu.ShowMenu(false);
        }
    }
}
