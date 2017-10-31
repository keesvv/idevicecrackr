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
                Tools.ShowSplashText();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(Tools.Indent + "Device Information\n");
                Console.ResetColor();

                Console.WriteLine(
                    Tools.Indent + $"Device Type: {Commands.RetrieveDeviceType.Execute()}" +
                    Tools.Indent + $"Device Name: {Commands.RetrieveDeviceName.Execute()}" +
                    Tools.Indent + $"Device UDID: {Commands.RetrieveDeviceUDID.Execute()}\n" +
                    Tools.Indent + $"Battery State: {Commands.RetrieveBatteryState.Execute()}" +
                    Tools.Indent + $"Battery Level: {Math.Round(float.Parse(Commands.RetrieveBatteryLevel.Execute()) * 100, 0)}\n\n" +
                    Tools.Indent + $"System Name: {Commands.RetrieveSystemName.Execute()}" +
                    Tools.Indent + $"System Version: {Commands.RetrieveSystemVersion.Execute()}\n" +
                    Tools.Indent + $"Press any key to return to the previous screen."
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
                } catch(Exception) { }
                Tools.ShowMainMenu(null, "Your device is rebooting.", true);
            })),

            new MenuItem(2, "Shutdown", null, ConsoleKey.D2, new Action(delegate()
            {
                try
                {
                    Commands.ShutdownDevice.Execute();
                } catch(Exception) { }
                Tools.ShowMainMenu(null, "Your device is shutting down.", true);
            })),

            new MenuItem(3, "Safe Mode", null, ConsoleKey.D3, new Action(delegate()
            {
                try
                {
                    Commands.SafeModeDevice.Execute();                    
                } catch(Exception) { }
                Tools.ShowMainMenu(null, "Your device is entering Safe Mode.", true);
            }))
        });
    }
}
