using System;
using System.Net.Sockets;

using Renci.SshNet;
using Renci.SshNet.Common;
using static iDeviceCrackr.iDeviceCrackr;

namespace iDeviceCrackr.Classes
{
    public class SSH
    {
        public static void Connect()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Tools.Indent + "IP Address: ");
            Hostname = Console.ReadLine();
            Console.Write(Tools.Indent + "Root password: ");
            Password = Console.ReadLine();
            Console.ResetColor();

            Console.Clear();
            Tools.ShowSplashText();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Tools.Indent + "Connecting to remote device...");
            Console.ResetColor();

            Client = new SshClient(Hostname, Port, Username, Password);
            try
            {
                Client.Connect();
            }

            catch (SocketException ex) { Tools.ShowFatalError("The remote device refused the connection.", ex,
                "Try restarting your device, enable SSH on your device or re-enter the IP Address."); }
            catch (SshAuthenticationException ex) { Tools.ShowFatalError("A SSH authentication error occured.", ex,
                "Try re-entering your username and password."); }

            catch (SshConnectionException ex) { Tools.ShowFatalError("The connection could not be established.", ex); }
            catch (ProxyException ex) { Tools.ShowFatalError("A proxy is causing an unknown error.", ex,
                "Try disabling your proxy."); }

            catch (Exception ex) { Tools.ShowFatalError("An unknown error occured connecting to the remote device.", ex,
                "Try restarting your computer or Wi-Fi connection."); }

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
