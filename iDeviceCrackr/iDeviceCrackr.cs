using System;
using System.Threading;
using System.IO;

using Renci.SshNet;
using iDeviceCrackr.Classes;

namespace iDeviceCrackr
{
    public class iDeviceCrackr
    {
        static string DeviceType { get; set; }
        static string HostName { get; set; }
        static int Port { get; set; } = 22;
        static string Username { get; set; } = "root";
        static string Password { get; set; }
        static SshClient Client { get; set; }
        static Commands Commands { get; set; }

        static void Main(string[] args)
        {
            Tools.ShowSplashScreen();
            Connect();
        }

        static void Connect()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("IP Address: ");
            HostName = Console.ReadLine();
            Console.Write("Root password: ");
            Password = Console.ReadLine();
            Console.ResetColor();

            Console.Clear();
            Tools.DisplaySplashText();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Connecting to remote device...");
            Console.ResetColor();

            Client = new SshClient(HostName, Port, Username, Password);
            Client.Connect();

            Commands.client = Client;
            Commands = new Commands(Client);
            DisplayMenu.Client = Client;
            DisplayMenu.Commands = Commands;

            DeviceType = Commands.RetrieveDeviceType.Execute();
            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.Clear();
            Tools.DisplaySplashText();

            Console.WriteLine($"Connected to {DeviceType}");
            DisplayMenu.MainMenu.ShowMenu();
        }

    }
}
