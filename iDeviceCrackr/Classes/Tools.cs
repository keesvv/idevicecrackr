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

        public static string Indent { get; set; } = "   ";

        public static void ShowSplashScreen()
        {
            Console.Clear();
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
            ShowSplashText();
        }

        public static void ShowSplashText()
        {
            Console.WriteLine(SplashText);
        }

        public static void ShowFatalError(string title, Exception exception, string fixHint = "")
        {
            Console.ResetColor();
            Console.Clear();
            ShowSplashText();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Indent + "An error occured");
            Console.WriteLine(Indent + "=======================================================");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Indent + title);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Indent + "=======================================================\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(Indent + "Detailed exception information:");
            Console.WriteLine(Indent + "Localized message: " + exception.Message);
            Console.WriteLine(Indent + "Error code: " + exception.HResult);
            Console.WriteLine(Indent + "Exception source: " + exception.Source);

            Console.WriteLine();

            if(string.IsNullOrEmpty(fixHint) != true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(Indent + "[Probable Solution] " + fixHint);
            }

            if(string.IsNullOrEmpty(exception.HelpLink) != true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Indent + "More help available at " + exception.HelpLink + " .");
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n" +
                Indent + "Try restarting iDeviceCrackr, your Wi-Fi connection or" +
                "\n" + Indent + "your computer to solve the problem."
                );

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + Indent + "Press any key to quit iDeviceCrackr...");
            Console.ResetColor();

            Console.ReadKey(false);
            Environment.Exit(1);
        }

        public static void ShowMainMenu(string errorMessage = "", string warningMessage = "", bool warnForNoResponse = false)
        {
            Console.Clear();
            ShowSplashText();

            if (string.IsNullOrEmpty(errorMessage) != true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Indent + "■  Error: " + errorMessage);
                Console.ResetColor();
            }

            if (string.IsNullOrEmpty(warningMessage) != true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Indent + "■  Warning: " + warningMessage);
                Console.ResetColor();
            }

            if (warnForNoResponse)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Indent + "■  Please note that the program may become unresponsive");
                Console.WriteLine(Indent + "   and will not respond on further commands.");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Indent + "■  ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Connected to {iDeviceCrackr.DeviceName}");
            Console.ResetColor();

            DisplayMenu.MainMenu.ShowMenu(false);
        }
    }
}
