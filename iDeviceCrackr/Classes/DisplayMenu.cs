using System;
using System.Collections.Generic;

using Renci.SshNet;

namespace iDeviceCrackr.Classes
{
    public class DisplayMenu
    {
        public static Commands Commands { get; set; }
        public static SshClient Client { get; set; }

        public static Menu MainMenu = new Menu("Main Menu", ConsoleColor.Cyan, new List<MenuItem>()
        {
            new MenuItem(0, "Exit iDeviceCrackr", ConsoleColor.Red, ConsoleKey.D0, new Action(delegate() { Client.Disconnect(); Environment.Exit(0); })),
            new MenuItem(1, "Power Options", ConsoleColor.Red, ConsoleKey.D1, new Action(delegate() { PowerOptionsMenu.ShowMenu(); })),
            new MenuItem(2, "Device Information", ConsoleColor.DarkGray, ConsoleKey.D2, new Action(delegate()
            {
                Console.ResetColor();
                Console.Clear();
                Tools.DisplaySplashText();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(Tools.StringIndent + "Device Information\n");
                Console.ResetColor();

                Console.WriteLine(
                    Tools.StringIndent + $"Device Type: {Commands.RetrieveDeviceType.Execute()}" +
                    Tools.StringIndent + $"Device Name: {Commands.RetrieveDeviceName.Execute()}" +
                    Tools.StringIndent + $"Device UDID: {Commands.RetrieveDeviceUDID.Execute()}\n" +
                    Tools.StringIndent + $"System Name: {Commands.RetrieveSystemName.Execute()}" +
                    Tools.StringIndent + $"System Version: {Commands.RetrieveSystemVersion.Execute()}\n" +
                    Tools.StringIndent + $"Press any key to return to the previous screen."
                    );

                Console.ReadKey(true);
                Tools.ShowMainMenu();
            }))
        });

        public static Menu PowerOptionsMenu = new Menu("Power Options", ConsoleColor.Red, new List<MenuItem>()
        {
            new MenuItem(0, "Respring", null, ConsoleKey.D0, new Action(delegate() { Commands.RespringDevice.Execute(); })),
            new MenuItem(1, "Reboot", null, ConsoleKey.D1, new Action(delegate()
            {
                try
                {
                    Commands.RebootDevice.Execute();
                    Tools.ShowMainMenu("Your device is rebooting.", true);
                } catch(Exception) { }                
            })),

            new MenuItem(2, "Shutdown", null, ConsoleKey.D2, new Action(delegate()
            {
                try
                {
                    Commands.ShutdownDevice.Execute();
                    Tools.ShowMainMenu("Your device is shutting down.", true);
                } catch(Exception) { }
            })),

            new MenuItem(3, "Safe Mode", null, ConsoleKey.D3, new Action(delegate()
            {
                try
                {
                    Commands.SafeModeDevice.Execute();
                    Tools.ShowMainMenu("Your device is entering Safe Mode.", true);
                } catch(Exception) { }
            }))
        });
    }
}
