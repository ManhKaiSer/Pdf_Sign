using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.IO;


namespace DOCXSigner
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int pid);

        //[System.Runtime.InteropServices.DllImport("kernel32.dll")]
        //static extern bool AttachConsole(int dwProcessId);

        private static void ConsoleNewLine()
        {
            try
            {
                Console.WriteLine(Environment.NewLine);
                // When using a winforms app with AttachConsole the app complets but there is no newline after the process stops. This gives the newline and looks normal from the console:
                SendKeys.SendWait("{ENTER}");

            }
            catch { }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
