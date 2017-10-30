using System;
using Renci.SshNet;

using static iDeviceCrackr.iDeviceCrackr;

namespace iDeviceCrackr.Classes
{
    public class SSH
    {
        public static void Connect()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Tools.StringIndent + "IP Address: ");
            Hostname = Console.ReadLine();
            Console.Write(Tools.StringIndent + "Root password: ");
            Password = Console.ReadLine();
            Console.ResetColor();

            Console.Clear();
            Tools.DisplaySplashText();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Tools.StringIndent + "Connecting to remote device...");
            Console.ResetColor();

            Client = new SshClient(Hostname, Port, Username, Password);
            Client.Connect();

            Commands.client = Client;
            iDeviceCrackr.Commands = new Commands(Client);
            DisplayMenu.Client = Client;
            DisplayMenu.Commands = iDeviceCrackr.Commands;

            DeviceType = iDeviceCrackr.Commands.RetrieveDeviceType.Execute();
            DeviceName = iDeviceCrackr.Commands.RetrieveDeviceName.Execute();
            Tools.ShowMainMenu();
        }
    }
}
