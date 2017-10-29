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
            new MenuItem(0, "Power Options", ConsoleColor.Red, ConsoleKey.D0, new Action(delegate() { PowerOptionsMenu.ShowMenu(); }))
        });

        public static Menu PowerOptionsMenu = new Menu("Power Options", ConsoleColor.Red, new List<MenuItem>()
        {
            new MenuItem(0, "Respring", null, ConsoleKey.D0, new Action(delegate() { Commands.respringDevice.Execute(); })),
            new MenuItem(1, "Reboot", null, ConsoleKey.D1, new Action(delegate() { Commands.rebootDevice.Execute(); Client.Disconnect(); }))
        });
    }
}
