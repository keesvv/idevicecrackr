﻿using Renci.SshNet;

namespace iDeviceCrackr
{
    public class Commands
    {

        public static SshClient client = null;
        public Commands(SshClient currentClient)
        {
            client = currentClient;
        }
        
        // Device information commands
        public SshCommand RetrieveDeviceType = client.CreateCommand("uname -m");
        public SshCommand RetrieveDeviceName = client.CreateCommand("sbdevice -n");
        public SshCommand RetrieveDeviceUDID = client.CreateCommand("sbdevice -u");

        // Battery information commands
        public SshCommand RetrieveBatteryState = client.CreateCommand("sbdevice -s");
        public SshCommand RetrieveBatteryLevel = client.CreateCommand("sbdevice -l");

        // System information commands
        public SshCommand RetrieveSystemName = client.CreateCommand("sbdevice -N");
        public SshCommand RetrieveSystemVersion = client.CreateCommand("sbdevice -V");

        // Device power commands
        public SshCommand RebootDevice = client.CreateCommand("reboot");
        public SshCommand ShutdownDevice = client.CreateCommand("halt");
        public SshCommand RespringDevice = client.CreateCommand("killall SpringBoard");
        public SshCommand SafeModeDevice = client.CreateCommand("touch /var/mobile/Library/Preferences/" +
            "com.saurik.mobilesubstrate.dat && killall SpringBoard");

        // App interaction commands
        public SshCommand OpenSettings = client.CreateCommand("open com.apple.Preferences");
        
    }
}
