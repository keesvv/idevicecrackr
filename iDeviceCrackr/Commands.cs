using Renci.SshNet;

namespace iDeviceCrackr
{
    public class Commands
    {
        private SshClient client = null;
        public Commands(SshClient client)
        {
            this.client = client;
        }
        
        public SshCommand retrieveDeviceName = client.CreateCommand("uname -m");
    }
}
