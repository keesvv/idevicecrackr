using System;
using System.IO;
using System.Threading;

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
    }
}
