# idevicecrackr
A full-featured tool for remotely modifying a remote jailbroken iDevice.

#### What is iDeviceCrackr?
iDeviceCrackr is a useful tool that you can use to change your iDevice the way you want, remotely.
The only thing you need is a jailbroken iDevice and a Wi-Fi connection.

#### How does it work?
iDeviceCrackr sets up SSH connection between your computer and your iDevice. SSH stands for Secure Shell, that means all data transferred between iDeviceCrackr and your iDevice is encrypted, safe and secure!

#### Current program features (for now)
- Show an overview of the device's information
- Respring/Reboot/Shutdown/Enter Safe Mode remotely

#### Upcoming features
- Media transfer
- App modification
- A lot of new menus
- Install apps from local file on remote device
- View the device's filesystem
- Advanced security
- Show an overview of all installed Cydia Sources/Tweaks
- Even more...

#### How to set up iDeviceCrackr
First off, you need to be on the same Wi-Fi network on your iDevice and your computer.

**Step 1**: Gather the required tools on Cydia
- Cydia Substrate
- Substrate Safe Mode
- sbutils
- OpenSSH
- OpenSSL
- open
- SSH Connect
- MTerminal

All tools can be found in the *BigBoss* Repo.

**Step 2**: Change the root password

Of course you don't want to stay with the default password, but if you do, you can simply skip this step.
To change the root password, open `MTerminal` or `Terminal` from your Homescreen.

Then, simply type `su passwd` and enter the default password, which is `alpine` without any capital letters.

Now you can change your password to whatever you like. Remember: this password is used for the connection!

**Step 3**: Enable SSH

SSH is not enabled by default on your iDevice. If you have *OpenSSH*, *OpenSSL* and *SSH Connect* installed successfully,
you can go to Settings and at the top where you can find *Airplane Mode* and *Wi-Fi*, you'll see *SSH* between Wi-Fi and Bluetooth.

Once you got there, simple enable the switch called *SSH*.

**Step 4**: Almost done!

Your iDevice is now ready to be connected over a remote connection. Please note that whenever you reboot your iDevice, *SSH* will be disabled automatically in the Settings app. To re-enable it, simple go to Settings > *SSH* > Enable.

Now you are going to test the connection between the computer and your iDevice.

If you have downloaded the latest version of iDeviceCrackr to your computer, open it from the Command Prompt and you will be prompted for an IP Address. To know what your iDevice's IP Address is, on your iDevice, open up your Settings app, navigate to *SSH* and remember the upper IP Address. It should be in a format like `192.168.x.xx`, such as `192.168.1.18`, `192.168.1.20`, etc.

Once you have entered the IP Address, you will be prompted for a password, which is the new password set in **Step 2**.

Now you are good to go! If you have any questions or suggestions for me, you can leave me a message on my email address or open a new request at the Issues page.
