using System;
using System.Diagnostics;
using System.Windows.Forms;
using ApiLibrary;
namespace CsvPlotterAndGrapher
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

#if (!DEBUG)
            FlaskApi.StartAPIServer();
#endif
            

            Application.Run(new MainForm());
        }
    }
}