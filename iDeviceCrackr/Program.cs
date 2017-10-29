using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Renci.SshNet;
using System.IO;

namespace iDeviceCrackr
{
    public class Program
    {

        static string deviceType = null;
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
            ShowMenu();
            Connect();

        }

        static void ShowSplashScreen()
        {

            using (var reader = new StringReader(splashText))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    Console.WriteLine(line);
                    Thread.Sleep(50);
                }
            }

            Thread.Sleep(100);

        }

        static void DisplaySplashText()
        {
            Console.WriteLine(splashText);
        }

        static void Connect()
        {
            Console.Write("IP Address: ");
            hostName = Console.ReadLine();
            Console.Write("Port: ");
            port = int.Parse(Console.ReadLine());
            Console.Write("Root password: ");
            password = Console.ReadLine();

            Console.Clear();
            DisplaySplashText();

            Console.WriteLine("Connecting to remote device...");
            client = new SshClient(hostName, port, username, password);
            client.Connect();
            commands = new Commands(client);
            Console.WriteLine(commands.retrieveDeviceName.Execute());

            ShowMenu();
        }

        static void ShowMenu()
        {

            Console.Clear();
            DisplaySplashText();

            Console.WriteLine($"Connected to ");
            string menuItems = 
                "[0] Power Options" + "\n"
                ;

            Console.WriteLine(menuItems);

        }

    }
}
