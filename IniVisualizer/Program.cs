using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IniVisualizer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            IniServer.MainForm serverForm = new IniServer.MainForm();
            serverForm.Show();

            IniClient.MainForm clientForm = new IniClient.MainForm();
            clientForm.Show();
            
            Application.Run();
        }
    }
}
