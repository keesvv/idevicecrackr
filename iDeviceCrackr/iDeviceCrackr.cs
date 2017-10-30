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

        static void Main(string[] args)
        {
            Tools.ShowSplashScreen();
            SSH.Connect();

            while (true)
            {
                Tools.ShowMainMenu();
            }
        }        
    }
}
