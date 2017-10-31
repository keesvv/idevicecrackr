using System;
using System.Threading;
using System.IO;

using Renci.SshNet;
using iDeviceCrackr.Classes;

namespace iDeviceCrackr
{
    public class iDeviceCrackr
    {
        public static string DeviceType { get; set; }
        public static string DeviceName { get; set; }

        public static string Hostname { get; set; }
        public static int Port { get; set; } = 22;
        public static string Username { get; set; } = "root";
        public static string Password { get; set; }
        public static SshClient Client { get; set; }
        public static Commands Commands { get; set; }

        // ======================================= \\
        //   Set to true and assign credentials    \\

        public static bool DeveloperMode = true;
        public static string DeveloperHostname = "192.168.1.18";
        public static string DeveloperPassword = "developer.xyz";

        // ======================================= \\


        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += (o, ev) =>
            {
                Client.Disconnect();
                Client.Dispose();
            };

            Tools.ShowSplashScreen();
            SSH.Connect(DeveloperMode);

            while (true)
            {
                Tools.ShowMainMenu();
            }
        }        
    }
}
