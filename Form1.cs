using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace DotNetDownloader
{
    public partial class Form1 : Form
    {
        string url = string.Empty;
        string exeInstaller = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: //4.5
                    url = "https://download.microsoft.com/download/B/A/4/BA4A7E71-2906-4B2D-A0E1-80CF16844F5F/dotNetFx45_Full_setup.exe";
                    exeInstaller = @"C:\Temp\dotNetFx45_Full_setup.exe";
                    break;
                case 1: // 4.5.1
                    url = "https://download.microsoft.com/download/1/6/7/167F0D79-9317-48AE-AEDB-17120579F8E2/NDP451-KB2858728-x86-x64-AllOS-ENU.exe";
                    exeInstaller = @"C:\Temp\NDP451-KB2858728-x86-x64-AllOS-ENU.exe";
                    break;
                case 2: //4.5.2
                    url = "https://download.microsoft.com/download/E/2/1/E21644B5-2DF2-47C2-91BD-63C560427900/NDP452-KB2901907-x86-x64-AllOS-ENU.exe";
                    exeInstaller = @"C:\Temp\NDP452-KB2901907-x86-x64-AllOS-ENU.exe";
                    break;
                case 3: //4.6.0
                    url = "https://download.microsoft.com/download/C/3/A/C3A5200B-D33C-47E9-9D70-2F7C65DAAD94/NDP46-KB3045557-x86-x64-AllOS-ENU.exe";
                    exeInstaller = @"C:\Temp\NDP46-KB3045557-x86-x64-AllOS-ENU.exe";
                    break;
                case 4: //4.6.1
                    url = "https://download.microsoft.com/download/E/4/1/E4173890-A24A-4936-9FC9-AF930FE3FA40/NDP461-KB3102436-x86-x64-AllOS-ENU.exe";
                    exeInstaller = @"C:\Temp\NDP461-KB3102436-x86-x64-AllOS-ENU.exe";
                    break;
                case 5: //4.6.2
                    url = "https://download.visualstudio.microsoft.com/download/pr/8e396c75-4d0d-41d3-aea8-848babc2736a/80b431456d8866ebe053eb8b81a168b3/ndp462-kb3151800-x86-x64-allos-enu.exe";
                    exeInstaller = @"C:\Temp\ndp462-kb3151800-x86-x64-allos-enu.exe";
                    break;
                case 6: //4.7.0
                    url = "https://download.visualstudio.microsoft.com/download/pr/2dfcc711-bb60-421a-a17b-76c63f8d1907/e5c0231bd5d51fffe65f8ed7516de46a/ndp47-kb3186497-x86-x64-allos-enu.exe";
                    exeInstaller = @"C:\Temp\ndp47-kb3186497-x86-x64-allos-enu.exe";
                    break;
                case 7: //4.7.1
                    url = "https://download.visualstudio.microsoft.com/download/pr/4312fa21-59b0-4451-9482-a1376f7f3ba4/9947fce13c11105b48cba170494e787f/ndp471-kb4033342-x86-x64-allos-enu.exe";
                    exeInstaller = @"C:\Temp\ndp471-kb4033342-x86-x64-allos-enu.exe";
                    break;
                case 8: //4.7.2
                    url = "https://download.visualstudio.microsoft.com/download/pr/1f5af042-d0e4-4002-9c59-9ba66bcf15f6/089f837de42708daacaae7c04b7494db/ndp472-kb4054530-x86-x64-allos-enu.exe";
                    exeInstaller = @"C:\Temp\ndp472-kb4054530-x86-x64-allos-enu.exe";
                    break;
                case 9: //4.8
                    url = "https://download.visualstudio.microsoft.com/download/pr/2d6bb6b2-226a-4baa-bdec-798822606ff1/8494001c276a4b96804cde7829c04d7f/ndp48-x86-x64-allos-enu.exe";
                    exeInstaller = @"C:\Temp\ndp48-x86-x64-allos-enu.exe";
                    break;
                default:
                    MessageBox.Show("Invalid selection");
                    break;
            }
        }

        private static void Download(string url, string installer)
        {
            WebClient wc = new WebClient();
            try
            {
                wc.DownloadFile(url, installer);
                MessageBox.Show("Installer downloaded!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            wc.Dispose();
        }

        private void CheckTempFolder()
        {
            if (!Directory.Exists(@"C:\Temp"))
            {
                Directory.CreateDirectory(@"C:\Temp");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (url != string.Empty && exeInstaller != string.Empty)
            {
                CheckTempFolder();
                Download(url, exeInstaller);
            }
            else
            {
                MessageBox.Show("Please select a framework from the dropdown menu");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(exeInstaller))
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = exeInstaller;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                }
                catch (Exception)
                {
                    //Do nothing
                }
            }
            else
            {
                MessageBox.Show("The installer for the runtime selected does not exist");
            }
        }
    }
}
