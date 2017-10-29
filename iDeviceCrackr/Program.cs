using System;
using System.Threading;
using System.IO;

using Renci.SshNet;

namespace iDeviceCrackr
{
    public class Program
    {

        static string deviceName = null;
        static string hostName = null;
        static int port = 22;
        static string username = "root";
        static string password = null;
        static SshClient client = null;
        static Commands commands = null;

        static string splashText =
            @"  _ _____             _           _____                _         " + "\n" +
            @" (_)  __ \           (_)         / ____|              | |        " + "\n" +
            @"  _| |  | | _____   ___  ___ ___| |     _ __ __ _  ___| | ___ __ " + "\n" +
            @" | | |  | |/ _ \ \ / / |/ __/ _ \ |    | '__/ _` |/ __| |/ / '__|" + "\n" +
            @" | | |__| |  __/\ V /| | (_|  __/ |____| | | (_| | (__|   <| |   " + "\n" +
            @" |_|_____/ \___| \_/ |_|\___\___|\_____|_|  \__,_|\___|_|\_\_|   " + "\n" +
            @"                                                                 " + "\n" +
            "";

        static void Main(string[] args)
        {

            // Initialize iDeviceCrackr
            ShowSplashScreen();
            Connect();

        }

        static void ShowSplashScreen()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            using (var reader = new StringReader(splashText))
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

        static void DisplaySplashText()
        {
            Console.WriteLine(splashText);
        }

        static void Connect()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("IP Address: ");
            hostName = Console.ReadLine();
            Console.Write("Port: ");
            port = int.Parse(Console.ReadLine());
            Console.Write("Root password: ");
            password = Console.ReadLine();
            Console.ResetColor();

            Console.Clear();
            DisplaySplashText();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Connecting to remote device...");
            Console.ResetColor();

            client = new SshClient(hostName, port, username, password);
            client.Connect();
            commands = new Commands(client);
            deviceName = commands.retrieveDeviceName.Execute();

            ShowMenu();
        }

        static void ShowMenu()
        {

            Console.Clear();
            DisplaySplashText();

            Console.WriteLine($"Connected to {deviceName}");
            string menuItems = 
                "[0] Power Options" + "\n" +
                "[1] Device Information" + "\n" +
                "[2] Install app from file" + "\n" +
                "[3] "
                ;

            Console.WriteLine(menuItems);

        }

    }
}
