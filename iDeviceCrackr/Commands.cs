using Renci.SshNet;

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
        public SshCommand retrieveDeviceName = client.CreateCommand("uname -m");

        // Device power commands
        public SshCommand rebootDevice = client.CreateCommand("reboot");
        public SshCommand shutdownDevice = client.CreateCommand("shutdown");
        public SshCommand respringDevice = client.CreateCommand("killall SpringBoard");

        // App interaction commands
        public SshCommand openSettings = client.CreateCommand("open com.apple.Preferences");
        
    }
}
