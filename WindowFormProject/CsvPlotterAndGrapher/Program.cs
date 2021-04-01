using System;
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
            FlaskApi.StartAPIServer();
            
            Application.Run(new Form1());
        }
    }
}