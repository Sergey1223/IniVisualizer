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
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            IniServer.MainForm serverForm = new IniServer.MainForm();

            serverForm.FormClosed += OnFormClosed;
            serverForm.Show();

            IniClient.MainForm clientForm = new IniClient.MainForm();
            
            clientForm.FormClosed += OnFormClosed;
            clientForm.Show();
            
            Application.Run();
        }

        private static void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Form closedForm = sender as Form;
            
            closedForm.FormClosed -= OnFormClosed;

            Form openForm = Application.OpenForms[0];
            
            openForm.FormClosed -= OnFormClosed;
            openForm.Close();

            Application.Exit();
        }
    }
}
